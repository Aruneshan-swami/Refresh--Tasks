import { Component } from '@angular/core';
import { HomeComponent } from '../home/home.component';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [HomeComponent],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  display(){
  }
}
