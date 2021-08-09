using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarsRover.Application.Contract.Models
{
    public class Plateau
    {
        [Required]
        public Size PlateauSize { get; set; }

        [Required]
        public List<Rover> RoverList { get; set; }
    }
}
