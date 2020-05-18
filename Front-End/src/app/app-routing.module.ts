import { AddSeretairesComponent } from './component/Secretaire/add-seretaires/add-seretaires.component';
import { ListSecretaireComponent } from './component/Secretaire/list-secretaire/list-secretaire.component';
import { AddLaborantinComponent } from './component/Laborantins/add-laborantin/add-laborantin.component';
import { ListeLaborantinsComponent } from './component/Laborantins/liste-laborantins/liste-laborantins.component';
import { Patient } from 'shared/patient';
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { from } from "rxjs";
import { LoginComponent } from "./component/login/login.component";
import { ListpatientComponent } from "./component/patient/listpatient/listpatient.component";
import { ListeDocteurComponent } from "./component/Docteur/listeDocteur/listeDocteur.component";
import { AddDocteurComponent } from "./component/Docteur/addDocteur/addDocteur.component";
import { AddpatientComponent } from "./component/patient/addpatient/addpatient.component";
import { ContentComponent } from "./component/content/content.component";
import { UserinfoComponent } from "./component/userinfo/userinfo.component";
import { AdminPanelComponent } from './component/dashbord/admin-panel/admin-panel.component';
import { UserInfoComponent } from './component/Docteur/user-info/user-info.component';


const routes: Routes = [
  { path: "", component: AdminPanelComponent },
  { path: "Login", component: LoginComponent },
  { path: "ListPatient", component: ListpatientComponent },
  { path: "AddPatient", component: AddpatientComponent },
  { path: "AddDoctor", component: AddDocteurComponent },
  { path: "ListDoctor", component: ListeDocteurComponent },
  { path: "userinfo/:id", component: UserinfoComponent },
  { path: "ListeLaborantin", component: ListeLaborantinsComponent },
  { path: "AddLaborantin", component: AddLaborantinComponent },
  { path: "ListeSecretaire", component: ListSecretaireComponent },
  { path: "AddSecretaires", component: AddSeretairesComponent },
  { path: "userInfo/:id", component: UserInfoComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
