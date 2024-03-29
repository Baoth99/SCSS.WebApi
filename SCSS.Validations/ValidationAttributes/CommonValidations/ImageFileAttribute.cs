﻿using Microsoft.AspNetCore.Http;
using SCSS.Utilities.Constants;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace SCSS.Validations.ValidationAttributes.CommonValidations
{
    public class ImageFileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(InvalidFileCode.Null);
            }

            var imageFile = value as IFormFile;

            var extension = Path.GetExtension(imageFile.FileName);

            if (!CollectionConstants.ImageExtensions.Contains(extension.ToLower()))
            {
                return new ValidationResult(InvalidFileCode.Extension);
            }

            //if (imageFile.Length > 500)
            //{
            //    return new ValidationResult(InvalidFileCode.Size);
            //}

            if (imageFile.Name.Contains("/") || imageFile.Name.Length > 50)
            {
                return new ValidationResult(InvalidFileCode.Name);
            }

            return ValidationResult.Success;
        }
    }
}
