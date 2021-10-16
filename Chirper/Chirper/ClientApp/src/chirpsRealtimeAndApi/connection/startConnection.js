import * as signalR from "@microsoft/signalr/dist/browser/signalr.js";
import axios from "axios";

export async function startRealtimeConnection() {
    
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chirpHub")
        .configureLogging(signalR.LogLevel.Trace)
        .withAutomaticReconnect()
        .build();

    connection.on("RecieveAllChirps", (allChirps) => {
        console.log("In connection on");
        console.log("All chirps " + JSON.stringify(allChirps));
    });    

    connection
        .start()
        .then(() => {
            console.log(connection.connectionState);
        })
        .catch((err) => console.error(err));

    //connection.onclose(console.log("connection closed"));
}