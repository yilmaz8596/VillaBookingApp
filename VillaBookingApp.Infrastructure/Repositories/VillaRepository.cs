using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using VillaBookingApp.Application.Common.Interfaces;
using VillaBookingApp.Domain.Entities;
using VillaBookingApp.Infrastructure.Data;

namespace VillaBookingApp.Infrastructure.Repositories
{
    public class VillaRepository: Repository<Villa>, IVillaRepository
    {
        private readonly AppDbContext _dbContext;
        public VillaRepository(
            AppDbContext dbContext
            ) : base(dbContext
            )
        {
             
            _dbContext = dbContext;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Villa villa)
        {
            _dbContext.Update(villa);
        }
    }
}
