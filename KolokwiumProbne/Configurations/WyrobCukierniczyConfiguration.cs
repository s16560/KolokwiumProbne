using KolokwiumProbne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Configurations
{
    public class WyrobCukierniczyConfiguration : IEntityTypeConfiguration<WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<WyrobCukierniczy> builder)
        {
            builder.HasKey(wc => wc.IdWyrobuCukierniczego); //[Key] primary key
            builder.Property(wc => wc.IdWyrobuCukierniczego).ValueGeneratedOnAdd();
            builder.Property(wc => wc.IdWyrobuCukierniczego).IsRequired();

            builder.Property(wc => wc.Nazwa)
                   .HasMaxLength(200) //[MaxLength(200)]
                   .IsRequired(); //[Required]

            builder.Property(wc => wc.CenaZaSzt)                 
                   .IsRequired();

            builder.Property(wc => wc.Typ)
                   .HasMaxLength(40)
                   .IsRequired();

            builder.HasMany(wc => wc.Zamowienie_WyrobyCukiernicze)
                   .WithOne(wc => wc.WyrobCukierniczy)
                   .HasForeignKey(wc => wc.IdWyrobuCukierniczego)
                   .IsRequired();
        }
    }
}
