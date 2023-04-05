using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    /*
     * This code creates a view in a SQL database named "viewEpisodes". The view is
     * created using a SELECT statement that retrieves data from the "Episodes" table
     * and several other related tables (Authors, Doctors). The SELECT statement retrieves
     * the following columns from the specified tables:
     * "SeriesNumber" from the "Episodes" table and renaming it as "Series_Number"
     * "EpisodeNumber" from the "Episodes" table and renaming it as "Episode_Number"
     * "Title" from the "Episodes" table
     * "AuthorName" from the "Authors" table and renaming it as "Author_Name"
     * "DoctorName" from the "Doctors" table and renaming it as "Doctor_Name"
     * "Companions" from the user-defined function "fnCompanions" which takes an "EpisodeId" as an input parameter
     * "Enemies" from the user-defined function "fnEnemies" which takes an "EpisodeId" as an input parameter
     * The LEFT JOIN clause is used to join the data from the "Authors" and "Doctors" tables
     * with the data from the "Episodes" table based on the "AuthorId" and "DoctorId" columns, respectively.
    */
    public partial class CreateView_viewEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes AS
                                   SELECT E.SeriesNumber AS Series_Number, 
	                                      E.EpisodeNumber AS Episode_Number, 
	                                      E.Title AS Title, 
	                                      A.AuthorName AS Author_Name, 
	                                      D.DoctorName AS Doctor_Name,
	                                      dbo.fnCompanions(E.EpisodeId) AS Companions,
	                                      dbo.fnEnemies(E.EpisodeId) AS Enemies
                                   FROM Episodes E
	                                            LEFT JOIN Authors A ON E.AuthorId = A.AuthorId
	                                            LEFT JOIN Doctors D ON E.DoctorId = D.DoctorId 
                                   GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS viewEpisodes");
        }
    }
}