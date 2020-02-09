using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nostradamus.Migrations
{
    public partial class PresidentialPrediction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresidentialPredictionScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ScoreTotal = table.Column<double>(nullable: true),
                    Candidate1Score = table.Column<double>(nullable: true),
                    Candidate1PartyScore = table.Column<double>(nullable: true),
                    Candidate1VPScore = table.Column<double>(nullable: true),
                    Candidate1FaithlessElectorsScore = table.Column<double>(nullable: true),
                    Candidate2Score = table.Column<double>(nullable: true),
                    Candidate2PartyScore = table.Column<double>(nullable: true),
                    Candidate2VPScore = table.Column<double>(nullable: true),
                    Candidate2FaithlessElectorsScore = table.Column<double>(nullable: true),
                    PopularVoteWinnerScore = table.Column<double>(nullable: true),
                    ElectoralVoteWinnerScore = table.Column<double>(nullable: true),
                    ElectionWinnerScore = table.Column<double>(nullable: true),
                    ALVoteScore = table.Column<double>(nullable: true),
                    AKVoteScore = table.Column<double>(nullable: true),
                    AZVoteScore = table.Column<double>(nullable: true),
                    ARVoteScore = table.Column<double>(nullable: true),
                    CAVoteScore = table.Column<double>(nullable: true),
                    COVoteScore = table.Column<double>(nullable: true),
                    CTVoteScore = table.Column<double>(nullable: true),
                    DEVoteScore = table.Column<double>(nullable: true),
                    FLVoteScore = table.Column<double>(nullable: true),
                    GAVoteScore = table.Column<double>(nullable: true),
                    HIVoteScore = table.Column<double>(nullable: true),
                    IDVoteScore = table.Column<double>(nullable: true),
                    ILVoteScore = table.Column<double>(nullable: true),
                    INVoteScore = table.Column<double>(nullable: true),
                    IAVoteScore = table.Column<double>(nullable: true),
                    KSVoteScore = table.Column<double>(nullable: true),
                    KYVoteScore = table.Column<double>(nullable: true),
                    LAVoteScore = table.Column<double>(nullable: true),
                    MEVoteScore = table.Column<double>(nullable: true),
                    MDVoteScore = table.Column<double>(nullable: true),
                    MAVoteScore = table.Column<double>(nullable: true),
                    MIVoteScore = table.Column<double>(nullable: true),
                    MNVoteScore = table.Column<double>(nullable: true),
                    MSVoteScore = table.Column<double>(nullable: true),
                    MOVoteScore = table.Column<double>(nullable: true),
                    MTVoteScore = table.Column<double>(nullable: true),
                    NEVoteScore = table.Column<double>(nullable: true),
                    NVVoteScore = table.Column<double>(nullable: true),
                    NHVoteScore = table.Column<double>(nullable: true),
                    NJVoteScore = table.Column<double>(nullable: true),
                    NMVoteScore = table.Column<double>(nullable: true),
                    NYVoteScore = table.Column<double>(nullable: true),
                    NCVoteScore = table.Column<double>(nullable: true),
                    NDVoteScore = table.Column<double>(nullable: true),
                    OHVoteScore = table.Column<double>(nullable: true),
                    OKVoteScore = table.Column<double>(nullable: true),
                    ORVoteScore = table.Column<double>(nullable: true),
                    PAVoteScore = table.Column<double>(nullable: true),
                    RIVoteScore = table.Column<double>(nullable: true),
                    SCVoteScore = table.Column<double>(nullable: true),
                    SDVoteScore = table.Column<double>(nullable: true),
                    TNVoteScore = table.Column<double>(nullable: true),
                    TXVoteScore = table.Column<double>(nullable: true),
                    UTVoteScore = table.Column<double>(nullable: true),
                    VTVoteScore = table.Column<double>(nullable: true),
                    VAVoteScore = table.Column<double>(nullable: true),
                    WAVoteScore = table.Column<double>(nullable: true),
                    WVVoteScore = table.Column<double>(nullable: true),
                    WIVoteScore = table.Column<double>(nullable: true),
                    WYVoteScore = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresidentialPredictionScore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresidentialPrediction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Candidate1 = table.Column<string>(nullable: true),
                    Candidate1Party = table.Column<string>(nullable: true),
                    Candidate1VP = table.Column<string>(nullable: true),
                    Candidate1FaithlessElectors = table.Column<int>(nullable: false),
                    Candidate2 = table.Column<string>(nullable: true),
                    Candidate2Party = table.Column<string>(nullable: true),
                    Candidate2VP = table.Column<string>(nullable: true),
                    Candidate2FaithlessElectors = table.Column<int>(nullable: false),
                    PopularVoteWinner = table.Column<string>(nullable: true),
                    ElectoralVoteWinner = table.Column<string>(nullable: true),
                    ElectionWinner = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Why = table.Column<string>(nullable: true),
                    SnapStartDate = table.Column<DateTime>(nullable: true),
                    SnapEndDate = table.Column<DateTime>(nullable: true),
                    Scored = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Valid = table.Column<bool>(nullable: false),
                    ALVote = table.Column<string>(nullable: true),
                    AKVote = table.Column<string>(nullable: true),
                    AZVote = table.Column<string>(nullable: true),
                    ARVote = table.Column<string>(nullable: true),
                    CAVote = table.Column<string>(nullable: true),
                    COVote = table.Column<string>(nullable: true),
                    CTVote = table.Column<string>(nullable: true),
                    DEVote = table.Column<string>(nullable: true),
                    FLVote = table.Column<string>(nullable: true),
                    GAVote = table.Column<string>(nullable: true),
                    HIVote = table.Column<string>(nullable: true),
                    IDVote = table.Column<string>(nullable: true),
                    ILVote = table.Column<string>(nullable: true),
                    INVote = table.Column<string>(nullable: true),
                    IAVote = table.Column<string>(nullable: true),
                    KSVote = table.Column<string>(nullable: true),
                    KYVote = table.Column<string>(nullable: true),
                    LAVote = table.Column<string>(nullable: true),
                    MEVote = table.Column<string>(nullable: true),
                    MDVote = table.Column<string>(nullable: true),
                    MAVote = table.Column<string>(nullable: true),
                    MIVote = table.Column<string>(nullable: true),
                    MNVote = table.Column<string>(nullable: true),
                    MSVote = table.Column<string>(nullable: true),
                    MOVote = table.Column<string>(nullable: true),
                    MTVote = table.Column<string>(nullable: true),
                    NEVote = table.Column<string>(nullable: true),
                    NVVote = table.Column<string>(nullable: true),
                    NHVote = table.Column<string>(nullable: true),
                    NJVote = table.Column<string>(nullable: true),
                    NMVote = table.Column<string>(nullable: true),
                    NYVote = table.Column<string>(nullable: true),
                    NCVote = table.Column<string>(nullable: true),
                    NDVote = table.Column<string>(nullable: true),
                    OHVote = table.Column<string>(nullable: true),
                    OKVote = table.Column<string>(nullable: true),
                    ORVote = table.Column<string>(nullable: true),
                    PAVote = table.Column<string>(nullable: true),
                    RIVote = table.Column<string>(nullable: true),
                    SCVote = table.Column<string>(nullable: true),
                    SDVote = table.Column<string>(nullable: true),
                    TNVote = table.Column<string>(nullable: true),
                    TXVote = table.Column<string>(nullable: true),
                    UTVote = table.Column<string>(nullable: true),
                    VTVote = table.Column<string>(nullable: true),
                    VAVote = table.Column<string>(nullable: true),
                    WAVote = table.Column<string>(nullable: true),
                    WVVote = table.Column<string>(nullable: true),
                    WIVote = table.Column<string>(nullable: true),
                    WYVote = table.Column<string>(nullable: true),
                    NosterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresidentialPrediction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresidentialPrediction_PresidentialPredictionScore_Id",
                        column: x => x.Id,
                        principalTable: "PresidentialPredictionScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresidentialPrediction_Noster_NosterId",
                        column: x => x.NosterId,
                        principalTable: "Noster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresidentialPrediction_NosterId",
                table: "PresidentialPrediction",
                column: "NosterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresidentialPrediction");

            migrationBuilder.DropTable(
                name: "PresidentialPredictionScore");
        }
    }
}
