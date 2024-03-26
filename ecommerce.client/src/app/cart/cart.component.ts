import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { Product } from '../product/product&category';
import { AuthService } from '../auth.service';

import { StripeService } from '../stripe.service';
import { Order } from '../models/order';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: Product[] = [];
  order: Order = new Order(); // Declare the order property and initialize it
  products: Product[] = [];
  
  constructor(private cartService: CartService
    , private authService: AuthService,
    private router: Router, private stripeService: StripeService, private auth: AuthService) { }

  ngOnInit() {
    this.cartService.cartItems$.subscribe((cartItems) => {
      this.cartItems = cartItems;
     
    });

    this.stripeService.getProducts().subscribe(products => {
      this.products = products;
    
    });
  }




  incrementQuantity(product: Product): void {
    const updatedCartItems = this.cartItems.map(item =>
      item === product
        ? { ...item, quantity: Math.max((item.quantity ?? 0) + 1, 1) }
        : item
    );
   /* console.log('Updated Cart Items:', updatedCartItems);*/
    this.cartService.updateCartItems(updatedCartItems);
  }

  decrementQuantity(product: Product): void {
    const updatedCartItems = this.cartItems.map(item =>
      item === product && item.quantity !== undefined && item.quantity > 1
        ? { ...item, quantity: (item.quantity ?? 0) - 1 }
        : item
    );
   /* console.log('Updated Cart Items:', updatedCartItems);*/
    this.cartService.updateCartItems(updatedCartItems);
  }

  async onBuyNowClick(): Promise<void> {
    try {
      if (!this.authService.isLogged()) {
        // If user is not logged in, navigate to the sign-up page
        this.router.navigateByUrl('/signup');
        return;
      }

      if (this.cartItems && this.cartItems.length > 0) {
        // Pass the entire array of cartItems
        const response = await this.stripeService.checkout(this.cartItems).toPromise();

        // Check if response is not undefined
        if (response) {
          // Create an Order object
          const order: Order = {
            sessionId: response.sessionId,
            pubKey: response.pubKey,
            orderDate: response.orderDate,
          };

          // Opens up Stripe.
          this.openStripe(order);
        } else {
          /*console.error('Checkout response is undefined.');*/
          // Handle the error as needed
        }
      } else {
        /*console.error('No products available in the cart.');*/
      }
    } catch (error) {
      /*console.error('Errors during checkout:', error);*/
      // Handle the error as needed
    }
  }





  private openStripe(order: Order): void {
    /*console.log('Order:', order);*/

    // Ensure that Stripe has been loaded
    if (window.Stripe && order.pubKey && typeof order.pubKey === 'string') {
     /* console.log('Valid pubkey:', order.pubKey);*/

      const stripe = window.Stripe(order.pubKey);

      // Open Checkout with further options
      stripe.redirectToCheckout({
        sessionId: order.sessionId,
      }).then((result: any) => {
        if (result.error) {
         /* console.error('Error redirecting to Checkout:', result.error);*/
          // Handle the error
        }
      });
    } else {
      /*console.error('Invalid pubkey or Stripe has not been loaded.');*/
      // Handle the error
    }
  }

  cancel() {
    // Clear the cart
    this.cartService.updateCartItems([]);

    // Navigate to an empty cart page or any other desired page
    // For example, navigate to the home page
    this.router.navigateByUrl('/');
  }
}
