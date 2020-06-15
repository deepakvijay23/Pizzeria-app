import { Component, OnInit } from '@angular/core';
import { PizzaModel, ApiResponse } from 'src/app/model/pizzaModel';
import { PizzaService } from 'src/app/services/pizza.service';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  allTypePizzas: Array<PizzaModel>;

  constructor(private pizzaService: PizzaService, private dataService: DataService,
    private router: Router) {
  }

  ngOnInit() {
    this.getAllPizzas();
  }

  getAllPizzas() {
    this.pizzaService.getAllPizzas().subscribe((res: ApiResponse<Array<PizzaModel>>) => {
      this.allTypePizzas = res.result.data;
    });
  }

  onCustomize(item: PizzaModel) {
    this.dataService.changeMessage(item);
    this.router.navigate(['/customization/pizza', item.name]);
  }


}
