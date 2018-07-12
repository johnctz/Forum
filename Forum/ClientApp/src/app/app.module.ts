import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ForumComponent } from './forum/forum.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbdModalComponent } from './modal/modal.component';
import { FooterComponent } from './footer/footer.component';
import { ModalService } from './modal/modalservice';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RegisterComponent,
    NgbdModalComponent,
    LoginComponent,
    ForumComponent,
    FooterComponent,
    ModalService

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: ForumComponent, pathMatch: 'full' },
      
    ])
  ],
  entryComponents: [LoginComponent, RegisterComponent],
  providers: [ModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
