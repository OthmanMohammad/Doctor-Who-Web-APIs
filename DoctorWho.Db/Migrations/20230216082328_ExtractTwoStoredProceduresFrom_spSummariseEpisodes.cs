using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class ExtractTwoStoredProceduresFrom_spSummariseEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC spSummariseEpisodeCompanions AS
                                   BEGIN
										SELECT C.CompanionName AS Three_Most_Frequently_Appearing_Companions
										FROM EpisodeCompanions EC
										JOIN Companions C ON EC.CompanionId = C.CompanionId
										GROUP BY EC.CompanionId, C.CompanionName
										ORDER BY COUNT(EC.CompanionId) DESC
										OFFSET 0 ROWS
										FETCH NEXT 3 ROWS ONLY
                                        END;
                                   GO              
                                   CREATE PROC spSummariseEpisodeEnemies AS
                                   BEGIN
                                        SELECT E.EnemyName AS Three_Most_Frequently_Appearing_Enemies
										FROM EpisodeEnemies EE
										JOIN Enemies E ON EE.EnemyId = E.EnemyId
										GROUP BY EE.EnemyId, E.EnemyName
										ORDER BY COUNT(EE.EnemyId) DESC
										OFFSET 0 ROWS
										FETCH NEXT 3 ROWS ONLY;
                                   END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC IF EXISTS spSummariseEpisodeCompanions;
                                   DROP PROC IF EXISTS spSummariseEpisodeEnemies;");
        }
    }
}
