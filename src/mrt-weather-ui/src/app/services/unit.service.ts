import { Injectable, signal } from '@angular/core';
import { TemperatureUnit } from '../models/temperature-unit.enum';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  private _unit = signal<TemperatureUnit>(TemperatureUnit.Metric);
  currentUnit = this._unit.asReadonly();

  setUnit(unit:TemperatureUnit) {
    this._unit.set(unit);
  }
}
