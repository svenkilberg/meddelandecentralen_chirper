import React, { Component } from 'react';
import { NewChirpForm } from './NewChirpForm';
import { Chirp } from './Chirp';
import * as signalR from "@microsoft/signalr/dist/browser/signalr.js";

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            chirps: [],
            hubConnection: new signalR.HubConnectionBuilder()
                .withUrl("/chirpHub")
                .configureLogging(signalR.LogLevel.Information)
                .build(),
        };
        this.createNewChirp = this.createNewChirp.bind(this);
    }
    static displayName = Home.name;

    componentDidMount = () => {        

        this.state.hubConnection.on('RecieveAllChirps', (allChirps) => {
            console.log('In RecieveAllChirps ' + JSON.stringify(allChirps));
            this.setState({ chirps: allChirps });
        });

        this.state.hubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log('Error while establishing connection :('));
    }

    renderChirp() {
        
        return this.state.chirps.map((chirp) => {
            const { id, userName, message, time } = chirp //destructuring
            return (
                <Chirp id={id} userName={userName} message={message} time={time}/>
            )
        })
        
    }

    createNewChirp(userName, message) {
        //alert('In createNewChirp function: ' + userName + ' and a message ' + message);
        this.state.hubConnection.invoke("CreateNewChirp", userName, message).catch(function (err) {
            console.log(err.toString());
        });
    }

    render() {
        
    return (
      <div>
        <div>
                <h1>Concorde Chirper</h1>
                <NewChirpForm createNewChirp={this.createNewChirp }/>
                
        </div>
        <div>                
                {this.renderChirp()}                    
        </div>
      </div>
    );
  }
}
