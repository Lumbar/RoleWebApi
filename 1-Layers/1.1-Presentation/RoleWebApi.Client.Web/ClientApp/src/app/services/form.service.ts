import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';

//https://medium.com/@luukgruijs/validating-reactive-forms-with-default-and-custom-form-field-validators-in-angular-5586dc51c4ae
@Injectable()
export class FormService {

  // get all values of the formGroup, loop over them
  // then mark each field as touched
  public markFormGroupTouched(formGroup: FormGroup) {

    var values = Object.keys(formGroup['controls']).map(function (e) {
      return formGroup['controls'][e]
    });

    //Object.values(formGroup['controls']).forEach(control => {
    values.forEach(control => {
      control.markAsTouched();

      //if (control.controls) {
      if (control['controls']) {
        control['controls'].forEach(c => this.markFormGroupTouched(c));
      }
    });
  }

  // return list of error messages
  public validationMessages() {
    const messages = {
      required: 'El campo es obligatorio',
      email: 'El email es incorrecto',
      invalid_characters: (matches: any[]) => {

        let matchedCharacters = matches;

        matchedCharacters = matchedCharacters.reduce((characterString, character, index) => {
          let string = characterString;
          string += character;

          if (matchedCharacters.length !== index + 1) {
            string += ', ';
          }

          return string;
        }, '');

        return `Los siguientes caracteres no están permitidos: ${matchedCharacters}`;
      },
    };

    return messages;
  }

  // Validate form instance
  // check_dirty true will only emit errors if the field is touched
  // check_dirty false will check all fields independent of
  // being touched or not. Use this as the last check before submitting
  public validateForm(formToValidate: FormGroup, formErrors: any, checkDirty?: boolean) {
    const form = formToValidate;

    for (const field in formErrors) {
      if (field) {
        formErrors[field] = '';
        const control = form.get(field);

        const messages = this.validationMessages();
        if (control && !control.valid) {
          if (!checkDirty || (control.dirty || control.touched)) {
            for (const key in control.errors) {
              if (key && key !== 'invalid_characters') {
                formErrors[field] = formErrors[field] || messages[key];
              } else {
                formErrors[field] = formErrors[field] || messages[key](control.errors[key]);
              }
            }
          }
        }
      }
    }

    return formErrors;
  }
}
