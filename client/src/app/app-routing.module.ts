import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { UsersComponent } from './components/users/users.component';

const routes: Routes = [
  { path: '', component: MainComponent,
  children: [
    { path: 'users', component: UsersComponent },
    { path: '', component: UsersComponent },
  ]}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
