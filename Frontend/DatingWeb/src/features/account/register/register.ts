import { Component, input } from '@angular/core';
import { RegisterCreds, User } from '../../../types/user';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  membersFromHome = input.required<User[]>();
  protected creds = {} as RegisterCreds;

  register() {
    console.log('Registering user with credentials:', this.creds);
    // Implement registration logic here, e.g., call a service to register the user
  }


  cancel() {
    console.log('Registration cancelled');
    // Implement cancellation logic here, e.g., navigate back to the home page
  }
}
