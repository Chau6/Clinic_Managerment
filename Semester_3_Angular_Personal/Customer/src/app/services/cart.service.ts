import { Injectable } from "@angular/core";
import { BaseURLService } from "./baseUrl.service";
import { HttpClient } from "@angular/common/http";
import { lastValueFrom } from "rxjs";
import { Cart } from "../models/cart.model";

@Injectable()
export class CartService {
    constructor(
        private baseURlService: BaseURLService,
        private httpClient: HttpClient,
    ){}

    async find(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'cart/find/' + id));
    }

    async findByCartId(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'cart/findByCartId/' + id));
    }

    async addQuantity(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'cart/addQuantity/' + id));
    }

    async subQuantity(id: number){
        return await lastValueFrom(this.httpClient.get(this.baseURlService.baseURL() + 'cart/subQuantity/' + id));
    }

    async create(cart: Cart) {
        return await lastValueFrom(this.httpClient.post(this.baseURlService.baseURL() + 'cart/create', cart));
    }

    async edit(cart: Cart){
        return await lastValueFrom(this.httpClient.put(this.baseURlService.baseURL() + 'cart/edit', cart));
    }

    async delete(id: number){
        return await lastValueFrom(this.httpClient.delete(this.baseURlService.baseURL() + 'cart/delete/' + id));
    }
}