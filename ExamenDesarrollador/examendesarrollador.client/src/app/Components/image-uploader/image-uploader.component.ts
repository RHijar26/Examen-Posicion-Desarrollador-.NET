import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-image-uploader',
  standalone: false,
  templateUrl: './image-uploader.component.html',
  styleUrl: './image-uploader.component.css'
})
export class ImageUploaderComponent {
  

  @Input() image!: string | ArrayBuffer | null;  
  @Output() imageChange = new EventEmitter<string | ArrayBuffer | null>();

  onFileSelected(event: Event) {    
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();

      reader.onload = (e) => {

        this.image = (reader.result as string).split(',')[1];;        
        this.imageChange.emit(this.image); 
      };

      reader.readAsDataURL(file);
    } else {
      console.log('No file selected');
    }
  }

  cleanImage() {
    this.image = null;
    this.imageChange.emit(this.image); 
  }

  openInput() {
    const fileInput = document.getElementById('fileInput') as HTMLElement;
    if (fileInput) {
      fileInput.click();
    }
  }
}
