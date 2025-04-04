/*
* Antonio De Rosa - Validazione Form
*/


// Aggiungo le regex come metodo di validazione al form.
$.validator.addMethod("nameSurname", function(value, element) {
    return this.optional(element) || /^[a-zA-Z]{3,25}$/.test(value); // Regex per il nome
}, "Nome o Cognome non valido (Caratteri consentiti: a-z, A-Z)");

$.validator.addMethod("customEmail", function(value, element) {
    return this.optional(element) || /^[a-zA-Z0-9]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$/.test(value); // Regex per l'email
}, "Email non valida");

$.validator.addMethod("usernameRule", function(value, element) {
    return this.optional(element) || /^[a-zA-Z0-9]{8,16}$/.test(value);
}, "Nome utente non valido (Caratteri consentiti: a-z, A-Z, 0-9, Minimo 8 caratteri, massimo 16)"); // Regex per lo username

$.validator.addMethod("passwordRule", function(value, element) {
    return this.optional(element) || /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})/.test(value); // Regex per password
}, "Password non valida (Minimo 8 caratteri, almeno una lettera maiuscola, una minuscola, un numero e un carattere speciale)");

$.validator.addMethod("validBirthdate", function(value, element) {
    const date = new Date(value);
    const minDate = new Date(element.min);
    const maxDate = new Date(element.max);
    return this.optional(element) || (date >= minDate && date <= maxDate);
}, "Data di Nascita non valida (Deve essere tra il 1905-01-01 e il 2011-12-31)"); // Validazione data di nascita

// Gestisco la validazione del form usando Jquery Validate.
$(document).ready(function() {
    $('#form').validate({
        // Imposta le regole di validazione per i campi del form.
        rules: {
            name: {
                required: true,
                nameSurname: true // Regex per il nome
            },
            surname: {
                required: true,
                nameSurname: true // Regex per il cognome
            },
            birthdate: {
                required: true,
                validBirthdate: true // Regex per la data di nascita
            },
            email: {
                required: true,
                customEmail: true // Regex per l'email
            },
            username: {
                required: true,
                usernameRule: true // regex per il nome utente
            },
            password: {
                required: true,
                passwordRule: true // Regex per la password
            }
        },
        errorPlacement: function(error, element) {
            error.appendTo(element.closest('.mb-3').find('.error-message')); // Gestisce la visualizzazione degli errori
        },
        highlight: function(element) {
            $(element).addClass('is-invalid').removeClass('is-valid'); // Aggiungi la visualizzazione degli highlight
        },
        unhighlight: function(element) {
            $(element).removeClass('is-invalid').addClass('is-valid'); // Toglie la visualizzazione degli highlight 
        },
        invalidHandler: function(event, validator) {
            // Gestisce la visualizzazione degli errori
            $('#form-errors').removeClass('d-none').html(
                'Per favore correggi gli errori evidenziati nel modulo.'
            );
        },
        submitHandler: function(form) {
            // Gestisce il submit del form
            $('#form-errors').addClass('d-none').empty();
            form.submit();
        }
    });
});