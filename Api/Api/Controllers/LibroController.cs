using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Api.Controllers
{

    [Route("[controller]")]

    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
                
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                  _libroService.GetAll()
                );  

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                   _libroService.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Libro model)
        {
            return Ok(
                    _libroService.Add(model)
                ) ;
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Libro model)
        {
            return Ok(
                     _libroService.Add(model)
                ); 

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                    _libroService.Delete(id)
                ) ;

        }
    }
}
