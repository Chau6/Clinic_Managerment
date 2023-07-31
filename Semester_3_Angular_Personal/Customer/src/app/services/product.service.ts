import { Injectable } from "@angular/core";
import { BaseURLService } from "./baseUrl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";

@Injectable()
export class ProductService {
    constructor(
        private baseURlService: BaseURLService,
        private httpClient: HttpClient,
    ){}

    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/findAll2'));
    }

    async findTwo(){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/findTwo'));
    }

    async findThree(){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/findThree'));
    }

    async find(id: string) {
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/find/' + id));
    }
}