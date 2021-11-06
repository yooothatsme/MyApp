import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  canActivate(): Observable<boolean> | boolean {
    let token;
    this.accountService.curresntUser$.subscribe(resp => {
      if(resp)
      token = resp.token;
    });
    if (token) {
      return true;
    }
    else {
      return false;
    }
  }
}