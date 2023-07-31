import { Injectable } from "@angular/core";
import { BaseURLService } from "./baseUrl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { Product } from "../models/product.model";

@Injectable()
export class ProductService {
    constructor(
        private baseURlService: BaseURLService,
        private httpClient: HttpClient,
    ){}

    async findAll(){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/findAll'));
    }

    async find(id: string) {
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/find/' + id));
    }

    async find2(id: string) {
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'admin/product/find2/' + id));
    }

    async create(product: Product) {
        return await lastValueFrom(this.httpClient.post(this.baseURlService.baseURL() + 'admin/product/create', product));
    }

    async edit(product: Product){
        return await lastValueFrom(this.httpClient.put(this.baseURlService.baseURL() + 'admin/product/edit', product));
    }

    async upload(id: string, file: File) {
        var formData = new FormData();
        formData.append('file', file);
        return await lastValueFrom(this.httpClient.post(this.baseURlService.baseURL() + 'admin/product/uploadFile/' + id, formData));
    }
}