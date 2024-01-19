import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  constructor(private router:Router){}

  navigateToLogin():void{
    this.router.navigate(['/nav']);
  }
  navigateToHome():void{
    this.router.navigate(['/root']);
  }
  navigateToRegister(){
    this.router.navigate(['/register']);
  }


}
