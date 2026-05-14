using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientServiceAPI.DTOs;
using PatientServiceAPI.Services;

namespace PatientServiceAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("GetAllPatients")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddPatient")]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> Add(CreatePatientDto createPatientDto)
        {
            try
            {
                await _patientService.CreatePatientAsync(createPatientDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        [HttpDelete("DeletePatientById/{id}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            try
            {
                await _patientService.DeletePatientAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetPatientById/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        [HttpPut("UpdatePatientById/{id}")]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto updatePatientDto)
        {
            try
            {
                await _patientService.UpdatePatientAsync(id, updatePatientDto);
                return Ok(updatePatientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpGet("GetPatientByName/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var patient = await _patientService.GetPatientByNameAsync(name);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
    }
}
