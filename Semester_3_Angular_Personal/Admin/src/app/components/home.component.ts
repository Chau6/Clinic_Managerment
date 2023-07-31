import { Component, OnInit } from "@angular/core";
import { Account } from "../models/account.model";
import { AccountService } from "../services/account.service";
import { Router } from "@angular/router";

@Component({
    selector: 'app-root',
    templateUrl: './home.component.html'
  })
  export class HomeComponent implements OnInit {
    account: Account;
    userEmail: string;

    constructor(
      private accountService: AccountService,
      private router: Router
  ) {}

  ngOnInit(): void {
    this.userEmail = localStorage.getItem('email');
    this.accountService.findByEmail(this.userEmail).then(
      result => {
        this.account = result as Account;
      },
      error => {
          console.log(error);
      }
    );
  }

  logout(){
    localStorage.removeItem('email');
    this.router.navigate(['/login']);
  }
}