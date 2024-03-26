// header.component.ts
import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart/cart.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import * as alertifyjs from 'alertifyjs';
import { AlertService } from '../alert.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {

  constructor(private cartService: CartService, private router: Router, private alert: AlertService, private auth: AuthService) {
    // Subscribe to changes in the cart items
    this.cartService.cartItems$.subscribe((items) => {
      // Update the cart item count
      this.cartItemCount = items.length;
    });
  }

  ngOnInit(): void {
    this.loggedinUserIdfn();
  }

  loggedinUser: string | undefined;
  loggedinUserId: number | undefined;
  cartItemCount: number = 0;

  loggedin() {
    const fullName = this.auth.getFullName();
    const userId = this.auth.getUserId();

    if (fullName && userId) {
      this.loggedinUser = fullName;
      this.loggedinUserId = +userId;
      return true;
    } else {
      return false;
    }
  }

  loggedinUserIdfn() {
    const userId = this.auth.getUserId();

    if (userId) {
      this.loggedinUserId = +userId;
    }
  }

  logout() {
    this.auth.logOut();
    this.alert.success("Logged out Successfully");
    this.router.navigateByUrl('/');
  }
}
