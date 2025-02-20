import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { Weather } from '../models/weather.model';
import { TemperatureUnit } from '../models/temperature-unit.enum';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/weathers`;
  private _weatherData = signal<Weather[]>([]);

  weatherData = this._weatherData.asReadonly();

  getWeatherData(): Observable<Weather[]> {
    return this.http.get<Weather[]>(`${this.apiUrl}/get-weather-data`).pipe(
      tap(data => this._weatherData.set(data))
    );
  }

  setTemperatureUnit(unit: TemperatureUnit): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/set-temperature-unit`, { unit });
  }
}
