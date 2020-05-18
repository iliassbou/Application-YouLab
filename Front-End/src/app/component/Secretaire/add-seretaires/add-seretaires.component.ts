import { Component, OnInit } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { SecretaireService } from "./../../../service/secretaire.service";
import { Secretaire } from "shared/secretaire";

@Component({
  selector: 'app-add-seretaires',
  templateUrl: './add-seretaires.component.html',
  styleUrls: ['./add-seretaires.component.css']
})
export class AddSeretairesComponent implements OnInit {

  searchText = '';

  showForm = false;


  datas: any[];
  secretaire: Secretaire[] = [];
  resultSecretaire: Secretaire[] = [];

  constructor(private secretaireService: SecretaireService,
    httpClient: HttpClientModule) { }

  ngOnInit() {
    $(document).ready(function () {
      $('#dtBasicExample').DataTable();
      $('.dataTables_length').addClass('bs-select');
    });
    this.dataGettin();
  }

  dataGettin() {
    this.secretaireService.getSecretaire().subscribe((e: any[]) => {
      this.datas = e;
      console.log(this.datas);
    });
  }

  // You should refresh page after delete

  deleteTask(id) {
    this.secretaireService.delete(id)
      .subscribe(() => {
        this.secretaire = this.secretaire.filter(secretaire => secretaire.id != id)
      })
  }



}
