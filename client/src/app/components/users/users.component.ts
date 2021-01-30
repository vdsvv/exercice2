import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { DialogData, DialogType } from 'src/app/helpers/dialog-data';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.service';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';

@Component({
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  dataSource: MatTableDataSource<User>;

  constructor(private usersService: UsersService,
              private dialog: MatDialog, 
              private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.usersService.getUsers().subscribe((users: User[]) => {
      this.dataSource = new MatTableDataSource<User>(users)
    })
  }

  addUser() {
    let user : User = {id:"", firstName:"", middleName:"", lastName:""}
    let dd: DialogData<User> = {dialogType: DialogType.Add, title:"Add user", selectedAction:"", data:user}
    this.openDialog(dd)
  }

  updateUser(user: User) {
    let userCopy = { ...user }
    let dd: DialogData<User> = {dialogType: DialogType.Update, title:"Edit user", selectedAction:"", data:userCopy}
    this.openDialog(dd)
  }

  deleteUser(user: User) {
    this.usersService.deleteUser(user)
        .subscribe(() => {
          this.dataSource.data = this.dataSource.data.filter(x => x.id !== user.id);
      });
  }

  openDialog(dd: DialogData<User>) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = dd;
    dialogConfig.width = '400px';
    const dialogRef = this.dialog.open(UserDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined){
        return
      }

      if (dd.dialogType === DialogType.Add){
        this.usersService.addUser(result as User)
          .subscribe((user) => {
            this.dataSource.data.push(user)
        },
        (err) => {
          console.error(err)
          this.showError("Unable to add new user")
        });
      }

      if (dd.dialogType === DialogType.Update){
        this.usersService.updateUser(result as User)
          .subscribe((user) => {
            let index = this.dataSource.data.findIndex(x => x.id == user.id)
            this.dataSource.data[index] = user
            //this.table.renderRows()
        },
        (err) => {
          console.error(err)
          this.showError("Unable to edit user")
        });
      }
    });
  }

  showError(message: string, action: string = "Close") {
    this._snackBar.open(message, action, { duration: 5000, });
  }
}
