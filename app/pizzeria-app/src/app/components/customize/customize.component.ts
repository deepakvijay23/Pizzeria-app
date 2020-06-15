import { Component, OnInit } from '@angular/core';
import { CrustModel, ApiResponse, ToppingModel, ItemType, ToppingType, PizzaModel, Pizza, CrustSize, CrustSizeType, OrderInput } from 'src/app/model/pizzaModel';
import { CustomizationService } from 'src/app/services/customization.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-customize',
  templateUrl: './customize.component.html',
  styleUrls: ['./customize.component.css']
})
export class CustomizeComponent implements OnInit {

  private testCustomId: string = "31d6bb0c-c8ce-4e7c-bb81-0bfd71fe5ba9";
  private selectedToppings: Array<ToppingModel> = [];
  displayMessage: boolean = false;
  ordernum: string;
  selectedVegTopping;
  selectedNonVegTopping;
  pizza: PizzaModel;
  crusts: Array<CrustModel>;
  vegToppings: Array<ToppingModel>;
  nonvegToppings: Array<ToppingModel>;
  totalPrice: number;
  customPizza: Pizza = new Pizza();

  constructor(private dataService: DataService,
    private customizationService: CustomizationService) { }

  pizzaSizess = [
    { text: "Regular", value: 0, checked: true },
    { text: "Medium", value: 1, checked: false },
    { text: "Large", value: 2, checked: false }
  ];

  ngOnInit(): void {
    this.dataService.currentMessage.subscribe(model => {
      console.log(model);
      this.pizza = model;
      this.customPizza.basePizza = model;
      this.totalPrice = model.price;
    });
    this.getAllCrusts(CrustSizeType.Regular);
    this.getAllToppings();
  }

  getAllCrusts(sizeType: CrustSizeType) {
    this.customizationService.getAllCrsuts().subscribe((res: ApiResponse<Array<CrustModel>>) => {
      let data: Array<CrustModel> = [];

      res.result.data.forEach(element => {
        element.availableSizes.forEach(p => {
          if (p.crustSizeType === sizeType) {
            data.push(element);
          }
        });

      });
      const defaultCrust = data[0];
      this.customPizza.crust = defaultCrust;
      data[0].checked = true;
      this.crusts = data;
    });
  }

  getAllToppings() {
    this.customizationService.getAllTopping().subscribe((res: ApiResponse<Array<ToppingModel>>) => {
      const allTypeTopping: Array<ToppingModel> = res.result.data;
      this.vegToppings = allTypeTopping.filter(x => x.type == ToppingType.Veg);
      this.nonvegToppings = allTypeTopping.filter(x => x.type == ToppingType.NonVeg);
    });
  }

  onSizeChange(size) {
    this.getAllCrusts(size.value);
    let crustSize: CrustSize;
    this.crusts.forEach(x => {
      const s = x.availableSizes.find(t => t.crustSizeType === size.value);
      if (x.availableSizes.find(t => t.crustSizeType === size.value)) {
        crustSize = s;
      }
    });
    console.log(crustSize);
    this.customPizza.size = crustSize;
    this.calculateTotalPrice();
  }

  onCrustChange(crustValue) {
    const crsut = this.crusts.find(x => x.itemId === crustValue.value);
    this.customPizza.crust = crsut;
    this.calculateTotalPrice();
  }

  onVegToppingsChange(e) {
    this.selectedVegTopping.forEach(element => {
      const topping = this.vegToppings.find(x => x.itemId === element);
      if (this.selectedToppings.indexOf(topping) === -1) {
        this.selectedToppings.push(topping);
      }
    });

    this.customPizza.topping = this.selectedToppings;
    this.calculateTotalPrice();
  }

  onNonVegToppingsChange(e) {
    this.selectedNonVegTopping.forEach(element => {
      const topping = this.nonvegToppings.find(x => x.itemId === element);
      if (this.selectedToppings.indexOf(topping) === -1) {
        this.selectedToppings.push(topping);
      }
    });

    this.customPizza.topping = this.selectedToppings;
    this.calculateTotalPrice();
  }

  calculateTotalPrice() {
    const basePrice = this.customPizza.basePizza.price;
    const crsutPriceAsperSize = this.customPizza.size.sizeToPriceRatio * this.customPizza.crust.price;
    let totalToppingPrice = 0;
    this.customPizza.topping?.forEach(element => {
      totalToppingPrice += element.price;
    });

    this.totalPrice = basePrice + crsutPriceAsperSize + totalToppingPrice;
  }

  placeOrder() {
    let order = new OrderInput();
    const toppings = this.customPizza.topping.map(x => x.itemId);
    console.log(toppings);
    order.customerId = this.testCustomId;
    order.pizzaInputs = [];
    order.pizzaInputs.push({
      crustId: this.customPizza.crust.itemId,
      pizzaId: this.customPizza.basePizza.itemId,
      size: this.customPizza.size.crustSizeType,
      toppingIds: this.customPizza.topping.map(x => x.itemId)
    });

    this.customizationService.placeOrder(order).subscribe((data: ApiResponse<any>) => {
      this.ordernum = data.result.data.orderNumber;
      this.displayMessage = true;
    });

  }
}