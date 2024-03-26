import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { Category } from './product&category';




@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  url: string = "https://localhost:7033/api/Category";
  constructor(private _httpClient: HttpClient) { }


  getAllCategories(): Observable<Category[]> {
    return this._httpClient.get<Category[]>(`${this.url}/getAll`);

  }


  getById(id: number): Observable<Category> {
    return this._httpClient.get<Category>(`${this.url}/getById/${id}`);
  }



  addUpdate(category: Category): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/AddUpdate`, category)
  }


  delete(id: number): Observable<Status> {
    return this._httpClient.delete<Status>(`${this.url}/delete/${id}`)
  }
}
