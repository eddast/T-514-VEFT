using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Exterminator.Models.InputModels;

namespace Exterminator.Models.Attributes
{
    /// <summary>
    /// Validation mechanism for the expertize attribute in GhostbusterInputModel
    /// </summary>
    public class Expertize : ValidationAttribute
    {

        /// <summary>
        /// List of valid expertizes in system
        /// </summary>
        private readonly IList<string> _validExpertizes =
            new List<string> {"Ghost catcher", "Monster encager", "Zombie exploder"}.AsReadOnly();

        /// <summary>
        /// Empty ctor
        /// </summary>
        public Expertize()
        {

        }

        /// <summary>
        /// Determines if provided expertize for model is valid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>Validation result - indicates success if expertize property was valid otherwise failure</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GhostbusterInputModel ghostbuster = (GhostbusterInputModel)validationContext.ObjectInstance;
            if(_validExpertizes.FirstOrDefault(x => x == ghostbuster.Expertize) == null)
            {
                return new ValidationResult(GetErrorMessage(ghostbuster.Expertize));
            }
            else return ValidationResult.Success;
        }

        /// <summary>
        /// Gets error message if expertize is invalid
        /// </summary>
        /// <returns>explicit error message if expertize is invalid</returns>
        private string GetErrorMessage(string providedExpertize) =>
            "Provided expertize '" + providedExpertize + "' is not a valid expertize.";
    }
}