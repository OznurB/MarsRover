using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarsRover.Application.Contract.Models;
using MarsRover.Application.Contract.ServiceInterfaces;

namespace MarsRover.Web.Controllers
{
    public class RoverController : Controller
    {
        private readonly IPlateauService _plateauService;
        private readonly IRoverService _roverService;

        public RoverController(IPlateauService plateauService,
                               IRoverService roverService)
        {
            _plateauService = plateauService;
            _roverService = roverService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(Plateau plateau)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _plateauService.IsValidSize(plateau.PlateauSize);

                    _plateauService.CreatePlateau(plateau);

                    _roverService.ExecuteCommand(plateau);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(plateau);
        }
    }
}