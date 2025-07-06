import { Component } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [FormsModule], // ✅ This is essential
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {
  onSubmit(form: NgForm) {
    const { name, email, message } = form.value;
    const formattedMessage = `
  ✅ Form Submitted Successfully!
  
  👤 Name: ${name}
  📧 Email: ${email}
  💬 Message:
  ${message}
    `;
    alert(formattedMessage);
    form.resetForm();
  }
  
  // onSubmit(form: NgForm) {
  //   alert('Form Submitted!\n' + JSON.stringify(form.value));
  //   form.resetForm();
  // }
}
