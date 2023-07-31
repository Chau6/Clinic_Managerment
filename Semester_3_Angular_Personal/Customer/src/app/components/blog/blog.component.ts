import { Component, OnInit } from '@angular/core';
import { Blog } from 'src/app/models/blog.model';
import { BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-root',
  templateUrl: './blog.component.html',
})
export class BlogComponent implements OnInit {
  blogs: Blog[];

  constructor(
    private blogService: BlogService,

  ){}

  ngOnInit() {
      this.blogService.findAll().then(
      (result) => {
        console.log(result);
        this.blogs = result as Blog[];
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
