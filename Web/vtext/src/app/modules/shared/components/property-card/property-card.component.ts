import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Property } from 'src/app/core/models';
import { findFirstPropertyImage } from 'src/app/state/admin/admin.actions';
import { getFirstPropertyImageById } from 'src/app/state/admin/admin.selectors';
import { AppState } from 'src/app/state/app.state';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.scss']
})
export class PropertyCardComponent implements OnInit {

  @Input()
  property!: Property;

  image$!: Observable<string>;

  constructor(private readonly store: Store<AppState>) { }

  ngOnInit(): void {
    this.image$ = this.store.select(getFirstPropertyImageById(this.property.id));
    this.store.dispatch(findFirstPropertyImage({id: this.property.id}));
  }
}
