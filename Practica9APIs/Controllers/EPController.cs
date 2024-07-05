using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica9APIs.Datos;
using Practica9APIs.Modelos;
using Practica9APIs.Modelos.Dto;
using System.Reflection.PortableExecutable;

namespace Practica9APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPDtoController : ControllerBase
    {
        //[HttpGet]//Retorna una lista
        //public IEnumerable<EPDto> GetEPDto()
        //{
        //    //Ejercicio 1
        //    //return new List<EP>
        //    //{
        //    //    new EP{Id=1, Nombre="Vista a la piscina"},
        //    //    new EP{Id=2, Nombre="Vista a la playa"}
        //    //};

        //    //Ejercicio 2
        //    //return new List<EPDto>
        //    //{
        //    //    new EPDto{Id=1, Nombre="Vista a la piscina"},
        //    //    new EPDto{Id=2, Nombre="Vista a la playa"}
        //    //};

        //    //Ejercicio 3
        //    return EPStore.EPList;
        //}

        //Ejercicio 4
        //[HttpGet("Id")]//Retorna un objeto. Hay que diferenciar los End Points
        //public EPDto GetEPDto(int Id)
        //{
        //    return EPStore.EPList.FirstOrDefault(a => a.Id == Id);
        //}

        //Ejercicio 5
        //[HttpGet]//Suplanta a los del ejercicio 1, 2 y 3 
        //public ActionResult<IEnumerable<EPDto>> GetEPDto()
        //{
        //    return Ok(EPStore.EPList);//Responde con un codigo de estado 200
        //}

        //[HttpGet("Id")]//Retorna un objeto. Hay que diferenciar los End Points. Suplanta el ejercicio 4
        //public ActionResult<EPDto> GetEPDto(int Id)
        //{
        //    if (Id == 0)
        //    {
        //        return BadRequest(); //Responde con un codigo de estado 400
        //    }

        //    var Ep= EPStore.EPList.FirstOrDefault(a => a.Id == Id);

        //    if (Ep == null)
        //    {
        //        return NotFound(); //Responde con un codigo de estado 404
        //    }

        //    return Ok(Ep);
        //}

        //Ejercicio 6
        //[HttpGet("Id")]//Retorna un objeto. Hay que diferenciar los End Points. Suplanta el ejercicio 4
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<EPDto> GetEPDto(int Id)
        //{
        //    if (Id == 0)
        //    {
        //        return BadRequest(); //Responde con un codigo de estado 400
        //    }

        //    var Ep = EPStore.EPList.FirstOrDefault(a => a.Id == Id);

        //    if (Ep == null)
        //    {
        //        return NotFound(); //Responde con un codigo de estado 404
        //    }

        //    return Ok(Ep);
        //}

        //Ejercicio 7
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EPDto>> GetEPDto()
        {
            return Ok(EPStore.EPList);//Responde con un codigo de estado 200
        }

        [HttpGet("Id", Name = "GetEp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EPDto> GetEPDto(int Id)
        {
            if (Id == 0)
            {
                return BadRequest(); //Responde con un codigo de estado 400
            }

            var Ep = EPStore.EPList.FirstOrDefault(a => a.Id == Id);

            if (Ep == null)
            {
                return NotFound(); //Responde con un codigo de estado 404
            }

            return Ok(Ep);
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public ActionResult<EPDto> CrearEPDto([FromBody] EPDto epdto) //[FromBody] indica recepcion de datos
        //{
        //    if (epdto == null)
        //    {
        //        return BadRequest(epdto);
        //    }
        //    if (epdto.Id>0)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    epdto.Id = EPStore.EPList.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
        //    EPStore.EPList.Add(epdto);
        //    return CreatedAtRoute("GetEP", new { id = epdto.Id }, epdto);
        //}

        //Ejercicio 7, g, h, i
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EPDto> CrearEPDto([FromBody] EPDto epdto) 
        {
            if (!ModelState.IsValid)//Si el modeo es valido
            {
                return BadRequest(ModelState);
            }
            if (EPStore.EPList.FirstOrDefault(v => v.Nombre.ToLower() == epdto.Nombre.ToLower()) != null)
            {
                // Validacion personalizada
                ModelState.AddModelError("NombreExiste", "Ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if (epdto == null)
            {
                return BadRequest(epdto);
            }

            if (epdto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            epdto.Id = EPStore.EPList.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
            EPStore.EPList.Add(epdto);
            return CreatedAtRoute("GetEP", new { id = epdto.Id }, epdto);
        }

        //Ejercicio 8
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEP(int id) // La interface IActionResult no le hace falta ya que devuelve un NoContent()
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var ep = EPStore.EPList.FirstOrDefault(v => v.Id == id);
            if (ep == null)
            {
                return NotFound();
            }

            EPStore.EPList.Remove(ep);
            return NoContent();
        }

        //HASTA ACA FUNCIONA TODO JOYA COMO EN EL PRACTICO








    }
}
