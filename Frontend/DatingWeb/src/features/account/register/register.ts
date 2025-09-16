import { Component, inject, input, output } from '@angular/core';
import { RegisterCreds, User } from '../../../types/user';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../../core/services/account-service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  private accountService = inject(AccountService); 
  cancelRegister = output<boolean>();
  protected creds = {} as RegisterCreds;

  register() {
    console.log('Registering user with credentials:', this.creds);
    this.accountService.register(this.creds).subscribe({
      next: (user) => {
        console.log('User registered successfully:', user);
        this.cancel();
      },
      error: (error) => {
        console.error('Error registering user:', error);
      }
    });
  }
  
  cancel() {
    this.cancelRegister.emit(false);
  }
}
