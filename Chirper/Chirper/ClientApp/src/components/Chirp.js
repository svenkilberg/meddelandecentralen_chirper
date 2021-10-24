import React, { Component } from 'react';

export class Chirp extends Component {
    constructor(props) {
        super(props);

        this.handleDeleteClick = this.handleDeleteClick.bind(this);
    }

    handleDeleteClick(id) {        
        this.props.deleteChirp(id);
    }

    render() {

        return (
            <div key={ this.props.id.toString()} className="card text-center mt-4 mb-4">
                <div className="card-header">
                    Användare: {this.props.userName}<br />
                    Tid: {this.props.time}<br />
                    Id: {this.props.id.toString()}<br />
                </div>
                <div className="card-body">                    
                    <p className="card-text">{this.props.message}</p>
                    <p className="card-text text-info">|{this.props.pipeTag}</p>
                </div>
                <div className="card-footer text-muted">
                    <span className="badge badge-pill badge-secondary mr-4">Edit</span>
                    <span className="badge badge-pill badge-danger chirpButtons" onClick={(() => this.handleDeleteClick(this.props.id))}>Delete</span>
                </div>
            </div>
        );
    }
}