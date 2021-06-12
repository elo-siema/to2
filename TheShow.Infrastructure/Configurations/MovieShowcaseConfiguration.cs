using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheShow.Domain;

namespace TheShow.Infrastructure.Configurations
{
    internal class MovieShowcaseConfiguration : IEntityTypeConfiguration<MovieShowcase>
    {
        public void Configure(EntityTypeBuilder<MovieShowcase> builder)
        {
            builder.ToTable("MovieShowcases");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Movie).WithMany(x => x.Showcases).HasForeignKey("MovieId");
        }
    }
}
