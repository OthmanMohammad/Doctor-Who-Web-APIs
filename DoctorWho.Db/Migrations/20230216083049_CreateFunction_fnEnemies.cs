using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreateFunction_fnEnemies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION fnRetrieveListOfEnemyIds (@EpisodeId INT)
                                   RETURNS TABLE AS
                                   RETURN
										SELECT DISTINCT EnemyId
										FROM EpisodeEnemies EE
										WHERE @EpisodeId = EE.EpisodeId
                                   GO
                                   CREATE FUNCTION fnRetrieveListOfEnemyNames (@EpisodeId INT)
                                   RETURNS TABLE AS
                                   RETURN
										SELECT DISTINCT EnemyName
										FROM Enemies E JOIN fnRetrieveListOfEnemyIds(@EpisodeId) fn 
										ON E.EnemyId = fn.EnemyId
							       GO
                                   CREATE FUNCTION fnRetrieveEnemies (@EpisodeId INT)
                                   RETURNS VARCHAR(MAX) AS
                                   BEGIN
										DECLARE @List_Of_Enemies AS VARCHAR(MAX)
										DECLARE @name AS VARCHAR(MAX)
										DECLARE enemy_cursor CURSOR FOR 
																		SELECT * FROM fnRetrieveListOfEnemyNames(@EpisodeId)
										OPEN enemy_cursor
										FETCH NEXT FROM enemy_cursor
										INTO @name
										WHILE @@FETCH_STATUS = 0
											BEGIN
												SET @List_Of_Enemies = CONCAT(@List_Of_Enemies, ', ', @name)
												FETCH NEXT FROM enemy_cursor
												INTO @name
											END
										CLOSE enemy_cursor
										DEALLOCATE enemy_cursor
										RETURN @List_Of_Enemies
						           END;
                                   GO
								   CREATE FUNCTION fnEnemies (@EpisodeId INT)
                                   RETURNS VARCHAR(MAX) AS
                                   BEGIN
										DECLARE @Max_Episode_Id AS INT
										SET @Max_Episode_Id = (SELECT MAX(EpisodeId) FROM Episodes)
										DECLARE @result AS VARCHAR(MAX)
										IF @EpisodeId <= 0 OR @EpisodeId > @Max_Episode_Id
											BEGIN
												SET @result = 'Invalid Episode Id! No Episodes exist for the Episode Id you have entered...'
											END
										ELSE
											BEGIN
												SET @result = SUBSTRING(dbo.fnRetrieveEnemies(@EpisodeId), 3, LEN(dbo.fnRetrieveEnemies(@EpisodeId)) - 2)
											END
										RETURN (CASE WHEN LEN(@result) > 0 THEN @result
										ELSE 'No enemies appear on this episode' END);
	                               END;
                                   GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnRetrieveListOfEnemyIds;
                                   DROP FUNCTION IF EXISTS fnRetrieveListOfEnemyNames;
                                   DROP FUNCTION IF EXISTS fnRetrieveEnemies;
                                   DROP FUNCTION IF EXISTS fnEnemies;");
        }
    }
}
