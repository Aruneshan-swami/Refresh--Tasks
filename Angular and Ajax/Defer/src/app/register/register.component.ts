import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HomeComponent } from '../home/home.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule,HomeComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerationForm!: FormGroup;
  constructor (private formBuilder:FormBuilder){
    this.CreateForm();
  }
  CreateForm(){
    this.registerationForm = this.formBuilder.group({
    userName : ['',Validators.required],
    Email : ['',Validators.email],
    Password : ['',Validators.minLength(8)]
  });
  }
OnSubmit(){
  console.log("Registration is complete",this.registerationForm.value);
}
}
