import { HttpClient } from '@angular/common/http';
import { Component, signal, inject, OnInit } from '@angular/core';
import { Nav } from "../layout/nav/nav";
import { AccountService } from '../core/services/account-service';
import { User } from '../types/user';
import { Router, RouterOutlet } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [Nav, RouterOutlet, NgClass],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private accountService = inject(AccountService);
  private http = inject(HttpClient);
  protected readonly title = signal('Dating');
  protected members = signal<User[]>([]);
  protected router = inject(Router);

  ngOnInit() {
    this.loadMembers();
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userJson = localStorage.getItem('user');
    if (!userJson) return;
    const user = JSON.parse(userJson);
    this.accountService.currentUser.set(user);
  }

  loadMembers() {
    this.http.get<User[]>('https://localhost:5001/api/members').subscribe({
      next: (response) => this.members.set(response),
      error: (error) => {
        console.error('Error fetching members:', error);
      },
      complete: () => {
        console.log('Fetching members completed');
      }
    });
  }
}
