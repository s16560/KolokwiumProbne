using KolokwiumProbne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Configurations
{
    public class ZamowienieConfiguration : IEntityTypeConfiguration<Zamowienie>
    {
        public void Configure(EntityTypeBuilder<Zamowienie> builder)
        {
            builder.HasKey(z => z.IdZamowienia); //[Key] primary key
            builder.Property(z => z.IdZamowienia).ValueGeneratedOnAdd();
            builder.Property(z => z.IdZamowienia).IsRequired();

            builder.Property(z => z.DataPrzyjecia).IsRequired();

            builder.Property(z => z.Uwagi).HasMaxLength(300); //[MaxLength(100)]

            builder.HasMany(z => z.Zamowienie_WyrobyCukiernicze)
                   .WithOne(z => z.Zamowienie)
                   .HasForeignKey(z => z.IdZamowienia)
                   .IsRequired();
        }
    }
}
