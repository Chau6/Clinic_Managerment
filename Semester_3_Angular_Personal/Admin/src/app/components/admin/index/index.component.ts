import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Account } from "src/app/models/account.model";
import { AccountService } from "src/app/services/account.service";

@Component({
    templateUrl: './index.component.html',
})
export class IndexComponent implements OnInit {
    accounts: Account[];
    selectedAccount: Account;

    constructor(
        private accountService: AccountService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.accountService.findAll().then(
            result => {
                console.log(result);
                this.accounts = result as Account[];
            },
            error => {
                console.log(error);
            }
        );
    }
}