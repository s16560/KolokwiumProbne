using KolokwiumProbne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Configurations
{
    public class KlientConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            builder.HasKey(k => k.IdKlient); //[Key] primary key
            builder.Property(k => k.IdKlient).ValueGeneratedOnAdd();
            builder.Property(k => k.IdKlient).IsRequired();

            builder.Property(k => k.Imie)
                   .HasMaxLength(50) //[MaxLength(50)]
                   .IsRequired(); //[Required]

            builder.Property(k => k.Nazwisko)
                   .HasMaxLength(60) //[MaxLength(60)]
                   .IsRequired(); //[Required]
         
            builder.HasMany(k => k.Zamowienia)
                   .WithOne(k => k.Klient)
                   .HasForeignKey(k => k.IdKlient)
                   .IsRequired();
        }
    }
}
