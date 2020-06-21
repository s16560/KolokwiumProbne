using KolokwiumProbne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumProbne.Configurations
{
    public class PracownikConfiguration : IEntityTypeConfiguration<Pracownik>
    {
        public void Configure(EntityTypeBuilder<Pracownik> builder)
        {
            builder.HasKey(p => p.IdPracownik); //[Key] primary key
            builder.Property(p => p.IdPracownik).ValueGeneratedOnAdd();
            builder.Property(p => p.IdPracownik).IsRequired();

            builder.Property(p => p.Imie)
                       .HasMaxLength(50) //[MaxLength(50)]
                       .IsRequired(); //[Required]

            builder.Property(p => p.Nazwisko)
                       .HasMaxLength(60) //[MaxLength(60)]
                       .IsRequired(); //[Required]

            builder.HasMany(p => p.Zamowienia)
                       .WithOne(p => p.Pracownik)
                       .HasForeignKey(p => p.IdKlient)
                       .IsRequired();
        }
    }
}
