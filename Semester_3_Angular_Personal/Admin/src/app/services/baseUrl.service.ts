import { Injectable } from "@angular/core";

@Injectable()
export class BaseURLService {
    baseURL(): string{
        return "http://localhost:5208/api/";
    }
}