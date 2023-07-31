import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; //Prime NG

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { IndexComponent } from './components/admin/index/index.component';
import { ButtonModule } from 'primeng/button';
import { CreateComponent } from './components/admin/create/create.component';
import { EditComponent } from './components/admin/edit/edit.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AccountService } from './services/account.service';
import { BaseURLService } from './services/baseUrl.service';
import { HttpClientModule } from '@angular/common/http';
import { SelectButtonModule } from 'primeng/selectbutton';
import { FileUploadModule } from 'primeng/fileupload';
import { Index2Component } from './components/product/index/index.component';
import { Edit2Component } from './components/product/edit/edit.component';
import { Create2Component } from './components/product/create/create.component';
import { ProductService } from './services/product.service';
import { CategoryService } from './services/category.service';
import { EditorModule } from 'primeng/editor';
import { Index3Component } from './components/order/index.component';
import { OrderService } from './services/order.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent,
    IndexComponent,
    CreateComponent,
    EditComponent,
    LoginComponent,
    Index2Component,
    Create2Component,
    Edit2Component,
    Index3Component

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    TableModule,
    InputTextModule,
    ButtonModule,
    SelectButtonModule,
    FileUploadModule,
    EditorModule
  ],
  providers: [
    AccountService,
    BaseURLService,
    ProductService,
    CategoryService,
    OrderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
