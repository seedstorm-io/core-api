﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeedStorm.CoreApi.Entities;
using SeedStorm.CoreApi.Entities.Node;
using SeedStorm.CoreApi.Entities.NodeCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.CoreApi
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeTemplate> NodesCatalog { get; set; }

        public DatabaseContext() : base()
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}