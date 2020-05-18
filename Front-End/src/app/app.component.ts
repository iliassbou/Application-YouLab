import { Component, OnInit } from "@angular/core";
import { PatientService } from "./service/patient.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "youlab";
  patient: any = [];

  constructor(private api: PatientService) { }

  ngOnInit() {
    this.getPatient();
  }

  getPatient() {
    this.api.getPatient().subscribe(data => {
      for (const res of data as any) {
        this.patient.push({
          name: res.nom,
          price: res.prenom
        });
      }
      // console.log(this.patient);
    });
  }
}
