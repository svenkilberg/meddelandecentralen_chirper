import React, { Component } from 'react';

export class Chirp extends Component {
    constructor(props) {
        super(props);        
    }    

    render() {

        return (
            <div class="card text-center mt-4 mb-4">
                <div class="card-header">
                    Användare: {this.props.userName}<br/> Tid: {this.props.date}
                </div>
                <div class="card-body">                    
                    <p class="card-text">{this.props.message}</p>
                </div>
                <div class="card-footer text-muted">
                    <span class="badge badge-pill badge-secondary mr-4">Edit</span>
                    <span class="badge badge-pill badge-danger">Delete</span>
                </div>
            </div>
        );
    }
}