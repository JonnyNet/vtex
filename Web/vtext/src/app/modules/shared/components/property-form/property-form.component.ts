import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { REGEX } from 'src/app/core/constans/regex';
import { Property } from 'src/app/core/models';
import { FormatNumberService } from 'src/app/modules/shared/services/format-number.service';

@Component({
  selector: 'app-property-form',
  templateUrl: './property-form.component.html',
  styleUrls: ['./property-form.component.scss']
})
export class PropertyFormComponent implements OnInit {

  form!: FormGroup;

  @Input("property") set property(value: Property) {
    if (value) {
      this.form.patchValue(value);
    }
  }

  @Input() disabled = false;
  @Output() submit = new EventEmitter<string>();

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly formatNumberService: FormatNumberService,
  ) {
    const validatorNumber = Validators.pattern(REGEX.NUMBER);
    this.form = this.formBuilder.group({
      id: [''],
      ownerId: [''],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      address: ['', [Validators.maxLength(100)]],
      price: ['', [Validators.required, Validators.pattern(REGEX.CURRENCY), Validators.maxLength(11)]],
      year: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(4), validatorNumber]],
      bedRooms: ['', [Validators.required, Validators.maxLength(2), validatorNumber]],
      bathRooms: ['', [Validators.required, Validators.maxLength(2), validatorNumber]],
      area: ['', [Validators.pattern(REGEX.DECIMALS)]],
      parkingLot: ['', [Validators.required, Validators.maxLength(2), validatorNumber]],
      description: ['', Validators.maxLength(500)]
    });
  }
  
  ngOnInit(): void {
    if(this.disabled){
      this.form.disable();
    }
  }

  formatNumber(event: any) {
    const value = event.target.value;
    const formatValue = this.formatNumberService.currency(value);
    event.target.value = formatValue.format;
  }

  onSubmit() {
    if (this.form.valid) {
      const price = this.formatNumberService.clearValue(this.form.value.price);
      const data = {
        ...this.form.value,
        price,
      };
      this.submit.emit(data);
    }
  }

}
