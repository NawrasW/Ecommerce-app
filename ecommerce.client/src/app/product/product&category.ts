export class Category {
  categoryId: number | undefined;
  name: string | undefined;
  icon: string | undefined;
  //constructor(id: number, name?: string) {
  //  this.categoryId = id;
  //  this.name = name;
  //}
}



export class Product {
  productId: number | undefined;
  name: string | undefined;
  description: string | undefined;
  imageData: string | undefined;
  price: number | undefined;
  quantity: number = 1;
  categoryId: number | undefined;
  category?: Category;

  constructor() {
    this.name = ''; // Initialize 'name' with an empty string
  }
}


