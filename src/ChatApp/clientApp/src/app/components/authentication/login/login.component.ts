import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/services/shared-service/shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm!: FormGroup;

  constructor(private _formBuilder: FormBuilder,
    private http: HttpClient,
    private sharedService: SharedService,
    private router: Router,
    private toaster: ToastrService
  ) { }

  ngOnInit(): void {
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  login() {
    const httpRequestBody = {
      email: this.loginForm.controls['email'].value,
      password: this.loginForm.controls['password'].value
    }

    this.http.post('api/account/login', httpRequestBody)
      .subscribe((res: any) => {
        if (!res) {
          this.toaster.error("Invalid credientials provided.");
        }
        this.sharedService.setToken(res.jwtToken);
        this.router.navigate(['chat']);
      }, (err: any) => {
        this.toaster.error("Invalid credientials provided.");
      })
  }

  signup(){
    this.router.navigate(['register'])
  }
}
