import React, { Component } from 'react';

export class Chirp extends Component {
    constructor(props) {
        super(props);        
    }    

    render() {

        return (
            <div key={ this.props.id.toString()} className="card text-center mt-4 mb-4">
                <div className="card-header">
                    Användare: {this.props.userName}<br/> Tid: {this.props.date}
                </div>
                <div className="card-body">                    
                    <p className="card-text">{this.props.message}</p>
                </div>
                <div className="card-footer text-muted">
                    <span className="badge badge-pill badge-secondary mr-4">Edit</span>
                    <span className="badge badge-pill badge-danger">Delete</span>
                </div>
            </div>
        );
    }
}