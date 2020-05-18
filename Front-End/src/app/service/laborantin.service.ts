import { from } from 'rxjs';
import { Laborantin } from '../../../shared/laborantin';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LaborantinService {

  private apiUrl = "http://localhost:51831/api/Laborantins";
  delete: any;

  constructor(private httpClient: HttpClient) { }

  getLaborantin() {
    return this.httpClient.get(this.apiUrl);
  }

  getLaborantinById(id: number) {
    return this.httpClient.get<Laborantin>(this.apiUrl + "/" + id);
  }

  deleteTask(id) {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
  }

  save(ss) {
    console.log(ss);
    return this.httpClient.post<any>(this.apiUrl, ss);
  }
}

