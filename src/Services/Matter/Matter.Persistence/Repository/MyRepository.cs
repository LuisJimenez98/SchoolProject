﻿using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Matter.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matter.Persistence.Repository
{
    public class MyRepository<T>: RepositoryBase<T>, IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext context;

        public MyRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
