import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import dateFormat from 'dateformat';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/main/services/auth.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { APP_CONFIG } from 'src/app/main/configs/environment.config';
import { CommonModule } from '@angular/common';
import { NgToastService } from 'ng-angular-popup';
import { ClientService } from 'src/app/main/services/client.service';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [BsDropdownModule, RouterModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit, OnDestroy {
  data: string = '';
  userDetail: string = '';
  loggedInUserDetail: any;
  private unsubscribe: Subscription[] = [];
  private intervalId: any; // For setInterval reference

  constructor(
    private _service: AuthService,
    private _clientService: ClientService,
    public _router: Router,
    private _toast: NgToastService
  ) {
    // Update every second, not every millisecond
    this.intervalId = setInterval(() => {
      const now = new Date();
      this.data = dateFormat(now, 'dddd mmmm dS,yyyy, h:MM:ss TT');
    }, 1000);
  }

  ngOnInit(): void {
    const user = this._service.getUserDetail();
    if (user && user.userId) {
      this.loginUserDetailByUserId(user.userId);
    }
    const userSubscription = this._service
      .getCurrentUser()
      .subscribe((data: any) => {
        const userName = this._service.getUserFullName();
        this.userDetail = data == null ? userName : data.fullName;
      });
    this.unsubscribe.push(userSubscription);
  }

  loginUserDetailByUserId(id: any) {
    const userDetailSubscribe = this._clientService
      .loginUserDetailById(id)
      .subscribe(
        (data: any) => {
          if (data.result == 1) {
            this.loggedInUserDetail = data.data;
          } else {
            this._toast.error(data.message); // Pass string if object errors
          }
        },
        (err) => this._toast.error(err.message)
      );
    this.unsubscribe.push(userDetailSubscribe);
  }

  getFullImageUrl(relativePath: string): string {
    return relativePath ? `${APP_CONFIG.imageBaseUrl}/${relativePath}` : '';
  }

  loggedOut() {
    this._service.loggedOut();
    this._router.navigate(['']);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }
}
