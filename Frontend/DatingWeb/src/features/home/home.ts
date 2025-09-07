import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  protected registerMode = signal(false);

  toggleRegisterMode() {
    this.registerMode.set(!this.registerMode());
  }
}
