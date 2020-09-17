using System;
using System.Collections.Generic;
using System.Text;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.DAL.Configurations
{
  class RequestConfigurations : IEntityTypeConfiguration<Fligth>
    {
        public void Configure(EntityTypeBuilder<Fligth> builder)
        {
           // builder.ToTable("Fligth");

            builder.HasOne(a => a.Request)
                .WithOne(b => b.Fligth)
                .HasForeignKey<Request>(b => b.RequestRef);
        }
    }
}
