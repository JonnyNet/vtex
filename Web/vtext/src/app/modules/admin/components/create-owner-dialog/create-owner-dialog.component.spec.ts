import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOwnerDialogComponent } from './create-owner-dialog.component';

describe('CreateOwnerDialogComponent', () => {
  let component: CreateOwnerDialogComponent;
  let fixture: ComponentFixture<CreateOwnerDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateOwnerDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateOwnerDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
