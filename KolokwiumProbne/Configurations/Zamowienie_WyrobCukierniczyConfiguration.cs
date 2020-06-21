using KolokwiumProbne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.Configurations
{
    public class Zamowienie_WyrobCukierniczyConfiguration
        : IEntityTypeConfiguration<Zamowienie_WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<Zamowienie_WyrobCukierniczy> builder)
        {
            builder.HasKey(zw => new
            {
                zw.IdWyrobuCukierniczego,
                zw.IdZamowienia
            });

            builder.Property(pm => pm.Uwagi)
                   .HasMaxLength(300);                  
        }
    }
}
