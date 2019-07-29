using KatlaSport.Services.BlobManagment;
using KatlaSport.Services.EmployeeManagment;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/employees")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IBlobService _blobService;

        public EmployeesController(IEmployeeService employeeService,IBlobService blobservice)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _blobService = blobservice ?? throw new ArgumentNullException(nameof(blobservice));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of employees.", Type = typeof(EmployeeBriefInfo[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{employeeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns an employee.", Type = typeof(EmployeeFullInfo))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetEmployee(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);
            return Ok(employee);
        }


        [HttpGet]
        [Route("{employeeId:int:min(1)}/subordinates")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a collections of subordiantes."
        , Type = typeof(EmployeeFullInfo[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSubordinates(int employeeId)
        {
            var subordinates = await _employeeService.GetSubordinatesAsync(employeeId);
            return Ok(subordinates);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new employee.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddEmployee()
        {
            var httpRequest = HttpContext.Current.Request;
            var file = httpRequest.Files["Image"];
            var data = httpRequest.Form["data"];
            var createRequestEmployee = JsonConvert.DeserializeObject<UpdateEmployeeRequest>(data);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (file != null && file.ContentLength > 0)
            {
                await _blobService.UploadAsync(file);
                var containerUri = await _blobService.GetBlobUriAsync();
                createRequestEmployee.ImageUri = containerUri + "/" + file.FileName;
            }
            var employee = await _employeeService.CreateEmployeeAsync(createRequestEmployee);
            var location = string.Format("/api/employee/{0}", employee.Id);
            return Created<EmployeeFullInfo>(location,employee);
        }


        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed employee.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateEmployee([FromUri] int id)
        {
            var httpRequest = HttpContext.Current.Request;
            var file = httpRequest.Files["Image"];
            var data = httpRequest.Form["data"];
            var updateRequestEmployee = JsonConvert.DeserializeObject<UpdateEmployeeRequest>(data);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (file != null && file.ContentLength > 0)
            {
                await _blobService.UploadAsync(file);
                var containerUri = await _blobService.GetBlobUriAsync();
                updateRequestEmployee.ImageUri = containerUri + "/" + file.FileName;
            }
            await _employeeService.UpdateEmployeeAsync(id, updateRequestEmployee);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existing employee")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteEmployee([FromUri] int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
