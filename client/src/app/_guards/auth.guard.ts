import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Injectable({
    providedIn: 'root'
})
/* The AuthGuard class implements the CanActivate interface, which means it has a canActivate() method.


The canActivate() method returns an Observable<boolean> or a Promise<boolean> or a boolean. 

If the canActivate() method returns true the route is activated (allowed to proceed), if it returns
false the route is blocked. 

The canActivate() method in the AuthGuard class returns an Observable<boolean> which is the result
of subscribing to the currentUser$ observable. 

The currentUser$ observable emits a value every time the user logs in or out. 

If the user is logged in the currentUser$ observable emits an object with the user details, if the
user is logged out the currentUser$ observable emits null. 

The map operator is used to map the user object emitted by the currentUser$ observable to true or
false, which */
export class AuthGuard implements CanActivate {

    constructor(private accountService: AccountService, private toastr: ToastrService) { }
    canActivate(): Observable<boolean> {
       return this.accountService.currentUser$.pipe(
            map(user => {
                if (user) return true;
                else {
                    this.toastr.error('You shall not pass!');
                    return false
                }
            })
       )
    }

}
