using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_P.Models;

namespace WebApplication_P.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TblDoctorsController : Controller
    {
        private readonly doctorContext _context;

        public TblDoctorsController(doctorContext context)
        {
            _context = context;
        }




        [HttpGet]
        public IEnumerable<Tbldoctor> GetDoctors()
        {
            return _context.Tbldoctors;
        }


        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var TblDoctor = await _context.Tbldoctors.FindAsync(id);
            if (TblDoctor == null)
            {
                return NotFound();
            }

            _context.Tbldoctors.Remove(TblDoctor);
            await _context.SaveChangesAsync();

            return Ok(TblDoctor);
        }

        private bool DoctorExists(int id)
        {
            return _context.Tbldoctors.Any(e => e.Id == id);
        }
    }
}


