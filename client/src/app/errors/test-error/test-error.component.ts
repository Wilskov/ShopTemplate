import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-test-error',
    templateUrl: './test-error.component.html',
    styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
    baseUrl = 'https://localhost:5001/api/';
    validationErrors: string[] = [];


    constructor(private http: HttpClient) { }

    ngOnInit(): void {
    }

    get400ValidationError() {
        this.http.post(this.baseUrl + 'account/register', {}).subscribe({
            next: response => {
                console.log('====================================');
                console.log(response);
                console.log('====================================');
            },
            error: error => {
                console.log('====================================');
                console.log(error);
                console.log('====================================');
                this.validationErrors = error;
            }
        })
    }

    get400Error() {
        this.http.get(this.baseUrl + 'buggy/bad-request').subscribe({
            next: response => {
                console.log('====================================');
                console.log(response);
                console.log('====================================');
            },
            error: error => {
                console.log('====================================');
                console.log(error);
                console.log('====================================');
            }
        })
    }
    get401Error() {
        this.http.get(this.baseUrl + 'buggy/auth').subscribe({
            next: response => {
                console.log('====================================');
                console.log(response);
                console.log('====================================');
            },
            error: error => {
                console.log('====================================');
                console.log(error);
                console.log('====================================');
            }
        })
    }


    get404Error() {
        this.http.get(this.baseUrl + 'buggy/not-found').subscribe({
            next: response => {
                console.log('====================================');
                console.log(response);
                console.log('====================================');
            },
            error: error => {
                console.log('====================================');
                console.log(error);
                console.log('====================================');
            }
        })
    }

    get500Error() {
        this.http.get(this.baseUrl + 'buggy/server-error').subscribe({
            next: response => {
                console.log('====================================');
                console.log(response);
                console.log('====================================');
            },
            error: error => {
                console.log('====================================');
                console.log(error);
                console.log('====================================');
            }
        })
    }

}
