import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { Product } from './product&category';
import { Order } from '../models/order';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  url: string = "https://localhost:7033/api/Product";
  constructor(private _httpClient: HttpClient) { }


  getAllProducts(): Observable<Product[]> {
    return this._httpClient.get<Product[]>(`${this.url}/getAll`);

  }


  getProductById(id: number): Observable<Product> {
    return this._httpClient.get<Product>(`${this.url}/getProductById/${id}`);
  }



  addProduct(product: Product): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/addProduct`, product)
  }


  updateProduct(product: Product): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/addProduct`, product)
  }


  delete(id: number): Observable<Status> {
    return this._httpClient.delete<Status>(`${this.url}/delete/${id}`)
  }

  getProductsByCategoryId(categoryId: number): Observable<Product[]> {

    return this._httpClient.get<Product[]>(`${this.url}/getProductsByCategoryId/${categoryId}`);
  }



  checkout(product: Product): Observable<Order> {
    return this._httpClient.post<Order>(`${this.url}/checkout`, product);
  }
}








