import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private http:HttpClient) { }

  apiUrl = "https://localhost:44343/api/";

  public getAPI_URL(url:any){
    return this.http.get(`${this.apiUrl}${url}`);
  }

}
