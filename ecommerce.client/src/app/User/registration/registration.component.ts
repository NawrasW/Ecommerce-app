import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../../models/user';
import * as alertifyjs from 'alertifyjs';
import { UserService } from '../user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PageModeEnum } from '../../constans/enums';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) {

  }
  ngOnInit(): void {

    this.activatedRoute.params.subscribe(params => {
      this.userId = params['id'];

      if (this.userId) {
        this.pageMode = PageModeEnum.Update;
        this.userService.getUserById(this.userId).subscribe(result => {
          // console.log(result)
          this.user = result;
          this.user.confirmpassword = this.user.password;

        });


      }

    });
  }
  @Input() isPopup: boolean = false;
  @Output() IsValid = new EventEmitter<boolean>();
  @ViewChild('userForm') userForm!: NgForm;

  pageModeTest: string = "Add";
  @Input() pageMode: PageModeEnum = PageModeEnum.Add;
  userId!: number;
  @Input() user: User = new User();

  get PageModeEnum(): any {

    return PageModeEnum;

  }

  onSubmit(form: NgForm) {
   /* console.log(form, this.user);*/
    if (!(this.user.password === this.user.confirmpassword)) {
      //alertifyjs.error('invaild')
      //console.log("invaild passowrd");



    }

    else {
      alertifyjs.success('valid');

      this.userService.addUpdateUser(this.user).subscribe(result => {
        // console.log(result);
        if (result) {
         /* alertifyjs.success(result.statusmessage)*/
          this.router.navigate(['/product']);
        }
      },
        error => {
          console.error('Error adding user:', error);
        }
      );
    }


  }

  reset() {
    this.user = new User();
  }

  ngAfterViewInit() {
    if (this.userForm.statusChanges)
      this.userForm.statusChanges.subscribe(result =>
        this.IsValid.emit(result != 'INVALID')

      );
  }
}
