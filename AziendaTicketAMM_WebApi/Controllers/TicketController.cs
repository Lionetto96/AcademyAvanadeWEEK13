using AziendaTicketAMM_CORE.BusinessLayer;
using AziendaTicketAMM_CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AziendaTicketAMM_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IBusinessLayer bl;

        public TicketController(IBusinessLayer bl)
        {
            this.bl = bl;
        }

        /// <summary>
        /// AddTicket
        /// </summary>

        [HttpPost]
        public IActionResult AddTicket(Ticket newTicket)
        {
            if (newTicket == null)
                return BadRequest(); var okResult = bl.CreateTicket(newTicket);
            if (!okResult)
                return StatusCode(500, "internal server error ,ticket not created");
            return Ok(newTicket);


        }

        /// <summary>
        /// FetchTicket
        /// </summary>

        [HttpGet]
        public IActionResult FetchAllTicket()
        {
            return Ok(bl.FetchAllTicket());
        }

        [HttpGet("{id}")]
        public IActionResult FetchTicketById(int id)
        {
            var ticket = bl.FetchTicketById(id);
            if (ticket is null)
                return NotFound();
            return Ok(ticket);
        }
        /// <summary>
        /// AssegnazioneTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="stato"></param>
        /// <returns></returns>
        //[HttpPut("assegnazioneTicket")]
        //public IActionResult AssegnazioneTicket(Ticket ticket, Stato stato)
        //{
        //    if (ticket == null && stato == null)
        //        BadRequest();
        //    var tic = bl.Assegnazioneticket(ticket, stato);
        //    if (tic == false)
        //        return StatusCode(500, $"unable to update ticket {ticket}");

        //    return Ok(tic);
        //}
        /// <summary>
        /// UpdateTicket
        /// </summary>
        /// <param name="ticket"></param>

        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateTicket(Ticket ticket)
        {
            if (ticket == null )
                BadRequest();
            var tic = bl.UpdateTicket(ticket);
            if (tic == false)
                return StatusCode(500, $"unable to update ticket {ticket}");

            return Ok(tic);
        }

        /// <summary>
        /// ChiusuraTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="stato"></param>
        /// <returns></returns>
        //[HttpPut("chiusuraticket")]
        //public IActionResult ChiusuraTicket(Ticket ticket, Stato stato)
        //{
        //    if (ticket == null && stato == null)
        //        BadRequest();
        //    var tic = bl.ChiusuraTicket(ticket, stato);
        //    if (tic == false)
        //        return StatusCode(500, $"unable to update ticket {ticket}");

        //    return Ok(tic);
        //}

        /// <summary>
        /// AddStato
        /// </summary>
        [HttpPost("{newStato}")]
        public IActionResult AddStato(Stato newStato)
        {
            if (newStato == null)
                return BadRequest(); var okResult = bl.CreateStato(newStato);
            if (!okResult)
                return StatusCode(500, "internal server error ,stato not created");
            return Ok(newStato);


        }
        /// <summary>
        /// FetchStato
        /// </summary>

        [HttpGet("{AllStati}")]
        public IActionResult FetchAllStato()
        {
            return Ok(bl.FetchAllStati());
        }

        /// <summary>
        /// FetchStatoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("stato/{id}")]
        public IActionResult FetchStatoById(int id)
        {
            var stato = bl.FetchStatoById(id);
            if (stato is null)
                return NotFound();
            return Ok(stato);
        }

        /// <summary>
        /// DeleteStatoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("stato/{id}")]
        public IActionResult DeleteStato(int id)
        {
            var okDelete = bl.DeleteStatoById(id);
            if (!okDelete)
                return StatusCode(500, "Unable to delete Stato");
            return Ok();
        }

        /// <summary>
        /// UpdateStatoById
        /// </summary>
        /// <param name="idstato"></param>

        /// <returns></returns>
        [HttpPut("updateStato/{Id}")]
        public IActionResult UpdateStato(int idstato)
        {
            if (idstato <= 0)
                BadRequest();
            var stato = bl.UpdateStatoById(idstato);
            if (stato == false)
                return StatusCode(500, $"unable to update stato {idstato}");

            return Ok(stato);


        }

        /// <summary>
        /// FetchCategoria
        /// </summary>

        [HttpGet("allCategorie")]
        public IActionResult FetchAllCategoria()
        {
            return Ok(bl.FetchAllCategorie());

        }

        /// <summary>
        /// FetchCategoriaById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("categoria/{id}")]
        public IActionResult FetchCategoriaById(int id)
        {
            var categoria = bl.FetchCategoriaById(id);
            if (categoria is null)
                return NotFound();
            return Ok(categoria);
        }
        /// <summary>
        /// AddCategoria
        /// </summary>
        [HttpPost("newCategoria")]
        public IActionResult AddCategoria(Categoria newCategoria)
        {
            if (newCategoria == null)
                return BadRequest(); var okResult = bl.CreateCategoria(newCategoria);
            if (!okResult)
                return StatusCode(500, "internal server error ,categoria not created");
            return Ok(newCategoria);


        }

        /// <summary>
        /// DeleteCategoriaById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("categoria/{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var okDelete = bl.DeleteCategoriaById(id);
            if (!okDelete)
                return StatusCode(500, "Unable to delete Categoria");
            return Ok();
        }
        /// <summary>
        /// UpdateCategoriaById
        /// </summary>
        /// <param name="idcategoria"></param>

        /// <returns></returns>
        [HttpPut("categoria/{Id}")]
        public IActionResult UpdateCategoria(int idcategoria)
        {
            if (idcategoria <= 0)
                BadRequest();
            var ct = bl.UpdateCategoriaById(idcategoria);
            if (ct == false)
                return StatusCode(500, $"unable to update categoria {idcategoria}");

            return Ok(ct);

            
        }
    }
}
