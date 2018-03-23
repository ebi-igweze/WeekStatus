using System;
using System.Threading.Tasks;
using DBModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Assignment_Wk8
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseSqlServer(BlogContextFactory.connectionString);

            using(var db = new BlogContext(optionsBuilder.Options)) {
                var authorRepo = new BlogRepository<DbContext, Author>(db);
                var blogRepo = new BlogRepository<DbContext, Blog>(db);
                var postRepo = new BlogRepository<DbContext, Post>(db);

                // get a single blog
                var blog = blogRepo.GetSingle(5);
                Console.WriteLine(blog);

                // get all posts
                var posts = postRepo.GetAll();
                posts.ToList().ForEach(Console.WriteLine);
                
                // get an Author
                var author = authorRepo.GetSingle(5);
                Console.WriteLine(author);

                // // add new post
                // var newPost = new Post { Title = "IQueryable", Author = author, Blog = blog, CreatedDate = DateTime.Now, Body = "Some sample of IQueryable" };
                // postRepo.Add(newPost);
                // postRepo.SaveChanges();

                // // delete a Post
                // postRepo.Delete(5);
                // postRepo.SaveChanges();

                // // filter posts in a blog
                // var postList  = postRepo.FindBy(p => p.Blog.Name.Contains("C#")).ToList();
                
                // var post = postRepo.GetSingle(6);
                // post.Body = "Some New Body that was updated for Sample purposes.";
                // postRepo.Edit(post);
                // postRepo.SaveChanges();
            }
            
        }
    }
}
