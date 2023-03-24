using MagiVillaAPI.Data;
using MagiVillaAPI.Dtos;
using MagiVillaAPI.Logging;
using Microsoft.AspNetCore.Mvc;

namespace MagiVillaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogging _logger;
        public VillaController(ILogging logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.Log("Getting all the villas.", "");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "Get Villa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log("The villa with id "+id+" does not exist and you entered wrong id.", "error");
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(e => e.Id == id);
            if (villa == null)
                return NotFound();
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla(VillaDTO villaDTO)
        {
            if (villaDTO == null)
                return BadRequest(villaDTO);
            if (villaDTO.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);
            villaDTO.Id = VillaStore.villaList.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);
            return CreatedAtRoute("Get Villa", new { id = villaDTO.Id }, villaDTO);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == null) return NotFound();
            var villa = VillaStore.villaList.FirstOrDefault(e => e.Id == id);
            if (villa == null) return NotFound();
            VillaStore.villaList.Remove(villa);
            return NoContent();
            
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, VillaDTO villaDTO)
        { 
            if((villaDTO == null) || (id != villaDTO.Id))
                    return BadRequest();
            var villa = VillaStore.villaList.FirstOrDefault(e => e.Id == id);

            villa.Name = villaDTO.Name;
            return NoContent();
        }
    }
}
