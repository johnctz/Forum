import { Component, OnInit, ViewChild } from '@angular/core';

import { NgbModal, NgbActiveModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { RegisterComponent } from '../register/register.component';
//import { ModalService } from '../modal/modalservice';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private modalService: NgbModal) { }
  //constructor(private modalService: ModalService) { }
  
  ngOnInit() {
    this.loadScript("../assets/js/bootstrap-validate.js");
  }

  register() {
    //this.modalService.closeModal();
    //this.modalService.register();
    const modalRef = this.modalService.open(RegisterComponent);
    modalRef.componentInstance.name = 'register';
  }

  public loadScript(url: string) {
    const body = <HTMLDivElement>document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }

}
