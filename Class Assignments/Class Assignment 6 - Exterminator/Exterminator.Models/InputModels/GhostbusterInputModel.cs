using System.ComponentModel.DataAnnotations;
using Exterminator.Models.Attributes;

namespace Exterminator.Models.InputModels
{
    public class GhostbusterInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Expertize]
        public string Expertize { get; set; }
    }
}