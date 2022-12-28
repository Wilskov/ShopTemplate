import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
/* The AccountService class is a service class that uses the HttpClient class to make HTTP requests to
the Web API */
export class AccountService {

    baseUrl = 'https://localhost:5001/api/';
    /* Creating a new BehaviorSubject object. https://stackoverflow.com/questions/39494058/behaviorsubject-vs-observable*/
    private currentUserSource = new BehaviorSubject<User | null>(null);
    currentUser$ = this.currentUserSource.asObservable();

    constructor(private http: HttpClient) { }

    login(model: any) {
        return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
            map((response: User) => {
                const user = response;
                if (user) {
                    localStorage.setItem('user', JSON.stringify(user));
                    this.currentUserSource.next(user);
                }
            })
        );
    }

    register(model: any)
	{
		return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
			map(user => {
				if (user) {
					localStorage.setItem('user', JSON.stringify(user));
					this.currentUserSource.next(user);
				}
			})
		)
	}

    setCurrentUser(user: User) {
        this.currentUserSource.next(user);

    }

    logout() {
        localStorage.removeItem('user');
        this.currentUserSource.next(null);
    }
}
