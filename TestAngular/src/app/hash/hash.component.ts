import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-hash',
  templateUrl: './hash.component.html',
  styleUrls: ['./hash.component.css'],
})
export class HashComponent {
  pageTitle: string = 'Hash Generator';
  firstName: string = '';
  hash: string | null = null;

  constructor(private http: HttpClient) {}

  generateHash() {
    console.log('First Name:', this.firstName);
    this.http
      .get<HashResponse>(
        `http://localhost:5000/api/Hash/${this.firstName.toLowerCase()}`
      )
      .subscribe({
        next: (response) => {
          this.hash = response.hash;
        },
        error: (error) => {
          console.error('There was an error!', error);
        },
      });
  }
}

interface HashResponse {
  hash: string;
}
