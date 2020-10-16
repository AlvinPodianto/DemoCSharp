using DemoDataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace DemoDataServiceTest.Mocks
{
    public class MockDbContext
    {
        private DemoContext _context;

        public MockDbContext()
        {
            var options = new DbContextOptionsBuilder<DemoContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                .Options;

            _context = new DemoContext(options);
        }

        public DemoContext Create() 
        {
            return _context;
        }
    }
}