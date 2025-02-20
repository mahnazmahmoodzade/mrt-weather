import { Component,inject } from '@angular/core';
import { TemperatureUnit } from '../../models/temperature-unit.enum';
import { UnitService } from '../../services/unit.service';
import { MatButtonToggleModule } from '@angular/material/button-toggle';

@Component({
  selector: 'app-unit-toggle',
  imports: [MatButtonToggleModule],
  standalone: true,
  templateUrl: './unit-toggle.component.html',
  styleUrl: './unit-toggle.component.scss'
})
export class UnitToggleComponent {
  
  private unitService = inject(UnitService);
  currentUnit = this.unitService.currentUnit;
  TemperatureUnit = TemperatureUnit; // Expose enum to template

  toggleUnit(newUnit: TemperatureUnit) {
    this.unitService.setUnit(newUnit);
  }
}
