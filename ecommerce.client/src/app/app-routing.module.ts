import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { RegistrationComponent } from './User/registration/registration.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './User/login/login.component';
import { PageModeEnum } from './constans/enums';
import { CheckoutComponent } from './checkout/checkout.component';

const routes: Routes = [{ path: '', pathMatch: 'full', redirectTo: '/product' },
  { path: 'product', component: ProductComponent },
  { path: 'signup', component: RegistrationComponent },
  { path: 'signup/:id', component: RegistrationComponent, data: { pageMode: PageModeEnum.View } },
  { path: 'cart', component: CartComponent },
  { path: 'signin', component: LoginComponent },
  { path: 'checkout', component: CheckoutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
