import { Component, Input, ViewChild } from '@angular/core';

import { NgbModal, NgbActiveModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { ModalService } from '../modal/modalservice';



@Component({
  selector: 'ngbd-modal-component',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']

})

export class NgbdModalComponent {

  constructor(private modalService: ModalService) { }

  register() {
    this.modalService.register();
  }
  
  login() {
    this.modalService.login();
  }
  //public mr: NgbModalRef;


  //register() {
  //  this.mr = this.modalService.open(RegisterComponent);
  //  this.mr.componentInstance.name = 'register';
  //}

  //login() {
  //  this.mr = this.modalService.open(LoginComponent);
  //  this.mr.componentInstance.name = 'login';
  //}

  //public closeModal() {
  //  this.mr.close();
  //}
}
