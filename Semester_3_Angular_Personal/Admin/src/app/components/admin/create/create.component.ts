import { Component, OnInit } from "@angular/core";
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { Account } from "src/app/models/account.model";
import { AccountService } from "src/app/services/account.service";

@Component({
    templateUrl: './create.component.html',
})
export class CreateComponent implements OnInit {
    addAccountForm: FormGroup;
    genderOptions: string[] = ['Male', 'Female', 'Other'];
    roleOptions: any[] = [
        { roleId: '1', value: 'Super Admin' },
        { roleId: '2', value: 'Admin' },
        { roleId: '3', value: 'User' },
    ];

    constructor(
        private accountService: AccountService,
        private formBuilder: FormBuilder,
        private router: Router
    ){}

    ngOnInit(): void {
        
        this.addAccountForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', Validators.required],
            password: ['', Validators.required],
            phone: ['', Validators.required],
            gender: ['Male', Validators.required],
            roleId: ['3', Validators.required]
        });
    }

    onGenderCheckboxChange(option: string) {
        this.gender.setValue(option);
    }

    get gender() {
        return this.addAccountForm.get('gender') as FormControl;
    }

    save(){
        var account: Account = this.addAccountForm.value as Account;
        account.avatar = 'no_image.jpg';
        console.log(account);
        this.accountService.create(account).then(
            result => {
                console.log(result);
                if(result){
                    this.router.navigate(['/dashboard/index']);
                }
            },
            error => {
                console.log(error);
            }
        )
    }
}