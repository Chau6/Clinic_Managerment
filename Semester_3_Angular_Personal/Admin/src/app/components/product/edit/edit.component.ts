import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from "src/app/models/product.model";
import { ProductService } from "src/app/services/product.service";

@Component({
    templateUrl: './edit.component.html',
})
export class Edit2Component implements OnInit {
    editProductForm: FormGroup;
    id: string;
    selectedFile: File;

    constructor(
        private productService: ProductService,
        private formBuilder: FormBuilder,
        private router: Router,
        private activatedRoute: ActivatedRoute,
    ){}
    ngOnInit(): void {
        this.activatedRoute.paramMap.subscribe(p => {
            this.id = p.get('id');
            this.productService.find2(this.id).then(
                result => {
                    var product = result as Product;
                    this.editProductForm = this.formBuilder.group({ //khởi tạo đối tượng
                        productName: product.productName,
                        image: product.image,
                        price: product.price,
                        categoryId: product.categoryId,
                        description: product.description,
                        quantity: product.quantity,
                        detail: product.detail,
                        expireDate: product.expireDate,
                        manufacturerId: product.manufacturerId,
                        hide: product.hide,
                        createdAt: product.createdAt
                    });
                },
                error => {
                    console.log(error);
                }
            )}
        )
    }

    selectFile(evt: any){
        this.selectedFile = evt[0];
    }

    upload(){
        this.productService.upload(this.id, this.selectedFile).then(
            result => {
                if(result){
                    this.router.navigate(['/dashboard/index2']);
                } 
            },
            error => {
                console.log(error);
            }
        )
    }

    save(){
        var product: Product = this.editProductForm.value as Product;
        product.productId = parseInt(this.id);
        // console.log(account);
        this.productService.edit(product).then(
            result => {
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