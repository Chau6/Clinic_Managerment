import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from 'src/app/models/account.model';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './register.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class RegisterComponent implements OnInit {
  addAccountForm: FormGroup;
  genderOptions: string[] = ['Male', 'Female', 'Other'];

  constructor(
    private accountService: AccountService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.addAccountForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      phone: ['', Validators.required],
      gender: ['Male', Validators.required],
      roleId: '3',
    });
  }

  onGenderCheckboxChange(option: string) {
    this.gender.setValue(option);
  }

  get gender() {
    return this.addAccountForm.get('gender') as FormControl;
  }

  save() {
    var account: Account = this.addAccountForm.value as Account;
    account.avatar = 'no_image.jpg';
    console.log(account);
    this.accountService.create(account).then(
      (result) => {
        console.log(result);
        if (result) {
          alert('Success');
          this.router.navigate(['/my_account']);
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
