using Microsoft.AspNetCore.Mvc;
using DSV.Models;
using DSV.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DSV.Controllers
{
    [ApiController]
    [Route("v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;
        public MovieController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie movie)
        {
            if (MovieExists(movie)){
                return StatusCode(400);
            }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }


        [HttpGet]
        public async Task<IActionResult> List() => Ok(await _context.Movies.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return StatusCode(404);
            }
            return Ok(movie);
            
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Movie movie)
        {
            if (!MovieExistsById(movie)){
                return StatusCode(400);
            }
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            
            return StatusCode(204);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return StatusCode(404);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool MovieExists(Movie movie) =>  _context.Movies.Any(m => m.Name == movie.Name);
        private bool MovieExistsById(Movie movie) =>  _context.Movies.Any(m => m.Id == movie.Id);
    }
}