import { Injectable } from "@angular/core";
import { BaseURLService } from "./baseUrl.service";
import { HttpClient } from "@angular/common/http";
import { Login } from "../models/login.model";
import { lastValueFrom } from "rxjs";
import { Account } from "../models/account.model";

@Injectable()
export class AccountService {
    constructor(
        private baseURlService: BaseURLService,
        private httpClient: HttpClient,
    ){}

    async login(login: Login){
        return await lastValueFrom(this.httpClient.post(this.baseURlService.baseURL() + 'admin/account/login2', login));
    }

    async findByEmail(email: string){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/account/findByEmail/' + email));
    }

    async create(account: Account) {
        return await lastValueFrom(this.httpClient.post(this.baseURlService.baseURL() + 'admin/account/register', account));
    }

    async find(id: string) {
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/account/find/' + id));
    }
}