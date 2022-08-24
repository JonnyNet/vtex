import { Injectable } from '@angular/core';
import { FormatNumber } from 'src/app/core/models';

@Injectable({
  providedIn: 'root'
})
export class FormatNumberService {

  currency(value: string, hasSimbol: boolean = false, chunkLength: number = 3, chunkDelimiter: string = ','): FormatNumber {
    const newValue = this.clearValue(value);
    const regex = `\\d(?=(\\d{${chunkLength}})+$)`;
    const result = newValue.replace(new RegExp(regex, 'g'), `$&${chunkDelimiter}`);
    const simbol = result.length > 0 && hasSimbol ? '$' : '';
    return { clearValue: newValue, format: `${simbol}${result}` };
  }

  clearValue(value: string): string {
    const newValue = value.toString().replace(/\D/g, '').replace(/^0+/, '').substring(0, 11);
    return newValue;
  }
}
