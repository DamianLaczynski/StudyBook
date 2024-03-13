import { Component, Input } from '@angular/core';
import { Test } from '../../model/test';

@Component({
  selector: 'app-list-test',
  templateUrl: './list-test.component.html',
  styleUrl: './list-test.component.css',
})
export class ListTestComponent {
    @Input() tests!: Test[];
}
