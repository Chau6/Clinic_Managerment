import { Component, OnInit } from "@angular/core";
import { Product } from "src/app/models/product.model";
import { ProductService } from "src/app/services/product.service";

@Component({
    templateUrl: './index.component.html',
})
export class Index2Component implements OnInit {
    products: Product[];
    selectedProduct: Product;

    constructor(
        private productService: ProductService,
    ) {}

    ngOnInit(): void {
        this.productService.findAll().then(
            result => {
                console.log(result);
                this.products = result as Product[];
            },
            error => {
                console.log(error);
            }
        );
    }
}