import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { ChartModel } from '../_models';
@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  public data: ChartModel[] = [];

  private hubConnection: signalR.HubConnection;

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/chart')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('INF: Connection started'))
      .catch((err) => console.log('ERR: Connection failed to start: ' + err));
  }

  public addTransferChartDataLister() {
    this.hubConnection.on('clientPolicyCallbackChartData', (data) => {
      this.data = data;
      console.log(data);
    });
  }


}
