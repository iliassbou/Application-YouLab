import { Component, OnInit } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { LaborantinService } from "./../../../service/laborantin.service";
import { Laborantin } from "shared/laborantin";

@Component({
  selector: 'app-liste-laborantins',
  templateUrl: './liste-laborantins.component.html',
  styleUrls: ['./liste-laborantins.component.css']
})
export class ListeLaborantinsComponent implements OnInit {

  searchText = '';

  showForm = false;

  myLaborantin: Laborantin = {
    id: '',
    name: '',
    userName: '',
    lastName: ''
  }
  datas: any[];
  laborantin: Laborantin[] = [];
  resultLaborantin: Laborantin[] = [];

  constructor(private laborantinService: LaborantinService,
    httpClient: HttpClientModule) { }

  ngOnInit() {
    $(document).ready(function () {
      $('#dtBasicExample').DataTable();
      $('.dataTables_length').addClass('bs-select');
    });
    this.dataGettin();
  }

  dataGettin() {
    this.laborantinService.getLaborantin().subscribe((e: any[]) => {
      this.datas = e;
      console.log(this.datas);
    });
  }

  // You should refresh page after delete

  deleteTask(id) {
    this.laborantinService.delete(id)
      .subscribe(() => {
        this.laborantin = this.laborantin.filter(laborantin => laborantin.id != id)
      })
  }



}
