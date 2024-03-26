import { Injectable } from '@angular/core';
import * as alertifyjs from 'alertifyjs';
@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }

  success(msg: string) {

    alertifyjs.success(msg);
  }

  error(msg: string) {

    alertifyjs.error(msg);
  }

  warning(msg: string) {

    alertifyjs.warning(msg);
  }
}
