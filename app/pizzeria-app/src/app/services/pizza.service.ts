import { Injectable } from '@angular/core';
import { PizzaModel, ApiResponse } from '../model/pizzaModel';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {
  baseUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getAllPizzas(): Observable<ApiResponse<Array<PizzaModel>>> {
    const url = `${this.baseUrl}/items/pizza`;
    return this.httpClient.get<ApiResponse<Array<PizzaModel>>>(url);
  }
}
