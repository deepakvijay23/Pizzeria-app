import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PizzaModel } from '../model/pizzaModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  private pizzaSource = new BehaviorSubject<PizzaModel>(null);
  currentMessage = this.pizzaSource.asObservable();

  changeMessage(message: PizzaModel) {
    this.pizzaSource.next(message)
  }
}
