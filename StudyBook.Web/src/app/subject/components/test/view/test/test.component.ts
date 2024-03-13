import { Component } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent {


  previous()
  {
    console.log("previous");
  }
  next()
  {
    console.log("next");
  }

  start()
  {
    console.log("start");
  }
  save()
  {
    console.log("save");
  }
}
