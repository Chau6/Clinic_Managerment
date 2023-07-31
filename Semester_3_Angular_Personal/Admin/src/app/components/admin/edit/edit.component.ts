import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Account } from "src/app/models/account.model";
import { AccountService } from "src/app/services/account.service";

@Component({
    templateUrl: './edit.component.html',
})
export class EditComponent implements OnInit {
    editAccountForm: FormGroup;
    genderOptions: string[] = ['Male', 'Female', 'Other'];
    roleOptions: any[] = [
        { roleId: '1', value: 'Super Admin' },
        { roleId: '2', value: 'Admin' },
        { roleId: '3', value: 'User' },
    ];
    id: string;
    selectedFile: File;
    userEmail: string;
    admin: Account;

    constructor(
        private accountService: AccountService,
        private formBuilder: FormBuilder,
        private router: Router,
        private activatedRoute: ActivatedRoute,
    ){}
    ngOnInit(): void {
        this.userEmail = localStorage.getItem('email');
        this.activatedRoute.paramMap.subscribe(p => {
            this.id = p.get('id');
            this.accountService.find(this.id).then(
                result => {
                    var account = result as Account;
                    // console.log(account);
                    this.editAccountForm = this.formBuilder.group({ //khởi tạo đối tượng
                        firstName: account.firstname,
                        lastName: account.lastname,
                        email: account.email,
                        phone: account.phoneNumber,
                        gender: account.gender,
                        roleId: account.roleId.toString(),
                        avatar: account.avatar,
                        status: account.status,
                        password: account.password,
                        securityCode: account.securityCode,
                        createdAt: account.createdAt
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

    onGenderCheckboxChange(option: string) {
        this.gender.setValue(option);
    }

    get gender() {
        return this.editAccountForm.get('gender') as FormControl;
    }

    save(){
        var account: Account = this.editAccountForm.value as Account;
        account.accountId = parseInt(this.id);
        // console.log(account);
        this.accountService.find(this.id).then( //của đối tượng
            result => {
                var accountEdit = result as Account;
                this.accountService.findByEmail(this.userEmail).then(
                    result => {
                        this.admin = result as Account; //của tài khoản admin

                        // console.log(this.account);
                        // console.log(accountEdit);
                        
                        if(this.admin.roleId <= accountEdit.roleId){ //role 1 = 1 và 1 < 2
                            if(this.admin.accountId == accountEdit.accountId){ //1 == 1
                                if(account.roleId >= this.admin.roleId){ //vượt quyền
                                    this.accountService.edit(account).then(
                                        result => {
                                            if(result){
                                                this.router.navigate(['/dashboard/index']);
                                            }
                                        },
                                        error => { 
                                            console.log(error);
                                        }
                                    )
                                }else{
                                    alert("You do not have permission to modify this object.");
                                    this.router.navigate(['/dashboard/index']);
                                }
                            }else if(this.admin.roleId < accountEdit.roleId){ // 1 < 2
                                if(account.roleId >= this.admin.roleId){
                                    this.accountService.edit(account).then(
                                        result => {
                                            if(result){
                                                this.router.navigate(['/dashboard/index']);
                                            }
                                        },
                                        error => { 
                                            console.log(error);
                                        }
                                    )
                                }else{
                                    alert("You do not have permission to modify this object.");
                                    this.router.navigate(['/dashboard/index']);
                                }
                            }else{
                                alert("You do not have permission to modify this object.");
                                this.router.navigate(['/dashboard/index']);
                            }
                        }else{
                            alert("You do not have permission to modify this object.");
                            this.router.navigate(['/dashboard/index']);
                        }
                    },
                    error => {
                        console.log(error);
                    }
                  );
            },
            error => {
                console.log(error);
            }
        )
    }
    

    upload(){
        console.log(this.id);
        console.log(this.selectedFile);
        this.accountService.upload(this.id, this.selectedFile).then(
            result => {
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