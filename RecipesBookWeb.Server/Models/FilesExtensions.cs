using System.ComponentModel.DataAnnotations;

namespace RecipesBookWeb.Server.Models
{
    /// <summary>
    /// A custom validation attribute that checks if a collection of file names contains files with a specific extension.
    /// </summary>
    /// <remarks>
    /// This attribute is used to ensure that all files in a collection have the specified extension.
    /// It is derived from the <see cref="ValidationAttribute"/> base class and overrides the <see cref="IsValid"/> method to perform the validation logic.
    /// </remarks>
    public class FilesExtensions : ValidationAttribute
    {
        readonly string extension;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesExtensions"/> class.
        /// </summary>
        /// <param name="extension">The file extension that should be present in all files in the collection.</param>
        public FilesExtensions(string extension)
        {
            this.extension = extension;
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>A <see cref="ValidationResult"/> instance that contains the result of the validation.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = value.ToString();

            if (value is IEnumerable<string> files)
            {
                List<string> collection = (List<string>) value;

                if ( collection != null )
                {
                    foreach (var item in collection)
                    {
                        if (item.Length > 0)
                        {
                            if (!item.Contains(extension))
                            {
                                return new ValidationResult($"The field {item} has an invalid file extension.");
                            }
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
