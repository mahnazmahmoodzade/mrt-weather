import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-sunrise-sunset-toggle',
  imports: [MatButtonModule, MatIconModule],
  standalone: true,
  templateUrl: './sunrise-sunset-toggle.component.html',
  styleUrl: './sunrise-sunset-toggle.component.scss'
})
export class SunriseSunsetToggleComponent {
  @Input() showSunrise!: boolean;
  @Output() toggle = new EventEmitter<void>();

  onToggle() {
    this.toggle.emit();
  }
}
