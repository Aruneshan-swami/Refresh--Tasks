import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {path:'',redirectTo:'home',pathMatch:'full'},
    {path:'home',component:HomeComponent},
    {path:'nav',component:NavComponent},
    {path:'register',component:RegisterComponent}
];
