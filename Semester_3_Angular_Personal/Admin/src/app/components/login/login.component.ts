import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  email: string;
  password: string;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private accountService: AccountService
  ) {}
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: this.email,
      password: this.password,
    });
  }
  save() {
    var login: Login = this.loginForm.value as Login;
    console.log(login);
    this.accountService.login(login).then(
      (result) => {
        if (result) {
          localStorage.setItem('email', login.email);
          this.router.navigate(['/dashboard']);
        } else {
          alert('Login Failed !!!');
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
