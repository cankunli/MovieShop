import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Register } from 'src/app/shared/models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  regiForm!: FormGroup;
  submitted = false;
  loading = false;

  constructor(private fb: FormBuilder, private authService: AuthenticationService, private route: ActivatedRoute, private router: Router ) { }

  get f() { return this.regiForm.controls; }

  buildForm() {
    this.regiForm=this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email:[null, {validators: [Validators.required, Validators.email]}],
      password:['', Validators.required],
      confirmPassword:['', Validators.required]
    })
  }

  ngOnInit(){
    this.buildForm();
  }
  

  onSubmit() {
    // console.log('submit clicked');
    console.log(this.regiForm);
    this.submitted = true;

    // stop here if form is invalid
    if (this.regiForm.invalid) {
      return;
    }

    this.authService.register(this.regiForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate(['/login'], { relativeTo: this.route });
                },
                error => {
                    //this.alertService.error(error);
                  this.loading = false;
                });

  }

}
