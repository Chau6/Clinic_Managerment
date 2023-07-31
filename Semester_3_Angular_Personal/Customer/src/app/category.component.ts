import { Component, OnInit } from '@angular/core';
import { Category } from './models/category.model';
import { CategoryService } from './services/category.service';

@Component({
  selector: 'categories',
  templateUrl: './category.component.html',
})
export class CategoryComponent implements OnInit {
  categories: Category[];

  constructor(
    private categoryService: CategoryService
  ){}

  ngOnInit() {
    this.categoryService.findAll().then(
      (result) => {
        console.log(result);
        this.categories = result as Category[];
      },
      (error) => {
        console.log(error);
      }
    );
  }
}