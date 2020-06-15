export class ItemModel {
    itemId: string;
    name: string;
    price: number;
    imageUrl: string;
    itemType: ItemType;
}

export class PizzaModel extends ItemModel {
    type: ToppingType
}

export class CrustModel extends ItemModel {
    availableSizes: Array<CrustSize>;
    checked: boolean;
}

export class ToppingModel extends ItemModel {
    type: ToppingType
}

export class CrustSize {
    crustSizeType: CrustSizeType;
    sizeToPriceRatio: number;
}

export class ErrorInfo {
    message: string;
}

export class ApiResult<T> {
    data: T;
    errorInfo: ErrorInfo;
}

export class ApiResponse<T> {
    requestId: string;
    result: ApiResult<T>
}

export enum ItemType {
    Pizza,
    Crust,
    Topping,
    Other
}

export enum ToppingType {
    Veg,
    NonVeg
}

export enum CrustSizeType {
    Regular,
    Medium,
    Large
}

export class Pizza {
    basePizza: ItemModel;
    totalPrice: number;
    size: CrustSize;
    crust: CrustModel;
    topping: Array<ToppingModel>;
}


export class OrderInput {
    pizzaInputs: Array<PizzaInput>;
    nonPizzaItemInputs: Array<NonPizzaItemInput>;
    customerId: string;
}

export class PizzaInput {
    size: CrustSizeType;
    crustId: string;
    toppingIds: Array<string>;
    pizzaId: string;
}

export class NonPizzaItemInput {
    itemId: string;
}