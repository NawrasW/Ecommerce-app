// checkout.component.ts

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CartService } from '../cart/cart.service';
import { Product } from '../product/product&category';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent {
  cartItems: Product[] = [];
  shippingInfoForm: FormGroup;

  constructor(private cartService: CartService, private formBuilder: FormBuilder) {
    this.cartService.cartItems$.subscribe((cartItems) => {
      this.cartItems = cartItems;
    });

    // Initialize the form with some basic validation
    this.shippingInfoForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      // Add more fields as needed
    });
  }

  placeOrder() {
    // Implement logic to handle placing the order
    console.log('Placing Order');
    console.log('Shipping Info:', this.shippingInfoForm.value);
  }

  submitOrder() { }
}
