using DoctorWho.Domain;
using System;

namespace DoctorWho.Db.Repositories
{
    public class EnemiesRepository
    {
        public static void Create(string EnemyName, string Description)
        {
            if (EnemyName == null) throw new ArgumentNullException("Cannot create an Enemy with a null EnemyName!");
            DoctorWhoCoreDbContext._context.Enemies.Add(new Enemy(EnemyName, Description));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Delete(Enemy Enemy)
        {
            if (Enemy == null) throw new ArgumentNullException("Cannot remove a null Enemy from the Enemies table");
            try
            {
                DoctorWhoCoreDbContext._context.Enemies.Remove(Enemy);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Enemy GetEnemyById(int EnemyId)
        {
            var enemy = DoctorWhoCoreDbContext._context.Enemies.Find(EnemyId);
            return enemy != null ? enemy : throw new NullReferenceException("No enemies with the provided Id exist in the database!");
        }
    }
}