// cart.service.ts

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../product/product&category';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItemsSubject = new BehaviorSubject<Product[]>([]);
  cartItems$ = this.cartItemsSubject.asObservable();

  addToCart(product: Product) {
    const currentCartItems = this.cartItemsSubject.value;
    const updatedCartItems = [...currentCartItems, product];
    this.cartItemsSubject.next(updatedCartItems);
  }

  //addToCart(product: Product) {
  //  const currentCartItems = this.cartItemsSubject.value;
  //  const existingItem = currentCartItems.find(item => item === product);

  //  if (existingItem) {
  //    // If the item already exists in the cart, increment the quantity
  //    const updatedCartItems = currentCartItems.map(item =>
  //      item === existingItem ? { ...item, quantity: (item.quantity || 1) + 1 } : item
  //    );
  //    this.cartItemsSubject.next(updatedCartItems);
  //  } else {
  //    // If the item is not in the cart, add it with quantity 1
  //    const updatedCartItems = [...currentCartItems, { ...product, quantity: 1 }];
  //    this.cartItemsSubject.next(updatedCartItems);
  //  }
  //}



  getCartItems(): Product[] {
    return this.cartItemsSubject.value;
  }

  updateCartItems(updatedCartItems: Product[]) {
    this.cartItemsSubject.next(updatedCartItems);
  }

  //removeFromCart(product: Product) {
  //  const currentCartItems = this.cartItemsSubject.value;
  //  const updatedCartItems = currentCartItems.filter(item => item !== product);
  //  this.cartItemsSubject.next(updatedCartItems);
  //}

  //isInCart(product: Product): boolean {
  //  const currentCartItems = this.cartItemsSubject.value;
  //  return currentCartItems.some(item => item === product);
  //}



  isInCart(product: Product): boolean {
    const currentCartItems = this.cartItemsSubject.value;
    return currentCartItems.some((item) => item.productId === product.productId);
  }

  removeFromCart(product: Product) {
    const currentCartItems = this.cartItemsSubject.value;
    const updatedCartItems = currentCartItems.filter((item) => item.productId !== product.productId);
    this.cartItemsSubject.next(updatedCartItems);
  }

}
