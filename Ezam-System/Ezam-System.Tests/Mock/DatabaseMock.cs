using Ezam_System.Data;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ezam_System.Tests.Mock
{
    public static class DatabaseMock
    {

        public static EzamDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<EzamDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new EzamDbContext(dbContextOptions);
            }
        }
    }
}
