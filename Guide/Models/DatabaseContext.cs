using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
}