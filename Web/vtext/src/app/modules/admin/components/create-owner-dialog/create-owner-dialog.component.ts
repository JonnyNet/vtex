import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Owner } from 'src/app/core/models';
import { FileHelper } from 'src/app/modules/shared/Helpers/file-helper';

@Component({
  selector: 'app-create-owner-dialog',
  templateUrl: './create-owner-dialog.component.html',
  styleUrls: ['./create-owner-dialog.component.scss']
})
export class CreateOwnerDialogComponent {

  form!: FormGroup;

  constructor(
    public readonly dialogRef: MatDialogRef<CreateOwnerDialogComponent>,
    private readonly _formBuilder: FormBuilder) {
    this.form = this._formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      address: ['', [Validators.maxLength(100)]],
      photo: [''],
      birthday: ['', Validators.required]
    });
  }

  async getDataFileAsyn(target: any, tag: any) {
    const file = target.files[0];
    tag.innerHTML = file.name;
    const data = await FileHelper.readFile(file);
    console.log(data);

    this.form.get('photo')?.setValue(data);
  }

  onSubmit() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value as Owner);
    }
  }
}
