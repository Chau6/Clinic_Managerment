import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "src/app/models/product.model";
import { ProductService } from "src/app/services/product.service";

@Component({
    templateUrl: './create.component.html',
})
export class Create2Component implements OnInit {
    addProductForm: FormGroup;

    constructor(
        private productService: ProductService,
        private formBuilder: FormBuilder,
        private router: Router
    ){}

    ngOnInit(): void {
        this.addProductForm = this.formBuilder.group({
            productName: ['', Validators.required],
            image: 'no_image.jpg',
            price: ['', Validators.required],
            categoryId: 1,
            description: ['', Validators.required],
            quantity: ['', Validators.required],
            detail: ['', Validators.required],
            expireDate: '',
            manufacturerId: 1,
            hide: false
        });
    }

    save(){
        var product: Product = this.addProductForm.value as Product;
        console.log(product);
        this.productService.create(product).then(
            result => {
                console.log(result);
                if(result){
                    this.router.navigate(['/dashboard/index2']);
                }
            },
            error => {
                console.log(error);
            }
        )
    }
}