import { Component, OnInit, effect, inject } from '@angular/core';
import { WeatherService } from './services/weather.service';
import { UnitService } from './services/unit.service';
import { UnitToggleComponent } from './components/unit-toggle/unit-toggle.component';
import { WeatherDisplayComponent } from './components/weather-display/weather-display.component';
import { SunriseSunsetToggleComponent } from './components/sunrise-sunset-toggle/sunrise-sunset-toggle.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    UnitToggleComponent,
    WeatherDisplayComponent,
    SunriseSunsetToggleComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  weatherService = inject(WeatherService);
  unitService = inject(UnitService);
  showSunrise = true;

  private unitEffect = effect(() => {
    const unit = this.unitService.currentUnit();
    this.weatherService.setTemperatureUnit(unit).subscribe(() => {
      this.weatherService.getWeatherData().subscribe();
    });
  });
  
  ngOnInit() {
    this.weatherService.getWeatherData().subscribe();
  }

  toggleSunriseSunset() {
    this.showSunrise = !this.showSunrise;
  }
}