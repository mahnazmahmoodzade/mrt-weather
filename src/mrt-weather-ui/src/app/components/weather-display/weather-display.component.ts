import { Component, input } from '@angular/core';
import { Weather } from '../../models/weather.model';
import { DatePipe, TitleCasePipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-weather-display',
  standalone: true,
  imports: [DatePipe,TitleCasePipe,MatCardModule, MatIconModule],
  templateUrl: './weather-display.component.html',
  styleUrl: './weather-display.component.scss'
})
export class WeatherDisplayComponent {
  weather = input.required<Weather>();
  unit = input.required<'C' | 'F'>();
  showSunrise = input.required<boolean>();

  getIconUrl(iconCode: string): string {
    return `https://openweathermap.org/img/wn/${iconCode}@2x.png`;
  }
}
