import React, { Component } from 'react';
import * as signalR from "@microsoft/signalr/dist/browser/signalr.js";
import { Chirp } from './Chirp';
import { NewChirpForm } from './NewChirpForm';

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            chirps: [],
            hubConnection: new signalR.HubConnectionBuilder()
                .withUrl("/chirpHub")
                .configureLogging(signalR.LogLevel.Trace)
                .build(),
        };

        this.createNewChirp = this.createNewChirp.bind(this);
        this.deleteChirp = this.deleteChirp.bind(this);
        this.editChirp = this.editChirp.bind(this);
        
    }

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

    componentWillUnmount = () => {
        this.state.hubConnection
            .stop();
    }    

    createNewChirp(userName, message, pipeTag) {        
        this.state.hubConnection.invoke("CreateNewChirp", userName, message, pipeTag).catch(function (err) {
            console.log(err.toString());
        });        
    }

    deleteChirp(id) {
        this.state.hubConnection.invoke("DeleteChirp", id).catch(function (err) {
            console.log(err.toString());
        });
    }

    editChirp(id, userName, message, pipeTag) {
        this.state.hubConnection.invoke("EditChirp", id, userName, message, pipeTag).catch(function (err) {
            console.log(err.toString());
        });
    }

    render() {
        const chirpsList = this.state.chirps;

        const chirpsListReverted = chirpsList.reverse();

        const renderChirp = chirpsListReverted.map((chirp) => (
            <Chirp
                key={chirp.id}
                id={chirp.id}
                userName={chirp.userName}
                message={chirp.message}
                time={chirp.time}
                pipeTag={chirp.pipeTag}
                deleteChirp={this.deleteChirp}
                editChirp={this.editChirp}
            />
        ));
    return (
      <div>
        <div>
                <h1>Concorde Chirper</h1>
                <NewChirpForm createNewChirp={this.createNewChirp }/>
                
        </div>
        <div>                
                {renderChirp}                    
        </div>
      </div>
    );
  }
}
