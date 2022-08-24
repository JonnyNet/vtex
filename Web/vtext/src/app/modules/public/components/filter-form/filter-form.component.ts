import { Component, EventEmitter, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { REGEX } from 'src/app/core/constans/regex';
import { Filter } from 'src/app/core/models';
import { FormatNumberService } from 'src/app/modules/shared/services/format-number.service';

@Component({
  selector: 'app-filter-form',
  templateUrl: './filter-form.component.html',
  styleUrls: ['./filter-form.component.scss']
})
export class FilterFormComponent {

  form!: FormGroup;
  @Output() filter = new EventEmitter<Filter>();

  constructor(
    private readonly formBulder: FormBuilder,
    private readonly formatNumberService: FormatNumberService) {

    const decimalValidator = Validators.pattern(REGEX.DECIMALS);
    const currencyValidator = Validators.pattern(REGEX.CURRENCY);
    this.form = this.formBulder.group({
      bedrooms: [''],
      bathrooms: [''],
      parkingLot: [''],
      areaFrom: ['', decimalValidator],
      areaTo: ['', [decimalValidator, this.toGreaterThanFromValidator('areaFrom')]],
      priceFrom: ['', currencyValidator],
      priceTo: ['', [currencyValidator, this.toGreaterThanFromValidator('priceFrom')]]
    }, { validators: this.atLeastOneValidator });
  }

  formatNumber(event: any) {
    const value = event.target.value;
    const formatValue = this.formatNumberService.currency(value);
    event.target.value = formatValue.format;
  }

  onSubmit() {
    if (this.form.valid) {
      const priceFrom = this.formatNumberService.clearValue(this.form.value.priceFrom);
      const priceTo = this.formatNumberService.clearValue(this.form.value.priceTo);
      const data = {
        ...this.form.value,
        priceFrom,
        priceTo
      };
      this.filter.emit(data);
    }
  }

  onClean() {
    if (this.form.valid) {
      this.form.reset();
      Object.keys(this.form.controls).forEach(key => {
        this.form.get(key)?.setValue("");
      });

      this.filter.emit(undefined);
    }
  }

  private toGreaterThanFromValidator(from: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

      if (!control.parent || !control) {
        return null;
      }

      if (!control.value || !control.parent.get(from)?.value) {
        return null;
      }

      const controlTo: number = +this.formatNumberService.clearValue(control.value);
      const controlFrom: number = +this.formatNumberService.clearValue(control.parent.get(from)?.value);

      if (controlFrom === 0 && controlFrom === controlTo) {
        return null;
      }

      if (controlTo > controlFrom) {
        return null;
      }

      return { toGreaterThanFrom: true };
    }
  }

  private atLeastOneValidator: ValidatorFn = (control: any): ValidationErrors | null => {

    if (!control) {
      return null;
    }

    const controls = control.controls;
    let theOne = Object.keys(controls).findIndex(key => controls[key].value !== '');

    if (theOne === -1) {
      return { atLeastOneRequired: true }
    }

    return null;

  }
}


