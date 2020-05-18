import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { PatientService } from "./../../../service/patient.service";
import { Patient } from "shared/patient";
import { Observable } from 'rxjs';
// import * as $ from 'jquery';
// import { from } from "rxjs";

@Component({
  selector: "app-listpatient",
  templateUrl: "./listpatient.component.html",
  styleUrls: ["./listpatient.component.css"]
})
export class ListpatientComponent implements OnInit {

  id;

  datas: any[];
  patient: Patient[] = [];
  resultPatient: Patient[] = [];

  constructor(
    private patientService: PatientService,
    httpClient: HttpClientModule
  ) { }

  ngOnInit() {
    $(document).ready(function () {
      $('#dtBasicExample').DataTable();
      $('.dataTables_length').addClass('bs-select');
    });
    this.dataGettin();
    // var id = +this.activeRoute.snapshot.paramMap.get('id');
    // this.id = id;
    // this.patientService.getPatient(this.id).subscribe((e: Patient[]) => {
    //   this.patient = e;
    // });
  }

  dataGettin() {
    this.patientService.getPatient(this.id).subscribe((e: any[]) => {
      this.datas = e;
      console.log(this.datas);
    });
  }

  // dataGettin() {
  //   this.patientService.getPatient().subscribe((e: any[]) => {
  //     this.datas = e;
  //     console.log(this.datas);
  //   });
  // }

  // You should refresh page after delete and post

  deleteTask(id) {
    this.patientService.delete(id)
      .subscribe(() => {
        this.patient = this.patient.filter(patient => patient.id != id)
      })
  }

}
