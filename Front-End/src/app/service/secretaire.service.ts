import { from } from 'rxjs';
import { Secretaire } from 'shared/secretaire';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecretaireService {
  private apiUrl = "http://localhost:51831/api/Secretaires";
  delete: any;

  constructor(private httpClient: HttpClient) { }

  getSecretaire() {
    return this.httpClient.get(this.apiUrl);
  }

  getSecretaireById(id: number) {
    return this.httpClient.get<Secretaire>(this.apiUrl + "/" + id);
  }

  deleteTask(id) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
  }


  save(ss) {
    console.log(ss);
    return this.httpClient.post<any>(this.apiUrl, ss);
  }
}

