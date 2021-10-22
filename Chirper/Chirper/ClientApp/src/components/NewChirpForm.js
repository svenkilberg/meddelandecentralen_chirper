import React, { Component } from 'react';

export class NewChirpForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            userNameInput: '',
            messageInput: '',
            pipeTagInput: '',
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        // Input field name and state is named the same.
        // Makes connection to state automatic using event.target.name
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit(event) {
        //alert('A name was submitted: ' + this.state.userNameInput + ' and a message ' + this.state.messageInput);
        event.preventDefault();
        this.props.createNewChirp(this.state.userNameInput, this.state.messageInput, this.state.pipeTagInput);
        this.setState({ userNameInput: '' });
        this.setState({ messageInput: '' });
        this.setState({ pipeTagInput: '' });
    }

    render() {

        return (
            <form>
                <div className="form-group">
                    <label className="label">Anv&auml;ndarnamn</label>
                    <input
                        type="text"
                        name="userNameInput"
                        className="form-control"
                        id="userNameInput"
                        value={this.state.userNameInput}
                        onChange={this.handleChange}
                    ></input>
                    
                </div>
                <div className="form-group">
                    <label className="label">Meddelande</label>
                    <input
                        type="text"
                        name="messageInput"
                        className="form-control"
                        id="messageInput"
                        value={this.state.messageInput}
                        onChange={this.handleChange}
                ></input>
                </div>
                <div className="form-group">
                    <label className="label">|Tag</label>
                    <input
                        type="text"
                        name="pipeTagInput"
                        className="form-control"
                        id="pipeTagInput"
                        value={this.state.pipeTagInput}
                        onChange={this.handleChange}
                    ></input>
                </div>
                <button type="submit" className="btn btn-secondary" onClick={(event => this.handleSubmit(event))}>Nytt Chirp</button>
            </form>
        );
    }
}