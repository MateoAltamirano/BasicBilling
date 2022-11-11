using System;
using System.Reflection;
using BasicBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.Infrastructure.Data
{
	public class BasicBillingContext : DbContext
	{
        public BasicBillingContext(DbContextOptions<BasicBillingContext> options) : base(options) { }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<ClientBill> ClientBill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

