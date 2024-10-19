import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'clientApp';

  constructor(private http: HttpClient) {
    this.http.get<WeatherForCast>('weatherforecast')
      .subscribe((res) => {
        console.log(res);
      })
  }
}

export interface WeatherForCast {
  date: string,
  summary: string,
  temperatureC: number,
  // temperatureF: number
}
