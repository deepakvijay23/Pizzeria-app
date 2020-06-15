import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse, CrustModel, ToppingModel, OrderInput } from '../model/pizzaModel';

@Injectable({
  providedIn: 'root'
})
export class CustomizationService {
  baseUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getAllCrsuts(): Observable<ApiResponse<Array<CrustModel>>> {
    const url = `${this.baseUrl}/items/crust`;
    return this.httpClient.get<ApiResponse<Array<CrustModel>>>(url);
  }

  getAllTopping(): Observable<ApiResponse<Array<ToppingModel>>> {
    const url = `${this.baseUrl}/items/topping`;
    return this.httpClient.get<ApiResponse<Array<ToppingModel>>>(url);
  }

  placeOrder(input: OrderInput): Observable<ApiResponse<any>> {
    const url = `${this.baseUrl}/order`;
    console.log(url);
    console.log(input);
    return this.httpClient.post<ApiResponse<any>>(url, input);
  }

}
