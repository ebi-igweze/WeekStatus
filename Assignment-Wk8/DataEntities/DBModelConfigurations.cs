using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBModels.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Body)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.CreatedDate)
                .IsRequired();
            
            builder.HasOne(p => p.Blog)
                .WithMany(blog => blog.Posts)
                .IsRequired();    
            builder.HasOne(p => p.Author)
                .WithMany(author => author.Posts)
                .IsRequired();
        }
    }

    public class BlogConfiguration : IEntityTypeConfiguration<Blog> 
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog");
            builder.HasKey(b => b.ID);
            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasMany(b => b.Posts)
                .WithOne(post => post.Blog)
                .IsRequired();
        }
    }

    public class AuthorConfiguration : IEntityTypeConfiguration<Author> 
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.FullName)
                .HasMaxLength(200)
                .IsRequired();
            builder.HasMany(a => a.Posts)
                .WithOne(post => post.Author)
                .IsRequired();
        }
    }

    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Name)
                .HasMaxLength(150)
                .IsRequired();
        }
    }

    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTag");
            builder.HasKey(t => t.ID);
            builder.HasOne(pt => pt.Tag)
                .WithMany(tag => tag.PostTags)
                .IsRequired();
            builder.HasOne(pt => pt.Post)
                .WithMany(post => post.PostTags)
                .IsRequired();
        }
    }

}