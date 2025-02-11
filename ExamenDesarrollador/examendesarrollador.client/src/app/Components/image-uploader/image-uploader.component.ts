import { Component } from '@angular/core';

@Component({
  selector: 'app-image-uploader',
  standalone: false,
  templateUrl: './image-uploader.component.html',
  styleUrl: './image-uploader.component.css'
})
export class ImageUploaderComponent {

  imageUrl: string | ArrayBuffer | null = null;

  onFileSelected(event: Event) {
    console.log('onFileSelected triggered', event);
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();

      reader.onload = (e) => {
        console.log('File loaded', e);
        this.imageUrl = reader.result;
      };

      reader.readAsDataURL(file);
    } else {
      console.log('No file selected');
    }
  }
}
