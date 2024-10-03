using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Data;
using REVISION_DOT_NET.Model.Domain.Jobs;
using REVISION_DOT_NET.Model.DTO;
using REVISION_DOT_NET.Model.DTO.Jobs;

namespace REVISION_DOT_NET.Controllers.Jobs
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ResponseDto _responseDto;
        public JobsController(AppDbContext context)

        {
            _context = context;
            _responseDto = new ResponseDto();
        }
        // Post a new jobs
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> PostJobs([FromBody] JobModel jobData)
        {
            try
            {
                var job = new JobModel
                {
                    title = jobData.title,
                    description = jobData.description,
                    category_id = jobData.category_id,
                    company_id = jobData.company_id,
                    thumbnail = jobData.thumbnail,
                    location_id = jobData.location_id,
                    posted_by_id = jobData.posted_by_id,
                };

                await _context.Job.AddAsync(job);
                await _context.SaveChangesAsync();

                _responseDto.Message = "Job posted successfully";
                _responseDto.IsSuccess = true;
                _responseDto.Result = job;

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;

                return BadRequest(_responseDto);
            }
        }

        // Get all jobs
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetPost (int page = 1, int pageSize = 10)
        {
            try
            {
                var skip = (page - 1) * pageSize;
                var jobs = await _context.Job.Skip(skip).Take(pageSize).ToListAsync();
                _responseDto.Message = "Job getting successfull";
                _responseDto.IsSuccess = true;
                _responseDto.Result = jobs;
                return Ok(jobs);

            }
            catch(Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
                return BadRequest(_responseDto);
            }

        }

    }
}
