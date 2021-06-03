import { Injectable } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {


  isAuthenticated!: boolean;
  curentUser!: User;
  
  constructor(private userService: UserService, private authService: AuthenticationService) { 
    this.authService.isAuthenticated.subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
      if (this.isAuthenticated) {
        this.authService.currentUser.subscribe((user: User) => {
          this.curentUser = user;
          console.log(this.curentUser);
        });
      }
    });
  }
}
