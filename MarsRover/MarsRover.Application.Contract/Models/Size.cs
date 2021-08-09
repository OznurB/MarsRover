using System.ComponentModel.DataAnnotations;

namespace MarsRover.Application.Contract.Models
{
    public class Size
    {
        [Display(Name = "Width")]
        public int Width { get; set; }

        [Display(Name = "Heigth")]
        public int Height { get; set; }

    }
}
