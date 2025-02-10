using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Models
{
    public class LocalizedMinLengthAttribute : MinLengthAttribute
    {
        public LocalizedMinLengthAttribute(int length, string displayName) : base(length)
        {
            DisplayName = displayName;
            this.ErrorMessage = FormatErrorMessage(DisplayName);
        }

        public string DisplayName { get; set; }



        public override string FormatErrorMessage(string whatever)
        {
            var errorMessage = ModelLocalizer.L(DisplayName);
            return errorMessage;
        }


    }

    public class LocalizedMaxLengthAttribute : ValidationAttribute, IClientModelValidator
    {
        private int MaxLength { get; set; }
        private string DisplayName { get; set; } = "";
        public LocalizedMaxLengthAttribute(int length, string displayName) : base()
        {
            this.DisplayName = displayName;
            this.ErrorMessage = FormatErrorMessage(displayName);
            this.MaxLength = length;
        }

        public override string FormatErrorMessage(string whatever)
        {
            return ModelLocalizer.L(DisplayName, MaxLength);
        }

        public override bool IsValid(object? value)
        {
            var valueAsString = Convert.ToString(value) ?? string.Empty;
            return (valueAsString.Length < MaxLength);
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(this.DisplayName);
            MergeAttribute(context.Attributes, "data-val-withmaxlengthinput", errorMessage);
            MergeAttribute(context.Attributes, "data-val-maxLength", this.MaxLength.ToString());
        }

        private static bool MergeAttribute(
            IDictionary<string, string> attributes,
            string key,
            string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }

    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public string DisplayName { get; set; }

        public LocalizedRequiredAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public override string FormatErrorMessage(string whatever)
        {
            var errorMessage = ModelLocalizer.L("isRequired", ModelLocalizer.L(DisplayName));
            return errorMessage;
        }


    }

    public class LocalizedRangeAttribute : RangeAttribute
    {
        public LocalizedRangeAttribute(double minimum, double maximum, string displayName) : base(minimum, maximum)
        {
            this.DisplayName = displayName;
            this.ErrorMessage = FormatErrorMessage(DisplayName);
        }

        public string DisplayName { get; set; }


        public override string FormatErrorMessage(string whatever)
        {
            var errorMessage = (ModelLocalizer.L(DisplayName));
            return errorMessage;
        }


    }

    public class LocalizedDisplayAttribute : DisplayNameAttribute
    {
        private readonly string _displayName;

        public LocalizedDisplayAttribute(string displayName)
        {
            _displayName = displayName;
        }

        public override string DisplayName
        {
            get { return ModelLocalizer.L(_displayName); }
        }
    }

    public class LocalizedCompareAttribute : CompareAttribute
    {
        public LocalizedCompareAttribute(string otherProperty, string displayName) : base(otherProperty)
        {
            this.DisplayName = displayName;
            this.ErrorMessage = FormatErrorMessage(DisplayName);
        }

        private string DisplayName { get; set; } = "";
        public override string FormatErrorMessage(string whatever)
        {
            return ModelLocalizer.L(DisplayName);
        }
    }


    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class LocalizedPlaceholderAttribute : Attribute
    {
        public LocalizedPlaceholderAttribute(string displayName)
        {
            Value = ModelLocalizer.L(displayName);
        }
        public string Value { get; set; }
    }


    public class LocalizedRegExpAttribute : RegularExpressionAttribute
    {
        public LocalizedRegExpAttribute(string pattern, string displayName) : base(pattern)
        {
            DisplayName = displayName;
            ErrorMessage = FormatErrorMessage(displayName);
        }

        private string DisplayName { get; set; } = "";
        public override string FormatErrorMessage(string whatever)
        {
            return ModelLocalizer.L(DisplayName);
        }
    }

}
