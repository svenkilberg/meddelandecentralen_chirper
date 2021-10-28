import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Chirp extends Component {
    constructor(props) {
        super(props);
        this.state = {
            editActive: false,
            editUserNameInput: '',
            editMessageInput: '',
            editPipeTagInput: '',
        };
        this.handleDeleteClick = this.handleDeleteClick.bind(this);
        this.handleEditActiveClick = this.handleEditActiveClick.bind(this);
        this.clearStateInputFields = this.clearStateInputFields.bind(this);
        this.handleEditNotActiveClick = this.handleEditNotActiveClick.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleDeleteClick(id) {        
        this.props.deleteChirp(id);
    }

    handleEditActiveClick() {
        this.setState({ editUserNameInput: this.props.userName });
        this.setState({ editMessageInput: this.props.message });
        this.setState({ editPipeTagInput: this.props.pipeTag });
        this.setState({ editActive: true });
    }

    clearStateInputFields() {
        this.setState({ editUserNameInput: '' });
        this.setState({ editMessageInput: '' });
        this.setState({ editPipeTagInput: '' });
    }

    handleEditNotActiveClick() {
        this.clearStateInputFields();
        this.setState({ editActive: false });
    }

    handleChange(event) {
        // Input field name and state is named the same.
        // Makes connection to state automatic using event.target.name
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit(event, id) {
        event.preventDefault();
        this.props.editChirp(id, this.state.editUserNameInput, this.state.editMessageInput, this.state.editPipeTagInput);
        this.clearStateInputFields();
        this.setState({ editActive: false });
    }

    render() {

        let editForm;
        if (this.state.editActive) {
            editForm =
                <div>
                    <h3> Editera chirp </h3>
                    <form>
                        <div className="form-group">
                            <label className="label">Anv&auml;ndarnamn</label>
                            <input
                                type="text"
                                name="editUserNameInput"
                                className="form-control"
                                id="editUserNameInput"
                                value={this.state.editUserNameInput}
                                onChange={this.handleChange}
                            ></input>

                        </div>
                        <div className="form-group">
                            <label className="label">Meddelande</label>
                            <input
                                type="text"
                                name="editMessageInput"
                                className="form-control"
                                id="editMessageInput"
                                value={this.state.editMessageInput}
                                onChange={this.handleChange}
                            ></input>
                        </div>
                        <div className="form-group">
                            <label className="label">|Tag</label>
                            <input
                                type="text"
                                name="editPipeTagInput"
                                className="form-control"
                                id="editPipeTagInput"
                                value={this.state.editPipeTagInput}
                                onChange={this.handleChange}
                            ></input>
                        </div>
                    <button type="submit" className="btn btn-secondary mr-4" onClick={(event => this.handleSubmit(event, this.props.id))}>Spara</button>
                    <button type="button" className="btn btn-secondary" onClick={(() => this.handleEditNotActiveClick())}>Avbryt</button>
                    </form>
                </div>
        } else {
            editForm = <div></div>
        }

        return (
            <div className="card text-center mt-4 mb-4">
                <div className="card-header lead">
                    Användare: {this.props.userName}<br />
                    Tid: {this.props.time}<br />                    
                </div>
                <div className="card-body lead">                    
                    <p className="card-text">{this.props.message}</p>
                    <p className="card-text text-info">|<Link to={`/pipetag/${this.props.pipeTag}`}>{this.props.pipeTag}</Link></p>
                </div>
                <div className="card-footer text-muted lead">
                    <span className="badge badge-pill badge-secondary mr-4 chirpButtons" onClick={(() => this.handleEditActiveClick())}>Edit</span>
                    <span className="badge badge-pill badge-danger chirpButtons" onClick={(() => this.handleDeleteClick(this.props.id))}>Delete</span>
                </div>

                {editForm}
            </div>
            
            
            
        );
    }
}