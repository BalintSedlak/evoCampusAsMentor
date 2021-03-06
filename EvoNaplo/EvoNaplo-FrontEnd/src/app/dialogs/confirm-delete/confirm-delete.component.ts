import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.scss']
})
export class ConfirmDeleteComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public ConfirmDeleteDialogeMessage, public dialogRef: MatDialogRef<ConfirmDeleteComponent>) { }

  ngOnInit(): void {
  }

  closeDialog(){
    this.dialogRef.close(false);
  }

}
