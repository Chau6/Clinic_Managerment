import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  email: string;
  ngOnInit() {
      this.email = localStorage.getItem('email');
  }

  logout() {
    localStorage.removeItem('email');
    alert("Logout Successfully! Please log in to access full functionality.");
    window.location.reload();
  }
}
