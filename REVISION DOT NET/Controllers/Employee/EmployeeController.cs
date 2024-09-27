using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Data;
using REVISION_DOT_NET.Model;
using REVISION_DOT_NET.Model.DTO;

namespace REVISION_DOT_NET.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _responseDto;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
            _responseDto = new ResponseDto();
        }
        //Get All Employees 
        [HttpGet]
        public ResponseDto GetEmployee()
        {

            try
            {
                //IEnumerable<EmployeeModel> employees= _context.Employees.ToList();
                var employees = _context.Employees.ToList();
                _responseDto.Result = employees;
                _responseDto.Message = "Employee getting successfull";

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ResponseDto> PostEmployee([FromBody] EmployeeModel employeeDto)
        {
            try
            {
                // Validate the incoming request
                if (!ModelState.IsValid)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Invalid employee data.";
                    return _responseDto;
                }

                // Create a new Employee model from the DTO
                var employee = new EmployeeModel
                {
                    Name = employeeDto.Name,
                    Address = employeeDto.Address,
                    ContactNumber = employeeDto.ContactNumber,
                    DateOfBirth = employeeDto.DateOfBirth,
                    DateOfJoining = employeeDto.DateOfJoining,
                    Department = employeeDto.Department,
                    Designation = employeeDto.Designation,
                    Email = employeeDto.Email,
                    EmergencyContact = employeeDto.EmergencyContact,
                    EmployeeId = employeeDto.EmployeeId,
                    EmploymentType = employeeDto.EmploymentType,
                    Gender = employeeDto.Gender,
                    Id = employeeDto.Id,
                    IsActive = employeeDto.IsActive,
                    LastUpdated = employeeDto.LastUpdated,
                    MaritalStatus = employeeDto.MaritalStatus,
                    Nationality = employeeDto.Nationality,
                    Role = employeeDto.Role,
                    Salary = employeeDto.Salary,
                    Skills = employeeDto.Skills,
                    Supervisor = employeeDto.Supervisor


                };

                // Add the new employee to the database
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                // Prepare the response
                _responseDto.IsSuccess = true;
                _responseDto.Result = employee;
                _responseDto.Message = "Employee created successfully.";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // Delete: api/Employee/{Id}
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ResponseDto> DeleteEmployee(int Id)
        {
            try
            {
                // Find the employee by ID
                EmployeeModel employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);

                // Check if the employee exists
                if (employee == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Employee not found";
                    return _responseDto;
                }

                // Remove the employee
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                // Set response DTO
                _responseDto.IsSuccess = true;
                _responseDto.Result = employee;
                _responseDto.Message = "Employee deleted successfully";

                // Return a successful response
                return _responseDto;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                _responseDto.IsSuccess = false;
                _responseDto.Message = $"An error occurred: {ex.Message}";
                // Log exception here if necessary
                return _responseDto;
            }
        }

        //Get Single Employee Data
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ResponseDto> GetSingleEmployee(int Id)
        {
            try
            {
                var singleEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == Id);  
                if (singleEmployee == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Data not found";

                }
                else
                {
                    _responseDto.IsSuccess =true;
                    _responseDto.Result= singleEmployee;
                    _responseDto.Message = "Data getting successfull";

                }
         
 
            } catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto; // Return the responseDto outside the try-catch
        }

    }
}
