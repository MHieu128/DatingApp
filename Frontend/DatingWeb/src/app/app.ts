import { HttpClient } from '@angular/common/http';
import { Component, signal, inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private http = inject(HttpClient);
  protected readonly title = signal('Dating');
  protected members = signal<any[]>([]);

  ngOnInit() {
    this.http.get<any>('https://localhost:5001/api/members').subscribe({
      next: (response: any) => this.members.set(response),
      error: (error: any) => {
        console.error('Error fetching members:', error);
      },
      complete: () => {
        console.log('Fetching members completed');
      }
    });
  }

}
