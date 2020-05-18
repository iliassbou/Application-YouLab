import { Component, OnInit } from "@angular/core";
import { PatientService } from 'src/app/service/patient.service';
import { ActivatedRoute } from '@angular/router';
import { Patient } from 'shared/patient';

@Component({
  selector: "app-userinfo",
  templateUrl: "./userinfo.component.html",
  styleUrls: ["./userinfo.component.css"]
})
export class UserinfoComponent implements OnInit {
  patients: Patient;
  id: number;
  constructor(private patientService: PatientService, private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.id = +this.activeRoute.snapshot.paramMap.get('id');

    this.patientService.getPatientById(this.id).subscribe((data: Patient) => {
      this.patients = data;
      console.log(this.patients);
    });
  }
}
