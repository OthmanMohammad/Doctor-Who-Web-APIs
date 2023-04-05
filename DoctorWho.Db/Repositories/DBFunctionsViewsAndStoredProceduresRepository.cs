using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoctorWho.Db.Repositories
{
    /*
     * The class has four static methods: Execute_fnCompanions, Execute_fnEnemies, Execute_viewEpisodes,
     * and Execute_spSummariseEpisodes. These methods are used to execute functions, views, and stored
     * procedures in the database.
     * 
     * Execute_fnCompanions takes an integer parameter EpisodeId and retrieves the companions for a given
     * episode by executing the fnCompanions function. The result of the function is displayed in the console.
     * 
     * Execute_fnEnemies takes an integer parameter EpisodeId and retrieves the enemies for a given episode
     * by executing the fnEnemies function. The result of the function is displayed in the console.
     * 
     * Execute_viewEpisodes retrieves all the results of the viewEpisodes view and displays them in the
     * console in a tabular format.
     * 
     * Execute_spSummariseEpisodes retrieves the three most frequently appearing companions and enemies by
     * executing the stored procedures spSummariseEpisodeCompanions and spSummariseEpisodeEnemies respectively.
     * The results are displayed in the console.
     * 
     * The DoctorWhoCoreDbContext._context object is used to access the database. The methods in the class
     * interact with the database by executing functions, views, and stored procedures. The results of these
     * actions are displayed in the console.
     * 
     */


    public class DBFunctionsViewsAndStoredProceduresRepository
    {
        public static void Execute_fnCompanions(int EpisodeId)
        {
            var companions = DoctorWhoCoreDbContext._context.Companions.Select(c => DoctorWhoCoreDbContext._context.Execute_fnCompanions(EpisodeId)).FirstOrDefault();
            Console.WriteLine(companions);
        }
        public static void Execute_fnEnemies(int EpisodeId)
        {
            var enemies = DoctorWhoCoreDbContext._context.Enemies.Select(e => DoctorWhoCoreDbContext._context.Execute_fnEnemies(EpisodeId)).FirstOrDefault();
            Console.WriteLine(enemies);
        }
        public static void Execute_viewEpisodes()
        {
            var viewResults = DoctorWhoCoreDbContext._context.EpisodeViews.ToList();

            Console.WriteLine(String.Format("{0, 5}|{1, 5}|{2, 5}|{3, 5}|{4, 5}|{5, 5}|{6, 5}",
                    "Series_Number", "Episode_Number", "Title", "Doctor_Name", "Author_Name", "Companions", "Enemies"));
            foreach (var result in viewResults)
            {
                Console.WriteLine(String.Format("{0, 5}|{1, 5}|{2, 5}|{3, 5}|{4, 5}|{5, 5}|{6, 5}",
                    result.Series_Number, result.Episode_Number, result.Title, result.Doctor_Name, result.Author_Name, result.Companions, result.Enemies));
            }
        }
        public static void Execute_spSummariseEpisodes()
        {
            var companions = DoctorWhoCoreDbContext._context.ThreeMostFrequentlyAppearingCompanions.FromSqlRaw("EXEC spSummariseEpisodeCompanions").ToList();
            foreach (var companion in companions)
            {
                Console.WriteLine(companion.Three_Most_Frequently_Appearing_Companions);
            }
            var enemies = DoctorWhoCoreDbContext._context.ThreeMostFrequenlyAppearingEnemies.FromSqlRaw("EXEC spSummariseEpisodeEnemies").ToList();
            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemy.Three_Most_Frequently_Appearing_Enemies);
            }
        }
    }
}