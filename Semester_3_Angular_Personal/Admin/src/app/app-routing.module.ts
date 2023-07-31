import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { IndexComponent } from './components/admin/index/index.component';
import { CreateComponent } from './components/admin/create/create.component';
import { EditComponent } from './components/admin/edit/edit.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home.component';
import { Index2Component } from './components/product/index/index.component';
import { Create2Component } from './components/product/create/create.component';
import { Edit2Component } from './components/product/edit/edit.component';
import { Index3Component } from './components/order/index.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'login', component: LoginComponent},
  {path: 'dashboard', component: HomeComponent, children: [
    {path: '', component: DashboardComponent},
    {path: 'home', component: DashboardComponent},
    {path: 'index', component: IndexComponent},
    {path: 'create', component: CreateComponent},
    {path: 'edit', component: EditComponent},
    {path: 'index2', component: Index2Component},
    {path: 'create2', component: Create2Component},
    {path: 'edit2', component: Edit2Component},
    {path: 'index3', component: Index3Component},
  ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
