import React, { Component } from 'react';
import * as signalR from "@microsoft/signalr/dist/browser/signalr.js";
import { Link } from 'react-router-dom';


export class PipeTagView extends Component {
    constructor(props) {
        super(props);

        this.state = {
            chirps: [],
            pipeTagViewHubConnection: new signalR.HubConnectionBuilder()
                .withUrl("/chirpHub")
                .configureLogging(signalR.LogLevel.Information)
                .build(),
        };        
    }
    

    componentDidMount = () => {        

        this.state.pipeTagViewHubConnection.on('RecieveAllChirps', (allChirps) => {
            console.log('In RecieveAllChirps ' + JSON.stringify(allChirps));
            this.setState({ chirps: allChirps });
        });

        this.state.pipeTagViewHubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log('Error while establishing connection :('));
    }

    componentWillUnmount = () => {
        this.state.pipeTagViewHubConnection
            .stop();
    }

    renderChirp() {
        const { match: { params } } = this.props;        
        var selectedPipeTag = params.pipeTag;
        console.log('In PipeTagView renderChirp ' + selectedPipeTag);

        var result = this.state.chirps.filter(chirp => {
            return chirp.pipeTag === selectedPipeTag
        });

        console.log('In PipeTagView renderChirp result ' + result);

        return result.map((chirp) => {
            const { id, userName, message, time, pipeTag } = chirp //destructuring
            return (
                <div key={id.toString()} className="card text-center mt-4 mb-4">
                    <div className="card-header">
                        Anv&auml;ndare: {userName}<br />
                        Tid: {time}<br />
                        Id: {id.toString()}<br />
                    </div>
                    <div className="card-body">
                        <p className="card-text">{message}</p>
                        <p className="card-text text-info">|{pipeTag}</p>
                    </div>
                    <div className="card-footer text-muted">
                        
                    </div>

                    
                </div>
            )
        })
        
    }    

    render() {
        
    return (
      <div>
        <div>
                <h1>Concorde Chirper</h1>
                <p>Vy med vald |Tag</p>
                <Link to={'/'}>G&aring; till alla Chirps</Link>
                
        </div>
        <div>                
                {this.renderChirp()}                    
        </div>
      </div>
    );
  }
}
