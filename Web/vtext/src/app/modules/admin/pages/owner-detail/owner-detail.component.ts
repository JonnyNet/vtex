import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ID } from 'src/app/core/constans/constans';
import { Owner } from 'src/app/core/models';
import * as adminActions from 'src/app/state/admin/admin.actions';
import * as adminSelectors from 'src/app/state/admin/admin.selectors';
import { AppState } from 'src/app/state/app.state';

@Component({
  selector: 'app-owner-detail',
  templateUrl: './owner-detail.component.html',
  styleUrls: ['./owner-detail.component.scss']
})
export class OwnerDetailComponent implements OnInit {

  owner$!: Observable<Owner>;

  constructor(
    private readonly store: Store<AppState>,
    private readonly activatedRoute: ActivatedRoute
  ) { }
  
  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.params[ID];
    const numberId = Number(id);
    this.owner$ = this.store.select(adminSelectors.getOwnerById);
    this.store.dispatch(adminActions.findOwner({ id: numberId }))
  }
}
