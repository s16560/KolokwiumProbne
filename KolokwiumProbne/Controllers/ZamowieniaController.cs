using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolokwiumProbne.DTO;
using KolokwiumProbne.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumProbne.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class ZamowieniaController : ControllerBase
    {
        private readonly ICukierniaDbService _context;

        public ZamowieniaController(ICukierniaDbService context) {
            _context = context;
        }

        [HttpGet("{nazwisko}")]
        public IActionResult pobierzListeZamowien(string nazwisko)
        {
            var response = _context.PobierzZamowienia(nazwisko);
            return Ok(response);
        }

        [HttpGet()]
        public IActionResult pobierzListeZamowien()
        {
            var response = _context.PobierzZamowienia(null);
            return Ok(response);
        }

        [HttpPost("client/{idKlienta}")]
        public IActionResult DodajZamowienie(int idKlienta, DodanieZamowieniaRequest request)
        {
            var response = _context.DodajZamowienie(idKlienta, request);
            return Created("Dodano zamowienie", response);
        }
    }
}