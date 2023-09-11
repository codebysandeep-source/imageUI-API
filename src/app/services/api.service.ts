import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  baseUrl = "";
  constructor(private http:HttpClient) {
    this.baseUrl = (window as any).apiBaseUrl;
   }

  public getAPI_URL(apiUrl:any){
    return this.http.get(`${this.baseUrl}${apiUrl}`);
  }

}
