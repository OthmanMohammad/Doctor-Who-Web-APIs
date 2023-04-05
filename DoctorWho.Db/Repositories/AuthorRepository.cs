using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoctorWho.Db.Repositories
{
    public class AuthorsRepository
    {
        public static void Create(string AuthorName)
        {
            if (AuthorName == null) throw new ArgumentNullException("Cannot create an Author with a null AuthorName!");
            DoctorWhoCoreDbContext._context.Authors.Add(new Author(AuthorName));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Delete(Author Author)
        {
            if (Author == null) throw new ArgumentNullException("Cannot remove a null Author from the Authors table");
            try
            {
                DoctorWhoCoreDbContext._context.Authors.Remove(Author);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}