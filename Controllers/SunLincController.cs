using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OntimeBackEnd.Models;
using OntimeBackEnd.Service;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace OntimeBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunLincController : ControllerBase
    {
        private readonly ISunLincInterface _sunlincInterface;
        public Validator _validator = new Validator();
        public SunLincController(ISunLincInterface onTimeInterface)
        {
            _sunlincInterface = onTimeInterface;
        }

        [HttpGet("getrecord")]
        public async Task<IActionResult> GetRecord()
        {
            var responce = await _sunlincInterface.GetRecord();
            if(responce.StudentModelRequest == null)
            {
                responce.IsSuccess = false;
                responce.Message = "Failed to fetch Data From Database";
            }

            return Ok(responce);
        }

        [HttpGet("getrecordbyprn")]//route
        public async Task<IActionResult> GetRecordByPRN([FromQuery] string prn)
        {
            var response = await _sunlincInterface.GetRecordByPRN(prn); 
            //if(response.StudentModelRequest == null)
            //{
            //    response.IsSuccess = false;
            //    response.Message = "Failed to fetch Data From Database";
            //}
            
            return Ok(response);
        }

        [HttpGet("getrecordbycredential")]
        public async Task<IActionResult> GetRecordByCredential([FromQuery] string prn, [FromQuery] string password)
        {
            var response = await _sunlincInterface.GetRecordByCredential(prn, password);
            return Ok(response);
        }

        [HttpGet("getrecordbydepartment")]
        public async Task<IActionResult> GetRecordByDepartment([FromQuery] string department)
        {
            var response = await _sunlincInterface.GetRecordByDepartment(department);
            Debug.WriteLine("success");
            if (response.StudentModelRequest.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "You have Select Wrong Department!";
            }
            return Ok(response);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecord(StudentModelRequest request)
        {
            StudentModelResponse response = new StudentModelResponse();
            response =await _validator.ValidateStudentRequest(request);
            if (string.IsNullOrEmpty(response.Message))
            {
                 response = await _sunlincInterface.InsertRecord(request);
            }
            return Ok(response);
        }

        [HttpDelete("deleteprn")]
        public async Task<IActionResult> DeleteRecordByPrn([FromQuery] string prn)
        {
            var response = await _sunlincInterface.DeleteRecordByPrn(prn);
            return Ok(response);
        }

        [HttpGet("attencance")]
        public async Task<IActionResult> UpdateAttendanceByPrn([FromQuery] string date, [FromQuery] string prn)
        {
            var response = await _sunlincInterface.UpdateAttendanceByPrn(date,prn); 
            return Ok(response);
        }

        [HttpGet("getstaff")]
        public async Task<IActionResult> GetStaffRecordByCredentials([FromQuery] string id, [FromQuery] string password)
        {
           var response = await _sunlincInterface.GetStaffRecordByCredential(id, password);
           return Ok(response);
        }
        [HttpGet("batch")]
        public async Task<IActionResult> GetRecordsByBatch([FromQuery] string batch)
        {
            var response = await _sunlincInterface.GetRecordsByBatch(batch);
            Debug.WriteLine("success");
            if (response.StudentModelRequest.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "You have Select Wrong Batch!";
            }
            return Ok(response);
        }

        [HttpGet("staff")]
        public async Task<IActionResult> GetStaffRecord()
        {
            var response = await _sunlincInterface.GetStaffRecord();
            if(response.StaffDetailsRequest == null )
            {
                response.IsSuccess = false;
                response.Message = "Failed to fetch Data From Database";
            }
            return Ok(response);
        }
        [HttpGet("getstaffrecordbyid")]//route
        public async Task<IActionResult> GetRecordBySaffId([FromQuery] string id)
        {
            var response = await _sunlincInterface.GetStaffRecordById(id);

            return Ok(response);
        }
        [HttpPost("insertstaffrecord")]
        public async Task<IActionResult> InsertStaffRecord(StaffDetailsRequest request)
        {
           StaffModelResponse response = new StaffModelResponse();
           // response = await _validator.ValidateStudentRequest(request);
            if (response != null)
            {
                response = await _sunlincInterface.InsertStaffRecord(request);
            }
            return Ok(response);
        }

        [HttpDelete("deletestaffrecord")]
        public async Task<IActionResult> DeleteStaffRecord([FromQuery] string id)
        {
            var response = await _sunlincInterface.DeleteStaffRecord(id);
            return Ok(response);
        }
    }
}
