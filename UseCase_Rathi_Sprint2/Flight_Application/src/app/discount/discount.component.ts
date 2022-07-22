import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Discount } from './discount.model';

@Component({
  selector: 'app-discount',
  templateUrl: './discount.component.html',
})
export class DiscountComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetDiscounts();
  }

  discountModel: Discount = new Discount();
  discountModels: Array<Discount> = new Array<Discount>();

  modalHeader: string = '';
  modalText: string = '';
  add: boolean = false;
  showLoading: boolean = false;

  GetDiscounts() {
    this.http.get("http://20.232.8.205/gateway/api/1.0/flight/discount").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }

  GetFromServer(res: any) {
    console.log(res);
    this.discountModels = res;
    this.HideSpinner();
  }

  AddDiscount(discount: Discount) {
    this.add = false;
    var discounts = {
      discountCode: discount.discountCode,
      percentage: Number(discount.percentage)
    };
    console.log(discounts);
    this.ShowSpinner();
    console.log(this.discountModels);
    this.http.post("http://20.232.8.205/gateway/api/1.0/flight/discount", discounts).subscribe(res => this.GetDiscounts(), res => console.log(res));
    this.discountModel = new Discount();
    this.add = true;
  }


  DeleteDiscount(discount: Discount) {
    this.add = false;
    console.log(discount);
    if (confirm("Are you sure you want to delete the Discount")) {
      this.ShowSpinner();
      let httparms = new HttpParams().set("discountCode", discount.discountCode);
      let options = { params: httparms };
      this.http.delete("http://20.232.8.205/gateway/api/1.0/flight/discount", options).subscribe(res => { this.GetDiscounts(); console.log(res) }, res => console.log(res));

    }
  }

  LaunchModel(discount: Discount) {
    this.modalHeader = "Discount Code"
    this.modalText = "Avail Offers on " + discount.discountCode + " @ " + discount.percentage + "% discount";
    document.getElementById("modelButton")?.click()
  }

  ShowSpinner() {
   this.showLoading = true;
  }

  HideSpinner() {
    this.showLoading = false;
   }
}
