import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-search-client',
  standalone: false,
  templateUrl: './search-client.component.html',
  styleUrl: './search-client.component.css'
})
export class SearchClientComponent {
  constructor(private dialogRef: MatDialogRef<SearchClientComponent>) { }

  close() {
    this.dialogRef.close();
  }

  confirm() {
    console.log("Confirmed!");
    this.dialogRef.close();
  }
}
