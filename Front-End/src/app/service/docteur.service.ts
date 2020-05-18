import { Docteur } from 'shared/docteur';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DocteurService {
  private apiUrl = "http://localhost:58810/api/Consultations";
  delete: any;

  constructor(private httpClient: HttpClient) { }

  getDocteur() {
    return this.httpClient.get(this.apiUrl);
  }

  getDocteurById(id: number) {
    return this.httpClient.get<Docteur>(this.apiUrl + "/" + id);
  }

  deleteTask(id) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
  }


  save(ss) {
    console.log(ss);
    return this.httpClient.post<any>(this.apiUrl, ss);
  }
}

