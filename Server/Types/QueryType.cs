using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Server.Types
{

    public class QueryType
    {
        public async Task<IEnumerable<Mockery>> GetMockeries([Service] DatabaseContext dbContext)
        {
            return await dbContext
                .Mockeries
                .AsNoTracking()
                .Include(mockery => mockery.MockeryCategories)
                .ThenInclude(category => category.Category)
                .Include(mockery => mockery.MockeryTags)
                .ThenInclude(tag => tag.Tag)
                .AsSplitQuery()
                .ToListAsync();
        }

    }
}