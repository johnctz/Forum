import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { NgbModal, NgbActiveModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  email: string = "";
  password: string = "";
  confirmPassword: string = ""
  firstName: string = "";
  lastName: string = "";
  passwordMatched: boolean = false;

  serverResponse: boolean = false;
  serverResponseDescription: string = "";

  public mrRegister: NgbModalRef;


  constructor(private httpClient: HttpClient, private modalService: NgbModal) {  }



  ngOnInit() {
    this.loadScript("../assets/js/bootstrap-validate.js");
  }

  registerAccount() {
    this.matchPassword();
    if (this.passwordMatched == false) {
      this.serverResponseDescription = "Passwords do not match.";
      this.serverResponse = true;
      return;
    }


    this.httpClient.post('/api/accounts',
      {
        email: this.email,
        password: this.password,
        firstName: this.firstName,
        lastName: this.lastName
      },
      {
        observe: 'response'
      })
      .subscribe(response => {
        console.log(response);

        this.mrRegister = this.modalService.open(RegisterComponent);
        this.mrRegister.componentInstance.name = 'registerSuccess';

        return response;
      }, err => {
        this.serverResponseDescription = err.error.modelError;
        this.serverResponse = true;
      });
  }

  onPasswordKeyUp(event: any) {
    this.matchPassword();
  }

  matchPassword() {
    if (this.password == this.confirmPassword) {
      this.passwordMatched = true;
      return;
    }
    this.passwordMatched = false;
    return;
  }

  loadScript(url: string) {
    const body = <HTMLDivElement>document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }

}
