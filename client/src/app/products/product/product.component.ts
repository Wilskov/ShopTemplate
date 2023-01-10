import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from 'src/app/_services/products.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
 /*  @Input() product: any; */
  product : any = {};
  
  constructor(public productsService: ProductsService, private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.getProductId(this.route.snapshot.params['id']);
  }

  getProductId(id : number) {
    this.http.get(`https://localhost:5001/api/products/${id}`).subscribe({
      next: response => this.product = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }
 


}
