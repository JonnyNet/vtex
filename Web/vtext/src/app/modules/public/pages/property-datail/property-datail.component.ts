import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ID } from 'src/app/core/constans/constans';
import { Property } from 'src/app/core/models';
import { URLS } from 'src/app/modules/admin/constans/urls';
import { AppState } from 'src/app/state/app.state';
import { findProperty } from 'src/app/state/public/public.actions';
import { getProperty, getPropertyImages } from 'src/app/state/public/public.selector';

@Component({
  selector: 'app-property-datail',
  templateUrl: './property-datail.component.html',
  styleUrls: ['./property-datail.component.scss']
})
export class PropertyDatailComponent implements OnInit {

  property$!: Observable<Property>;
  images$!: Observable<string[]>;

  constructor(private readonly store: Store<AppState>,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.params[ID];
    if (id) {
      const numberId = +id;
      this.property$ = this.store.select(getProperty);
      this.images$ = this.store.select(getPropertyImages);
      this.store.dispatch(findProperty({ id: numberId }))
    } else {
      this.router.navigate([URLS.HOME.FULLPATH]);
    }
  }
}
