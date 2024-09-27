﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Data;
using REVISION_DOT_NET.Model.Domain.Blogs;
using REVISION_DOT_NET.Model.DTO;

namespace REVISION_DOT_NET.Controllers.Blogs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ResponseDto _responseDto;
        public BlogsController(AppDbContext context)
        {
            _context = context;
            _responseDto = new ResponseDto();

        }
        // Get Blogs
        [HttpGet]
        public async Task<ResponseDto> GetBlog()
        {
            try
            {
                var blogs = await _context.Blogs.ToListAsync();

                // Map Blogs entity to BlogsDto
                var blogDtos = blogs.Select(blog => new BlogsDto
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Description = blog.Description
                }).ToList();

                _responseDto.Result = blogDtos;
                _responseDto.IsSuccess = true;
                _responseDto.Message = "Data retrieval successful";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        [HttpPost]
        public  async Task<ResponseDto> PostBlog([FromBody] BlogModel blogData)
        {
            try
            {
                var blog = new BlogModel
                {
                    Id = blogData.Id,
                    Title = blogData.Title,
                    Description = blogData.Description,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();
                _responseDto.Result = blog;
                _responseDto.IsSuccess = true;
                _responseDto.Message = "Blog Created Successfull";
            }
            catch (Exception ex)
            {
                _responseDto.Message= ex.Message;
                _responseDto.IsSuccess= false;
            }
            return _responseDto;


        }


    }
}
