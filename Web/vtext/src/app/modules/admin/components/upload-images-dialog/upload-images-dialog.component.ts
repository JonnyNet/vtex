import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FileHelper } from 'src/app/modules/shared/Helpers/file-helper';

@Component({
  selector: 'app-upload-images-dialog',
  templateUrl: './upload-images-dialog.component.html',
  styleUrls: ['./upload-images-dialog.component.scss']
})
export class UploadImagesDialogComponent {

  files: File[] = [];
  baseDropValid: any;
  accept = "image/*";
  hasBaseDropZoneOver: boolean = false
  fileDropDisabled = false;
  dataFiles: string[] = [];

  constructor(public readonly dialogRef: MatDialogRef<UploadImagesDialogComponent>) { }

  LoadFile(data: any): void {
    data.forEach(async (file: File) => {
      const data = await FileHelper.readFile(file);
      this.dataFiles.push(data);
    });
  }

  deleteFile(index: number): void {
    this.files.splice(index, 1);
    this.dataFiles.splice(index, 1);
  }

  onSubmit(): void {
    this.dialogRef.close(this.dataFiles);
  }
}
