﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppTrackerAPI.Models;
using AppTrackerAPI.Services;

namespace AppTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;

        public ApplicationController(ApplicationService service)
        {
            _service = service;
        }

        [HttpGet("GetAllApplications")]
        public async Task<IActionResult> GetAllApplications()
        {
            var apps = await _service.GetAllApplications();
            return Ok(apps);
        }

        [HttpGet("GetApplicationById/{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var app = await _service.GetApplicationById(id);
            return app != null ? Ok(app) : NotFound();
        }

        [HttpPost("CreateApplication")]
        public async Task<IActionResult> CreateApplication([FromBody] Application application)
        {
            await _service.CreateApplication(application);
            return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
        }

        [HttpPut("UpdateApplication")]
        public async Task<IActionResult> UpdateApplication([FromBody] Application application)
        {
            await _service.UpdateApplication(application);
            return NoContent();
        }

        [HttpDelete("RemoveApplication/{id}")]
        public async Task<IActionResult> RemoveApplication(int id)
        {
            await _service.DeleteApplication(id);
            return NoContent();
        }
    }

}
