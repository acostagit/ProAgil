using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoAgil.API.Data;
using ProjetoAgil.API.Models;

namespace ProjetoAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }
     
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falhou");   
            }
                
            // return new Evento[]{
            //     new Evento(){
            //         EventoId = 1,
            //         Tema = "DotNet Core e Angular",
            //         Local = "Sao Paulo",
            //         Lote = "Lote 1",
            //         QtdePessoas = 20,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            //     },
            //     new Evento(){
            //         EventoId = 2,
            //         Tema = "DotNet Core e Angular",
            //         Local = "Belo Horizonte",
            //         Lote = "Lote 2",
            //         QtdePessoas = 420,
            //         DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy")
            //     }
            // };            
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
            {
                 var result = await _context.Eventos.FirstOrDefaultAsync(e => e.EventoId == id);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falhou");   
            }
            // return new Evento[]{
            //     new Evento(){
            //         EventoId = 1,
            //         Tema = "DotNet Core e Angular",
            //         Local = "Sao Paulo",
            //         Lote = "Lote 1",
            //         QtdePessoas = 20,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            //     },
            //     new Evento(){
            //         EventoId = 2,
            //         Tema = "DotNet Core e Angular",
            //         Local = "Belo Horizonte",
            //         Lote = "Lote 2",
            //         QtdePessoas = 420,
            //         DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy")
            //     }
            // }.FirstOrDefault(x => x.EventoId == id);            
        }

    }
}
