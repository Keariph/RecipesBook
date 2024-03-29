using System.ComponentModel.DataAnnotations;

namespace RecipesBookWeb.Server.Models
{
    /// <summary>
    /// A custom validation attribute that checks for invalid characters in a string.
    /// </summary>
    /// <remarks>
    /// This attribute is used to ensure that a string does not contain any of the specified invalid characters.
    /// It is derived from the <see cref="ValidationAttribute"/> base class and overrides the <see cref="IsValid"/> method to perform the validation logic.
    /// </remarks>
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string invalidChars;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCharsAttribute"/> class.
        /// </summary>
        /// <param name="invalidChars">A string containing the invalid characters that should not be present in the validated string.</param>
        public InvalidCharsAttribute(string invalidChars)
        {
            this.invalidChars = invalidChars;
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>A <see cref="ValidationResult"/> instance that contains the result of the validation.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();

                foreach (char c in invalidChars)
                {
                    if (stringValue.Contains(c))
                    {
                        return new ValidationResult($"The field {validationContext.DisplayName} contains unacceptable characters.");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
