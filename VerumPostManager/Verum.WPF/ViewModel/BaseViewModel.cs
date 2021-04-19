using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.WPF.Models;

namespace Verum.WPF.ViewModel
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;
    public class BaseViewModel : ObservableObject, IDataErrorInfo
    {
        public virtual ValidationResult SelfValidate()
        {
            return new ValidationResult();
        }
        private string GetValidationError(string property = null)
        {
            var validationResult = SelfValidate();
            if (validationResult == null || validationResult.IsValid)
            {
                IsValid = true;
                return string.Empty;
            }
            IsValid = false;
            if (property == null)
            {
                return string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
            }
            else
            {
                var results = validationResult.Errors.FirstOrDefault(e => e.PropertyName == property);
                return results != null ? results.ErrorMessage : string.Empty;
            }
        }
        public string Error
        {
            get
            {
                return GetValidationError();
            }
        }
        public string this[string property]
        {
            get
            {
                return GetValidationError(property);
            }
        }
        public bool IsValid { get; private set; }
        protected bool Validate()
        {
            IsValid = SelfValidate().IsValid;
            return IsValid;
        }
    }
}
