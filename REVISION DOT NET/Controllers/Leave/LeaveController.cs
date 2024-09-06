using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Data;
using REVISION_DOT_NET.DTO;
using REVISION_DOT_NET.Model;

namespace REVISION_DOT_NET.Controllers.Leave
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ResponseDto _responseDto;

        public LeaveController(AppDbContext context)
        {
            _context = context;
            _responseDto = new ResponseDto();
        }

        // GET: api/Leave
        [HttpGet]
        public async Task<ResponseDto> GetAllLeaves()
        {
            try
            {
                var leaves = await _context.Leaves.ToListAsync();
                _responseDto.IsSuccess = true;
                _responseDto.Result = leaves;
                _responseDto.Message = "Leaves retrieved successfully.";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // GET: api/Leave/{id}
        [HttpGet("{id:int}")]
        public async Task<ResponseDto> GetLeaveById(int id)
        {
            try
            {
                var leave = await _context.Leaves.FirstOrDefaultAsync(l => l.LeaveId == id);
                if (leave == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Leave not found.";
                }
                else
                {
                    _responseDto.IsSuccess = true;
                    _responseDto.Result = leave;
                    _responseDto.Message = "Leave retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // POST: api/Leave
        [HttpPost]
        public async Task<ResponseDto> CreateLeave([FromBody] LeaveModel leaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Invalid leave data.";
                    return _responseDto;
                }

                _context.Leaves.Add(leaveModel);
                await _context.SaveChangesAsync();

                _responseDto.IsSuccess = true;
                _responseDto.Result = leaveModel;
                _responseDto.Message = "Leave created successfully.";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

                if (ex.InnerException != null)
                {
                    _responseDto.Message += " | Inner Exception: " + ex.InnerException.Message;
                }
            }

            return _responseDto;
        }

        // PUT: api/Leave/{id}
        [HttpPut("{id:int}")]
        public async Task<ResponseDto> UpdateLeave(int id, [FromBody] LeaveModel leaveModel)
        {
            try
            {
                if (id != leaveModel.LeaveId)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Leave ID mismatch.";
                    return _responseDto;
                }

                var existingLeave = await _context.Leaves.FindAsync(id);
                if (existingLeave == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Leave not found.";
                    return _responseDto;
                }

                // Update properties
                existingLeave.LeaveName = leaveModel.LeaveName;
                existingLeave.EmployeeId = leaveModel.EmployeeId;

                _context.Leaves.Update(existingLeave);
                await _context.SaveChangesAsync();

                _responseDto.IsSuccess = true;
                _responseDto.Result = existingLeave;
                _responseDto.Message = "Leave updated successfully.";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // DELETE: api/Leave/{id}
        [HttpDelete("{id:int}")]
        public async Task<ResponseDto> DeleteLeave(int id)
        {
            try
            {
                var leave = await _context.Leaves.FindAsync(id);
                if (leave == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Leave not found.";
                    return _responseDto;
                }

                _context.Leaves.Remove(leave);
                await _context.SaveChangesAsync();

                _responseDto.IsSuccess = true;
                _responseDto.Result = leave;
                _responseDto.Message = "Leave deleted successfully.";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }
    }
}
