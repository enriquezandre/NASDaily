using Microsoft.AspNetCore.Mvc;
using nas_daily_api.Dtos;
using nas_daily_api.Services;
using System.Collections.Generic;

namespace nas_daily_api.Controllers
{
    [Route("api/office")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet("{officeId}")]
        public IActionResult GetOfficeByOfficeId(string officeId)
        {
            var office = _officeService.GetOfficeByOfficeId(officeId);
            if (office == null)
                return NotFound();

            return Ok(office);
        }

        [HttpGet]
        public IActionResult GetAllOffices()
        {
            var allOffices = _officeService.GetAllOffices();
            return Ok(allOffices);
        }

        [HttpPost]
        public IActionResult CreateOffice(OfficeDto office)
        {
            var createdOffice = _officeService.CreateOffice(office);
            return CreatedAtAction(nameof(GetOfficeByOfficeId), new { officeId = createdOffice.OfficeId }, createdOffice);
        }

        [HttpPut("{officeId}")]
        public IActionResult UpdateOffice(string officeId, OfficeDto office)
        {
            _officeService.UpdateOffice(officeId, office);
            return NoContent();
        }

        [HttpDelete("{officeId}")]
        public IActionResult DeleteOffice(string officeId)
        {
            _officeService.DeleteOffice(officeId);
            return NoContent();
        }
    }
}