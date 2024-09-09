using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DataAccess.Configurations
{
    public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        }
    }
}
