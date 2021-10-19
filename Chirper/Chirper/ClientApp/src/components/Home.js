import React, { Component } from 'react';
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
    }
    static displayName = Home.name;

    componentDidMount = () => {        

        this.state.hubConnection.on('RecieveAllChirps', (allChirps) => {
            
            this.setState({ chirps: allChirps });
        });

        this.state.hubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log('Error while establishing connection :('));
    }

    renderChirp() {
        return this.state.chirps.map((chirp) => {
            const { id, userName, message, date } = chirp //destructuring
            return (
                <Chirp userName={userName} message={message} date={date}/>
            )
        })
    }

    render() {
        
    return (
      <div>
        <div>
                <h1>Concorde Chirper</h1>
                <button type="button" class="btn btn-secondary">Nytt Chirp</button>
        </div>
        <div>
                <table className="table" id='students'>
                    <tbody>
                        {this.renderChirp()}
                    </tbody>
                </table>
        </div>
      </div>
    );
  }
}
