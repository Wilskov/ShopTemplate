import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
	selector: 'app-nav',
	templateUrl: './nav.component.html',
	styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

	model: any = {};
	// operator "of" => RxJS library link: https://angular.io/guide/rx-library
	currentUser$: Observable<User | null> = of(null)

	constructor(public accountService: AccountService, private router: Router) { }

	ngOnInit(): void {
		this.currentUser$ = this.accountService.currentUser$;
	}

	login() {
		this.accountService.login(this.model).subscribe({
			next: _ => this.router.navigateByUrl('/members'), // 'underscore' is using when you don't use any arguement 
			error: error => console.log(error)
		});
	}

	logout() {
		this.accountService.logout();
		this.router.navigateByUrl('/');

	};
}



