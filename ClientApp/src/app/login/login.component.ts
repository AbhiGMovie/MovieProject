import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})

export class loginComponent {
  public username: string = "";
  public password: string = "";
  public user: Users = { Id: 0, userName: "", password: "" };
  public loginuser: Users;
  httpclient: HttpClient;
  baseUrls: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.httpclient = http;
    this.baseUrls = baseUrl;
  }
  public Login() {
    this.user.userName = this.username;
    this.user.password = this.password;
    this.httpclient.post<Users>(this.baseUrls + 'api/user/login', { Id:this.user.Id, userName:this.username,password:this.password}).subscribe({
      next: data => {
        this.loginuser = data;
        alert("Login Successful");
        this.router.navigate(['/']);
      },
      error: error => {
        console.error('There was an error!', error);
        alert("Login UnSuccessful");
      }
    })

    

  }
}

interface Users {
  Id: number;
  userName: string;
  password: string;
}
