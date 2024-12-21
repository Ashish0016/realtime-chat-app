import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/services/shared-service/shared.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public signupForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private http: HttpClient,
    private toaster: ToastrService,
    private router: Router,
    private sharedService: SharedService
  ) { }

  ngOnInit(): void {
    this.signupForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: [''],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  signup() {
    const httpRequestBody = this.signupForm.getRawValue();

    this.http.post('api/user/createUser', httpRequestBody)
      .subscribe((res:any) => {
        this.toaster.success('User created successfully!');
        this.sharedService.setToken(res.jwtToken);
        this.router.navigate(['chat']);
      }, (err: any) => {

      });
  }

  sigin() {
    this.router.navigate(['']);
  }
}
