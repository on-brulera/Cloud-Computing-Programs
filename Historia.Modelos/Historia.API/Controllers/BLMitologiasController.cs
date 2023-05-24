using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Historia.Modelos;

namespace Historia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLMitologiasController : ControllerBase
    {
        private readonly DataContext _context;

        public BLMitologiasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DALMitologia
        [Route("/BL/NumeroDioses")]
        [HttpGet]
        public ActionResult<int> NumeroDioses()
        {
            if (_context.Dioses == null)
            {
                return NotFound();
            }
            var numDioses = _context.Dioses.ToArray();
            return numDioses.GetLength(0);
        }

        [Route("/BL/NumeroDiosesById")]
        [HttpGet]
        public ActionResult<int> NumeroDiosesById(int mitologiaId)
        {
            if (_context.Dioses == null)
            {
                return NotFound();
            }
            var numDioses = _context.Dioses.Where(d=>d.MitologiaId == mitologiaId).ToArray();
            return numDioses.Length;
        }
    }
}
