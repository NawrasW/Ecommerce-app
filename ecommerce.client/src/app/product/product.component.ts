import { Component, OnInit } from '@angular/core';
import { ProductsService } from './product.service';
import { CategoryService } from './category.service';
import { Category, Product } from './product&category';
import { CartService } from '../cart/cart.service';
import * as alertifyjs from 'alertifyjs';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  filteredItems: Product[] = [];
  selectedCategory: number | undefined;
  cartItems: Product[] = []; // Add this line
  constructor(private productService: ProductsService, private categoryService: CategoryService, private cartService: CartService) { }

  ngOnInit() {
    // Fetch categories first
    this.categoryService.getAllCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
     /* console.log('Categories:', this.categories);*/
      

      // After fetching categories, fetch products
      this.productService.getAllProducts().subscribe((products: Product[]) => {
        this.products = products;
        this.filteredItems = products; // Initialize filtered items with all items
        //console.log('Products:', this.products);

        // Ensure the first category is selected on page refresh
        if (this.categories.length > 0) {
          this.filterItems(this.categories[0].categoryId);
        }
      });
    });


    this.cartService.cartItems$.subscribe((cartItems) => {
      this.cartItems = cartItems;
    });
  }

  filterItems(categoryId: number | undefined) {
 /*   console.log('Filtering items for Category ID:', categoryId);*/

    if (categoryId !== undefined) {
      this.selectedCategory = categoryId;
      this.filteredItems = this.products.filter((product) => product.categoryId === categoryId);
    /*  console.log('Filtered Items:', this.filteredItems);*/
    } else {
      this.selectedCategory = undefined;
      this.filteredItems = this.products;
 

    }
  }

  //isInCart(product: Product): boolean {
  //  return this.cartItems.some(item => item === product && (item.quantity || 0) > 0);
  //}




  addToCart(product: Product) {
    this.cartService.addToCart(product);
    alertifyjs.error('invaild')
  }


  removeFromCart(product: Product) {
    this.cartService.removeFromCart(product);
  }

  isInCart(product: Product): boolean {
    return this.cartService.isInCart(product);
  }
}
