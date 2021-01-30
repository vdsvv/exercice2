import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData, DialogType } from 'src/app/helpers/dialog-data';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.service';

@Component({
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent implements OnInit {
  
  constructor(
      private dialogRef: MatDialogRef<UserDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public dialogData : DialogData<User> ) {
  }

  ngOnInit() {
    
  }

  close() {
      this.dialogRef.close();
  }

}
