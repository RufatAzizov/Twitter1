﻿using AutoMapper;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDtos;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;
using Twitter.Core.Entity;

namespace Twitter.Business.Services.Implements
{
    public class BlogService : IBlogService
    {
        IBlogRepository _repo { get; }
        IMapper _mapper { get; }
        public BlogService(IBlogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<BlogListDto> GetAll()
        {
            var blogs = _repo.GetAll();
            return _mapper.Map<IEnumerable<BlogListDto>>(blogs);
        }

        public async Task<BlogDetailDto> GetByIdAsync(int id)
        {
            var blog = await _checkId(id, true);
            return _mapper.Map<BlogDetailDto>(blog);
        }

        public async Task CreateAsync(BlogCreateDto dto)
        {
            var blogExists = await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower());
            if (blogExists)
            {
                throw new Exceptions.Blog.BlogExistException();
            }

            var blogEntity = _mapper.Map<Blog>(dto);

            blogEntity.CreatedTime = DateTime.UtcNow;
            blogEntity.UpdatedTime = DateTime.UtcNow;

            await _repo.CreateAsync(blogEntity);
            await _repo.SaveAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var blog = await _checkId(id);
            _repo.Remove(blog);
            await _repo.SaveAsync();
        }

        //public async Task Delete(int id)
        //{
        //    var data = await _repo.GetByIdAsync(id, false);
        //    if (data == null) throw new NotFoundException<Post>();
        //    if (data.AppUserId != UserId) throw new Exception();
        //    _repo.Remove(data);
        //    await _repo.SaveAsync();
        //}
        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
        async Task<Blog> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack);
            if (data == null) throw new NotFoundException<Topic>();
            return data;
        }



    }
}
