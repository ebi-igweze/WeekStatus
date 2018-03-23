using System;
using System.Linq;
using DBModels.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBModels
{
    public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public static readonly string connectionString = "Server=(local);Database=BlogDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        public BlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BlogContext(optionsBuilder.Options);
        }
    }

    public class BlogContext: DbContext {

        public BlogContext(DbContextOptions<BlogContext> options): base(options) {}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            // var configType = typeof (IEntityTypeConfiguration<BaseModel>);
            // var configs = 
            //     from assembly in AppDomain.CurrentDomain.GetAssemblies()
            //     from assemblyType in assembly.GetTypes()
            //     where (assemblyType.IsAbstract == false)
            //     where (assemblyType.IsInterface == false)
            //     where (configType.IsAssignableFrom(assemblyType))
            //     select Activator.CreateInstance(assemblyType) as IEntityTypeConfiguration<BaseModel>;

            // configs.ToList().ForEach(c => builder.ApplyConfiguration(c));

            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BlogConfiguration());
            // base.OnModelCreating(builder);
        }
    }
}