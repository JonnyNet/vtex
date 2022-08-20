import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDatailComponent } from './property-datail.component';

describe('PropertyDatailComponent', () => {
  let component: PropertyDatailComponent;
  let fixture: ComponentFixture<PropertyDatailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyDatailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PropertyDatailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
