using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class RemovePresidentScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresidentialPrediction_PresidentialPredictionScore_Id",
                table: "PresidentialPrediction");

            migrationBuilder.DropTable(
                name: "PresidentialPredictionScore");

            migrationBuilder.AddColumn<double>(
                name: "AKVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ALVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ARVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AZVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "COVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CTVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate1FaithlessElectorsScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate1PartyScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate1Score",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate1VPScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate2FaithlessElectorsScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate2PartyScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate2Score",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Candidate2VPScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DEVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ElectionWinnerScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ElectoralVoteWinnerScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FLVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HIVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IDVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ILVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "INVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "KSVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "KYVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MDVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MEVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MIVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MNVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MOVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MSVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MTVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NCVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NDVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NEVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NHVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NJVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NMVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NVVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NYVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OHVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OKVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ORVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PopularVoteWinnerScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RIVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SCVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SDVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ScoreTotal",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TNVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TXVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UTVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VTVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WAVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WIVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WVVoteScore",
                table: "PresidentialPrediction",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WYVoteScore",
                table: "PresidentialPrediction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AKVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ALVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ARVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "AZVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "CAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "COVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "CTVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate1FaithlessElectorsScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate1PartyScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate1Score",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate1VPScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate2FaithlessElectorsScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate2PartyScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate2Score",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "Candidate2VPScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "DEVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ElectionWinnerScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ElectoralVoteWinnerScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "FLVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "GAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "HIVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "IAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "IDVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ILVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "INVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "KSVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "KYVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "LAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MDVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MEVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MIVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MNVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MOVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MSVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "MTVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NCVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NDVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NEVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NHVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NJVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NMVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NVVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "NYVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "OHVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "OKVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ORVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "PAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "PopularVoteWinnerScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "RIVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "SCVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "SDVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "ScoreTotal",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "TNVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "TXVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "UTVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "VAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "VTVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "WAVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "WIVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "WVVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.DropColumn(
                name: "WYVoteScore",
                table: "PresidentialPrediction");

            migrationBuilder.CreateTable(
                name: "PresidentialPredictionScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AKVoteScore = table.Column<double>(nullable: true),
                    ALVoteScore = table.Column<double>(nullable: true),
                    ARVoteScore = table.Column<double>(nullable: true),
                    AZVoteScore = table.Column<double>(nullable: true),
                    CAVoteScore = table.Column<double>(nullable: true),
                    COVoteScore = table.Column<double>(nullable: true),
                    CTVoteScore = table.Column<double>(nullable: true),
                    Candidate1FaithlessElectorsScore = table.Column<double>(nullable: true),
                    Candidate1PartyScore = table.Column<double>(nullable: true),
                    Candidate1Score = table.Column<double>(nullable: true),
                    Candidate1VPScore = table.Column<double>(nullable: true),
                    Candidate2FaithlessElectorsScore = table.Column<double>(nullable: true),
                    Candidate2PartyScore = table.Column<double>(nullable: true),
                    Candidate2Score = table.Column<double>(nullable: true),
                    Candidate2VPScore = table.Column<double>(nullable: true),
                    DEVoteScore = table.Column<double>(nullable: true),
                    ElectionWinnerScore = table.Column<double>(nullable: true),
                    ElectoralVoteWinnerScore = table.Column<double>(nullable: true),
                    FLVoteScore = table.Column<double>(nullable: true),
                    GAVoteScore = table.Column<double>(nullable: true),
                    HIVoteScore = table.Column<double>(nullable: true),
                    IAVoteScore = table.Column<double>(nullable: true),
                    IDVoteScore = table.Column<double>(nullable: true),
                    ILVoteScore = table.Column<double>(nullable: true),
                    INVoteScore = table.Column<double>(nullable: true),
                    KSVoteScore = table.Column<double>(nullable: true),
                    KYVoteScore = table.Column<double>(nullable: true),
                    LAVoteScore = table.Column<double>(nullable: true),
                    MAVoteScore = table.Column<double>(nullable: true),
                    MDVoteScore = table.Column<double>(nullable: true),
                    MEVoteScore = table.Column<double>(nullable: true),
                    MIVoteScore = table.Column<double>(nullable: true),
                    MNVoteScore = table.Column<double>(nullable: true),
                    MOVoteScore = table.Column<double>(nullable: true),
                    MSVoteScore = table.Column<double>(nullable: true),
                    MTVoteScore = table.Column<double>(nullable: true),
                    NCVoteScore = table.Column<double>(nullable: true),
                    NDVoteScore = table.Column<double>(nullable: true),
                    NEVoteScore = table.Column<double>(nullable: true),
                    NHVoteScore = table.Column<double>(nullable: true),
                    NJVoteScore = table.Column<double>(nullable: true),
                    NMVoteScore = table.Column<double>(nullable: true),
                    NVVoteScore = table.Column<double>(nullable: true),
                    NYVoteScore = table.Column<double>(nullable: true),
                    OHVoteScore = table.Column<double>(nullable: true),
                    OKVoteScore = table.Column<double>(nullable: true),
                    ORVoteScore = table.Column<double>(nullable: true),
                    PAVoteScore = table.Column<double>(nullable: true),
                    PopularVoteWinnerScore = table.Column<double>(nullable: true),
                    RIVoteScore = table.Column<double>(nullable: true),
                    SCVoteScore = table.Column<double>(nullable: true),
                    SDVoteScore = table.Column<double>(nullable: true),
                    ScoreTotal = table.Column<double>(nullable: true),
                    TNVoteScore = table.Column<double>(nullable: true),
                    TXVoteScore = table.Column<double>(nullable: true),
                    UTVoteScore = table.Column<double>(nullable: true),
                    VAVoteScore = table.Column<double>(nullable: true),
                    VTVoteScore = table.Column<double>(nullable: true),
                    WAVoteScore = table.Column<double>(nullable: true),
                    WIVoteScore = table.Column<double>(nullable: true),
                    WVVoteScore = table.Column<double>(nullable: true),
                    WYVoteScore = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresidentialPredictionScore", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PresidentialPrediction_PresidentialPredictionScore_Id",
                table: "PresidentialPrediction",
                column: "Id",
                principalTable: "PresidentialPredictionScore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
