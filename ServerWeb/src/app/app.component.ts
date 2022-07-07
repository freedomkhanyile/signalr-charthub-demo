import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
 import { SignalRService } from './_services/signal-r.service';
import { ChartType, ChartOptions } from 'chart.js';
// import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels: any[] = [['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'];
   public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];
  constructor(
    public signalRService: SignalRService,
    private http: HttpClient
  ) {}
  ngOnInit(): void {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataLister();
    this.getChartsFromApi();
  }
  getChartsFromApi() {
    this.http.get('https://localhost:5001/api/charts').subscribe((data) => {
      console.log(data);
    });
  }
}
