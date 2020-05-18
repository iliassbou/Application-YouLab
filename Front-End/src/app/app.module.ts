import { from } from 'rxjs';
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./component/login/login.component";
import { NavComponent } from "./component/nav/nav.component";
import { ContentComponent } from "./component/content/content.component";
import { AddpatientComponent } from "./component/patient/addpatient/addpatient.component";
import { ListpatientComponent } from "./component/patient/listpatient/listpatient.component";
import { UserinfoComponent } from "./component/userinfo/userinfo.component";

import { HttpClientModule } from "@angular/common/http";
import { PatientService } from "./service/patient.service";
import { SidebarComponent } from './component/sidebar/sidebar.component';
import { ListSecretaireComponent } from './component/Secretaire/list-secretaire/list-secretaire.component';
import { ListeDocteurComponent } from './component/Docteur/listeDocteur/listeDocteur.component';
import { AddDocteurComponent } from './component/Docteur/addDocteur/addDocteur.component';
import { AddLaborantinComponent } from './component/Laborantins/add-laborantin/add-laborantin.component';
import { ListeLaborantinsComponent } from './component/Laborantins/liste-laborantins/liste-laborantins.component';
import { AdminPanelComponent } from './component/dashbord/admin-panel/admin-panel.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DataTablesModule } from 'angular-datatables';
import { AddSeretairesComponent } from './component/Secretaire/add-seretaires/add-seretaires.component';
import { UserInfoComponent } from './component/Docteur/user-info/user-info.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavComponent,
    ContentComponent,
    AddpatientComponent,
    ListpatientComponent,
    UserinfoComponent,
    SidebarComponent,
    ListSecretaireComponent,
    ListeDocteurComponent,
    AddDocteurComponent,
    AddLaborantinComponent,
    ListeLaborantinsComponent,
    AdminPanelComponent,
    AddSeretairesComponent,
    UserInfoComponent
  ],
  imports: [
    BrowserModule, AppRoutingModule, HttpClientModule, FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    DataTablesModule
  ],
  providers: [PatientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
