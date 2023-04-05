using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        // DbSet properties for each of the entities in the domain
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<EpisodeView> EpisodeViews { get; set; }
        public DbSet<ThreeMostFrequentlyAppearingCompanions> ThreeMostFrequentlyAppearingCompanions { get; set; }
        public DbSet<ThreeMostFrequentlyAppearingEnemies> ThreeMostFrequenlyAppearingEnemies { get; set; }
        public string Execute_fnCompanions(int EpisodeId) => throw new NotSupportedException();
        public string Execute_fnEnemies(int EpisodeId) => throw new NotSupportedException();

        // Override the OnConfiguring method to configure the database connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the UseSqlServer method to configure the connection string to use SQL Server
            // 'Integrated Security=True' was added since I kept getting 'login failed for user' error when updating -database migration
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-COT3PQTF\\SQLEXPRESS; Initial Catalog=DoctorWhoCore; Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }

        // Method to create the model for the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the key for the Author entity and set properties
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasMaxLength(350);

            // Populating the "Author" table
            using (var reader = new StreamReader(@"C:\Users\ASUS\Desktop\Doctor-Who-Core\Data_Files\Authors_List.csv"))
            {
                // Counter variable to set the AuthorId
                var i = 1;

                // Read each line from the CSV file until the end of the file is reached
                while (!reader.EndOfStream)
                {
                    // Read a line from the CSV file
                    var line = reader.ReadLine();

                    // Create an instance of the Author entity with the AuthorId set to the current iteration of the loop
                    // and the AuthorName set to the line read from the file
                    modelBuilder.Entity<Author>().HasData(
                        new Author { AuthorId = i, AuthorName = line });

                    // Increment the counter variable for the next iteration
                    i++;
                }
            }


            // Define the key for the Companion entity and set properties
            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).HasMaxLength(350);
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).HasMaxLength(350);

            // Populating the "Companion" table
            using (var reader = new StreamReader(@"C:\Users\ASUS\Desktop\Doctor-Who-Core\Data_Files\Companions_List.csv"))
            {
                var i = 1;
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    // Split the line into an array of strings using the comma as the separator
                    var data = line.Split(',');

                    // Use the Entity Framework Core model builder to add data to the Companion entity
                    modelBuilder.Entity<Companion>().HasData(
                        new Companion { CompanionId = i, CompanionName = data[0], WhoPlayed = data[1] });

                    i++;
                }
            }

            // Define the key for the Doctor entity and set properties
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorId).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).HasMaxLength(350);
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");

            // Populating the "Doctor" table (data is hardcoded)
            modelBuilder.Entity<Doctor>().HasData(
             new Doctor { DoctorId = DoctorIdEnum.First_Doctor, DoctorNumber = 1, DoctorName = "William Hartnell", BirthDate = new DateTime(1908, 01, 08), FirstEpisodeDate = new DateTime(1963, 10, 29), LastEpisodeDate = new DateTime(1966, 10, 29) },
             new Doctor { DoctorId = DoctorIdEnum.Second_Doctor, DoctorNumber = 2, DoctorName = "Patrick Troughton", BirthDate = new DateTime(1920, 03, 25), FirstEpisodeDate = new DateTime(1966, 11, 05), LastEpisodeDate = new DateTime(1969, 06, 21) },
             new Doctor { DoctorId = DoctorIdEnum.Third_Doctor, DoctorNumber = 3, DoctorName = "Jon Pertwee", BirthDate = new DateTime(1919, 07, 07), FirstEpisodeDate = new DateTime(1970, 01, 02), LastEpisodeDate = new DateTime(1974, 06, 08) },
             new Doctor { DoctorId = DoctorIdEnum.Fourth_Doctor, DoctorNumber = 4, DoctorName = "Tom Baker", BirthDate = new DateTime(1934, 01, 20), FirstEpisodeDate = new DateTime(1974, 12, 28), LastEpisodeDate = new DateTime(1981, 03, 21) },
             new Doctor { DoctorId = DoctorIdEnum.Fifth_Doctor, DoctorNumber = 5, DoctorName = "Peter Davison", BirthDate = new DateTime(1951, 04, 13), FirstEpisodeDate = new DateTime(1982, 01, 04), LastEpisodeDate = new DateTime(1984, 03, 16) },
             new Doctor { DoctorId = DoctorIdEnum.Sixth_Doctor, DoctorNumber = 6, DoctorName = "Colin Baker", BirthDate = new DateTime(1943, 06, 08), FirstEpisodeDate = new DateTime(1984, 03, 22), LastEpisodeDate = new DateTime(1986, 12, 06) },
             new Doctor { DoctorId = DoctorIdEnum.Seventh_Doctor, DoctorNumber = 7, DoctorName = "Sylvester McCoy", BirthDate = new DateTime(1943, 08, 20), FirstEpisodeDate = new DateTime(1987, 09, 07), LastEpisodeDate = new DateTime(1989, 12, 06) },
             new Doctor { DoctorId = DoctorIdEnum.Eighth_Doctor, DoctorNumber = 8, DoctorName = "Paul McGann", BirthDate = new DateTime(1959, 11, 14), FirstEpisodeDate = new DateTime(1996, 05, 27), LastEpisodeDate = new DateTime(1996, 05, 27) },
             new Doctor { DoctorId = DoctorIdEnum.Ninth_Doctor, DoctorNumber = 9, DoctorName = "Christopher Eccleston", BirthDate = new DateTime(1964, 02, 16), FirstEpisodeDate = new DateTime(2005, 03, 26), LastEpisodeDate = new DateTime(2005, 06, 18) },
             new Doctor { DoctorId = DoctorIdEnum.Tenth_Doctor, DoctorNumber = 10, DoctorName = "David Tennant", BirthDate = new DateTime(1971, 04, 18), FirstEpisodeDate = new DateTime(2005, 12, 25), LastEpisodeDate = new DateTime(2010, 01, 01) },
             new Doctor { DoctorId = DoctorIdEnum.Eleventh_Doctor, DoctorNumber = 11, DoctorName = "Matt Smith", BirthDate = new DateTime(1982, 10, 28), FirstEpisodeDate = new DateTime(2010, 04, 03), LastEpisodeDate = new DateTime(2013, 12, 25) },
             new Doctor { DoctorId = DoctorIdEnum.Twelfth_Doctor, DoctorNumber = 12, DoctorName = "Peter Capaldi", BirthDate = new DateTime(1958, 04, 14), FirstEpisodeDate = new DateTime(2014, 08, 23), LastEpisodeDate = new DateTime(2017, 12, 25) },
             new Doctor { DoctorId = DoctorIdEnum.Thirteenth_Doctor, DoctorNumber = 13, DoctorName = "Jodie Whittaker", BirthDate = new DateTime(1982, 06, 17), FirstEpisodeDate = new DateTime(2018, 10, 07), LastEpisodeDate = null });

            // Define the key for the Enemy entity and set properties.
            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).HasMaxLength(350);
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");

            // Populating the "Enemy" table
            using (var reader = new StreamReader(@"C:\Users\ASUS\Desktop\Doctor-Who-Core\Data_Files\Enemies_List.csv"))
            {
                var i = 1;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');
                    modelBuilder.Entity<Enemy>().HasData(
                        new Enemy { EnemyId = i, EnemyName = data[0], Description = data[1] });
                    i++;
                }
            }

            // Define "EpisodeCompanion" entity and set the primary key
            modelBuilder.Entity<EpisodeCompanion>().HasKey(ec => ec.EpisodeCompanionId);

            // Set up the relationship between "EpisodeCompanion" and "Companion" entities
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ec => ec.Companion)
                        .WithMany(c => c.EpisodeCompanions)
                        .HasForeignKey(ec => ec.CompanionId);

            // Set up the relationship between "EpisodeCompanion" and "Episode" entities
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ec => ec.Episode)
                        .WithMany(e => e.EpisodeCompanions)
                        .HasForeignKey(ec => ec.EpisodeId);

            // Populating the "EpisodeCompanion" table
            using (var reader = new StreamReader(@"C:\Users\ASUS\Desktop\Doctor-Who-Core\Data_Files\Episode_Companion_List.csv"))
            {
                var i = 1;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');
                    modelBuilder.Entity<EpisodeCompanion>().HasData(
                        new EpisodeCompanion
                        {
                            EpisodeCompanionId = i,
                            // converts the string representation of the episode ID to an integer and
                            // assigns it to the EpisodeId property.
                            EpisodeId = int.Parse(data[0]),
                            CompanionId = int.Parse(data[1]) 
                        });
                    i++;
                }
            }

            // Define the EpisodeEnemy entity and set the primary key
            modelBuilder.Entity<EpisodeEnemy>().HasKey(ee => ee.EpisodeEnemyId);

            // Define the relationship between EpisodeEnemy and Enemy entities
            modelBuilder.Entity<EpisodeEnemy>()
                        .HasOne(ee => ee.Enemy)
                        .WithMany(e => e.EpisodeEnemies)
                        .HasForeignKey(ee => ee.EnemyId);

            // Define the relationship between EpisodeEnemy and Episode entities
            modelBuilder.Entity<EpisodeEnemy>()
                        .HasOne(ee => ee.Episode)
                        .WithMany(e => e.EpisodeEnemies)
                        .HasForeignKey(ee => ee.EpisodeId);

            // Populating the "EpisodeEnemy" table
            using (var reader = new StreamReader(@"C:\Users\ASUS\Desktop\Doctor-Who-Core\Data_Files\Episode_Enemy_List.csv"))
            {
                var i = 1;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');
                    modelBuilder.Entity<EpisodeEnemy>().HasData(
                        new EpisodeEnemy
                        {
                            EpisodeEnemyId = i,
                            EpisodeId = int.Parse(data[0]),
                            EnemyId = int.Parse(data[1])
                        });
                    i++;
                }
            }

            // Define the key for the Episode entity and set properties
            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasMaxLength(50);
            modelBuilder.Entity<Episode>().Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("NULL");

            /*
            The int.TryParse(string, out int) method is used to try to parse a string representation 
            of a number into an int value. If the string can be successfully parsed into an int, the 
            method returns true and the parsed value is stored in the out int parameter. If the string 
            cannot be parsed into an int, the method returns false and the value of the out int parameter 
            is not modified.

            In the code below, int.TryParse(data[0], out int val1) is used to try to parse the string value 
            stored in data[0] into an int value. If the string can be parsed into an int, the value is stored 
            in val1 and the method returns true. If the string cannot be parsed into an int, the method returns 
            false and val1 is not modified.

            Similarly, DateTime.TryParseExact(data[4], "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result) 
            is used to try to parse the string value stored in data[4] into a DateTime value using the specified format "dd-MMM-yy". 
            If the string can be parsed into a DateTime value using the specified format, the value is stored in result and the method returns true. 
            If the string cannot be parsed into a DateTime value using the specified format, the method returns false and result is not modified.

            */

            // Populating the "Episode" table
            using (var reader = new StreamReader(@"C:\Users\ASUS\Desktop\Doctor-Who-Core\Data_Files\Episode_List.csv"))
            {
                var i = 1;
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');

                    modelBuilder.Entity<Episode>().HasData(
                        new Episode
                        {
                            EpisodeId = i,
                            SeriesNumber = int.TryParse(data[0], out int val1) ? val1 : null,
                            EpisodeNumber = int.TryParse(data[1], out int val2) ? val2 : null,
                            EpisodeType = data[2],
                            Title = data[3],
                            EpisodeDate = DateTime.TryParseExact(data[4], "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result) ? result : null,
                            AuthorId = int.TryParse(data[5], out int val4) ? val4 : 1,
                            DoctorId = int.TryParse(data[6], out int val5) ? (DoctorIdEnum)val5 : 0,
                            Notes = data[7]
                        });
                    i++;
                }
            }

            // Define the EpisodeView entity as a database view with no key
            modelBuilder.Entity<EpisodeView>().HasNoKey().ToView("viewEpisodes");

            // Define the ThreeMostFrequentlyAppearingCompanions entity as an entity with no key
            modelBuilder.Entity<ThreeMostFrequentlyAppearingCompanions>().HasNoKey();

            // Define the ThreeMostFrequentlyAppearingEnemies entity as an entity with no key
            modelBuilder.Entity<ThreeMostFrequentlyAppearingEnemies>().HasNoKey();

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                        .GetMethod(nameof(Execute_fnCompanions), new[] { typeof(int) }))
                        .HasName("fnCompanions");
            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                        .GetMethod(nameof(Execute_fnEnemies), new[] { typeof(int) }))
                        .HasName("fnEnemies");
        }
    }
}




