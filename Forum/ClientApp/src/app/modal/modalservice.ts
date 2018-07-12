import { Component, Input, ViewChild } from '@angular/core';

import { NgbModal, NgbActiveModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';


@Component({
  selector: 'ngbd-modal-service',
  templateUrl: './modal.component.html',
  //styleUrls: ['./modal.component.css']

})


export class ModalService {

  constructor(private modalService: NgbModal) { }

  public mr: NgbModalRef;

  public register() {
    this.mr = this.modalService.open(RegisterComponent);
    this.mr.componentInstance.name = 'register';
  }

  public login() {
    this.mr = this.modalService.open(LoginComponent);
    this.mr.componentInstance.name = 'login';
  }

  public closeModal() {
    this.mr.close();
  }

}
