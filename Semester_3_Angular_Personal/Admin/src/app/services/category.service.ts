import { Injectable } from "@angular/core";
import { BaseURLService } from "./baseUrl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class CategoryService {
    constructor(
        private baseURlService: BaseURLService,
        private httpClient: HttpClient,
    ){}

    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/category/findAll'));
    }
}