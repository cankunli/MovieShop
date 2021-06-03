import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/models/user';
import { UserDataService } from '../../dataServices/user-data.service';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuthenticated:boolean | undefined;
  currentUser!: User;

  constructor(private authService:AuthenticationService, private route: Router, private userDataService: UserDataService) { }

  ngOnInit(): void {
    this.authService.isAuthenticated.subscribe(
      auth => {
        this.isAuthenticated = auth;
        console.log('Auth Status: ' + this.isAuthenticated);
        if (this.isAuthenticated) {
          this.currentUser = this.userDataService.curentUser;
          console.log(this.currentUser);
        }
      }
    );
  }

  logout(){
    this.authService.logout();
    this.route.navigateByUrl('/login');
  }
}
