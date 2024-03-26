import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, map } from 'rxjs';
import { Product } from './product/product&category';

import { Stripe } from '@stripe/stripe-js';
import { RedirectToCheckoutOptions } from '@stripe/stripe-js';


export class Order {
  sessionId!: string;
  pubKey!: string;
  orderDate: string | number | Date | null | undefined;
}


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class StripeService {
  private stripe: Stripe | null = null;
  private readonly devApiBaseAddress = 'https://localhost:7033';

  constructor(private http: HttpClient) {
    // Initialize Stripe with your public key
    // Note: You need to replace 'your-public-key' with your actual Stripe public key
    // Initialize as undefined; it will be set asynchronously
   /* this.initializeStripe();*/
  }

  private async initializeStripe(order: Order): Promise<void> {
    // Load Stripe asynchronously
    const stripe = await import('@stripe/stripe-js');
    this.stripe = await stripe.loadStripe(order.pubKey);

    // Now, you can use other values from the 'order' instance as needed
    //console.log('Session ID:', order.sessionId);
    //console.log('Order Date:', order.orderDate);
  }

  getProducts(): Observable<Product[]> {
    const url = `${this.devApiBaseAddress}/api/product/getAll`;

    return this.http.get<Product[]>(url)
      .pipe(
        catchError(error => {
          console.error('Error fetching products:', error);
          throw error; // Rethrow the error to propagate it
        })
      );
  }

  checkout(product: Product[]): Observable<any> {
    const url = `${this.devApiBaseAddress}/order/checkout`;

    return this.http.post(url, product).pipe(
      map((response: any) => response), // Adjust based on the structure of your response
      catchError((error: any) => {
        console.error('Error during checkout:', error);
        throw error;
      })
    );
  }
  openStripe(pubKey: string, sessionId: string): void {
    console.log('Opening Stripe:', { pubKey, sessionId }); // Add this line

    if (!this.stripe) {
      console.error('Stripe is not initialized.');
      // Handle the error
      return;
    }

    const options: RedirectToCheckoutOptions = {
      sessionId: sessionId
    };

    this.stripe.redirectToCheckout(options).then((result: any) => {
      if (result.error) {
        console.error('Error redirecting to Checkout:', result.error);
        // Handle the error
      }
    });
  }
}
