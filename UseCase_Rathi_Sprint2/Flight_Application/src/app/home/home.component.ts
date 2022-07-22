import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  imageurl:any="././assets/Flight.jpg";
  constructor() { }

  ngOnInit(): void {
  }

}
