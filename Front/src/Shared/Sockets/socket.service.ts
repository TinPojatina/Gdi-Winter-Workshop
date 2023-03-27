import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as signalR from '@microsoft/signalr'
import { ISocketNotifyMessage } from '../Models/ISocketNotifyMessage';

const apiUrl = environment.apiEndpoint;

@Injectable({
  providedIn: 'root'
})
export class SocketService {
  private hubConnection!: signalR.HubConnection;

  connectionAttempts: number = 0;
  isConnected = false;

  constructor() { }

  public buildConnection(): void{
    if(this.isConnected == false){
      this.hubConnection = new signalR.HubConnectionBuilder().withUrl(`${apiUrl}appHub`).build();

      this.startConnection();

      this.hubConnection.on('camundaMessageHub', (data: ISocketNotifyMessage) =>{
        console.log(`socket message has been received: ${JSON.stringify(data)}`)
        alert(`socket message has been received: ${JSON.stringify(data)}`)
      })
    }
  }

  public startConnection(){
    this.connectionAttempts++;
    this.hubConnection
    .start()
    .then(() => {
      this.connectionAttempts = 0;
      this.isConnected = true;
      console.log("socket connection started");
    })
    .catch(err => {
      console.log(`socket error while establishing connection`);
      setTimeout(() => {
        this.startConnection();
      }, 5000);
    });
  }
}
