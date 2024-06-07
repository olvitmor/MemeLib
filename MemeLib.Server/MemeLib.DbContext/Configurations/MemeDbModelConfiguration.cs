using MemeLib.DbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeLib.DbContext.Configurations;

public class MemeDbModelConfiguration : IEntityTypeConfiguration<MemeDbModel>
{
    public void Configure(EntityTypeBuilder<MemeDbModel> builder)
    {
        builder.ToTable("memes");

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasComment("Meme Id");

        builder.Property(x => x.Alias)
            .IsRequired()
            .HasColumnName("alias")
            .HasComment("Meme Alias");

        builder.Property(x => x.Ts)
            .IsRequired()
            .HasColumnName("ts")
            .HasComment("Meme last update timestamp");

        builder.Property(x => x.AuthorId)
            .IsRequired()
            .HasColumnName("author_id")
            .HasComment("Meme's author id");

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasComment("Meme description");

        builder.Property(x => x.PublishDate)
            .HasColumnName("publish_date")
            .HasComment("Meme publish date");
    }
}