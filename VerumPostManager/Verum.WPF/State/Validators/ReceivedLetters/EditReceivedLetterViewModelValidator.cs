﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.ViewModel;

namespace Verum.WPF.State.Validators.ReceivedLetters
{
    public class EditReceivedLetterViewModelValidator : AbstractValidator<EditReceivedLetterViewModel>
    {
        public EditReceivedLetterViewModelValidator()
        {
            RuleFor(x => x.Content)
               .NotEmpty()
               .WithMessage("Pole 'Treść' nie może być puste!")
               .Must(x => x?.Length <= 400)
               .WithMessage("Maksymalna liczba znaków: 400");

            RuleFor(x => x.Comment)
                .NotEmpty()
                .WithMessage("Pole 'Komentarz' nie może być puste!")
                .Must(x => x?.Length <= 400)
                .WithMessage("Maksymalna liczba znaków: 400");

            RuleFor(x => x.Attachment)
               .NotEmpty()
               .WithMessage("Pole 'Załącznik' nie może być puste!")
               .Must(x => x?.Length <= 400)
                .WithMessage("Maksymalna liczba znaków: 400");

            RuleFor(x => x.Sender)
               .NotNull()
               .WithMessage("Pole 'Nadawca' nie może być puste!");

            RuleFor(x => x.Recipient)
               .NotNull()
               .WithMessage("Pole 'Odbiorca' nie może być puste!");

            RuleFor(x => x.Employee)
               .NotNull()
               .WithMessage("Pole 'Pracownik' nie może być puste!");

            RuleFor(x => x.Date)
               .NotNull()
               .WithMessage("Pole 'Data' nie może być puste!");
        }
    }
}