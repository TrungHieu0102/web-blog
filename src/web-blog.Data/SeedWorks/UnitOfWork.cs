﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_blog.Core.SeedWorks;

namespace web_blog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebBlogContext _context;

        public UnitOfWork(WebBlogContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
