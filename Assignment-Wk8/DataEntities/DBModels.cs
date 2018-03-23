using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DBModels.Configurations;
using Microsoft.EntityFrameworkCore.Design;

namespace DBModels
{
    public class BaseModel
    {
        public int ID { get; set; }
    }

    public class Post : BaseModel
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public String Body { get; set; }
        public Blog Blog { get; set; }
        public Author Author { get; set; }
        public List<PostTag> PostTags { get; set; }
        public override string ToString() {
            return $"{{ Title: {Title}, CreatedDate: {CreatedDate}, Body: {Body}, Blog: {Blog}, Author: {Author}}}";
        }
    }

    public class Blog : BaseModel
    {
        public string Name { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        public override string ToString() {
            return $"{{ ID: {ID}, Name: {Name} }}";
        }
    }

    public class Author : BaseModel
    {
        public string FullName { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        public override string ToString() {
            return $"{{ ID: {ID}, FullName: {FullName} }}";
        }
    }

    public class Tag : BaseModel 
    {
        public string Name { get; set; }
        public List<PostTag> PostTags { get; set; }
        public override string ToString() {
            return $"{{ ID: {ID}, Name: {Name} }}";
        }
    }

    public class PostTag: BaseModel
    {
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}