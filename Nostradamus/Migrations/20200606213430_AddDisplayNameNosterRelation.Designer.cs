﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nostradamus;

namespace Nostradamus.Migrations
{
    [DbContext(typeof(NostradamusContext))]
    [Migration("20200606213430_AddDisplayNameNosterRelation")]
    partial class AddDisplayNameNosterRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Nostradamus.Models.GenericEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("DateOccurs");

                    b.Property<string>("Description");

                    b.Property<int?>("EventQualityVoteCount");

                    b.Property<string>("NosterId");

                    b.Property<bool?>("Occurred");

                    b.Property<string>("Title");

                    b.Property<bool?>("Valid");

                    b.HasKey("Id");

                    b.HasIndex("NosterId");

                    b.ToTable("GenericEvent");
                });

            modelBuilder.Entity("Nostradamus.Models.GenericPrediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("CorrectVoteCount");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreationDate");

                    b.Property<bool>("EventOccurred");

                    b.Property<int?>("GenericEventId");

                    b.Property<int?>("IncorrectVoteCount");

                    b.Property<string>("NosterId");

                    b.Property<string>("OutcomeDescription");

                    b.Property<DateTime?>("SnapEndDate");

                    b.Property<bool>("Valid");

                    b.HasKey("Id");

                    b.HasIndex("GenericEventId");

                    b.HasIndex("NosterId");

                    b.ToTable("GenericPrediction");
                });

            modelBuilder.Entity("Nostradamus.Models.Noster", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Motto");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Noster");
                });

            modelBuilder.Entity("Nostradamus.Models.NosterMessage", b =>
                {
                    b.Property<string>("NosterId");

                    b.Property<string>("MessageSource");

                    b.Property<DateTime>("OriginTime");

                    b.Property<bool>("IsSeen");

                    b.Property<string>("MessageBody");

                    b.Property<string>("NosterTargetUserName");

                    b.HasKey("NosterId", "MessageSource", "OriginTime");

                    b.HasAlternateKey("MessageSource", "NosterId", "OriginTime");

                    b.ToTable("NosterMessage");
                });

            modelBuilder.Entity("Nostradamus.Models.NosterRelation", b =>
                {
                    b.Property<string>("NosterId");

                    b.Property<string>("RelatedNosterId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("DisplayName");

                    b.Property<string>("RelatedDisplayName");

                    b.Property<string>("RelatedUserName");

                    b.Property<string>("RelationStatus");

                    b.Property<string>("RelationType");

                    b.Property<string>("UserName");

                    b.HasKey("NosterId", "RelatedNosterId", "CreationDate");

                    b.HasAlternateKey("CreationDate", "NosterId", "RelatedNosterId");

                    b.ToTable("NosterRelation");
                });

            modelBuilder.Entity("Nostradamus.Models.PresidentialPrediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AKVote");

                    b.Property<double?>("AKVoteScore");

                    b.Property<string>("ALVote");

                    b.Property<double?>("ALVoteScore");

                    b.Property<string>("ARVote");

                    b.Property<double?>("ARVoteScore");

                    b.Property<string>("AZVote");

                    b.Property<double?>("AZVoteScore");

                    b.Property<bool>("Active");

                    b.Property<string>("CAVote");

                    b.Property<double?>("CAVoteScore");

                    b.Property<string>("COVote");

                    b.Property<double?>("COVoteScore");

                    b.Property<string>("CTVote");

                    b.Property<double?>("CTVoteScore");

                    b.Property<string>("Candidate1");

                    b.Property<int>("Candidate1FaithlessElectors");

                    b.Property<double?>("Candidate1FaithlessElectorsScore");

                    b.Property<string>("Candidate1Party");

                    b.Property<double?>("Candidate1PartyScore");

                    b.Property<double?>("Candidate1Score");

                    b.Property<string>("Candidate1VP");

                    b.Property<double?>("Candidate1VPScore");

                    b.Property<string>("Candidate2");

                    b.Property<int>("Candidate2FaithlessElectors");

                    b.Property<double?>("Candidate2FaithlessElectorsScore");

                    b.Property<string>("Candidate2Party");

                    b.Property<double?>("Candidate2PartyScore");

                    b.Property<double?>("Candidate2Score");

                    b.Property<string>("Candidate2VP");

                    b.Property<double?>("Candidate2VPScore");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DEVote");

                    b.Property<double?>("DEVoteScore");

                    b.Property<string>("Description");

                    b.Property<string>("ElectionWinner");

                    b.Property<double?>("ElectionWinnerScore");

                    b.Property<string>("ElectoralVoteWinner");

                    b.Property<double?>("ElectoralVoteWinnerScore");

                    b.Property<string>("FLVote");

                    b.Property<double?>("FLVoteScore");

                    b.Property<string>("GAVote");

                    b.Property<double?>("GAVoteScore");

                    b.Property<string>("HIVote");

                    b.Property<double?>("HIVoteScore");

                    b.Property<string>("IAVote");

                    b.Property<double?>("IAVoteScore");

                    b.Property<string>("IDVote");

                    b.Property<double?>("IDVoteScore");

                    b.Property<string>("ILVote");

                    b.Property<double?>("ILVoteScore");

                    b.Property<string>("INVote");

                    b.Property<double?>("INVoteScore");

                    b.Property<string>("KSVote");

                    b.Property<double?>("KSVoteScore");

                    b.Property<string>("KYVote");

                    b.Property<double?>("KYVoteScore");

                    b.Property<string>("LAVote");

                    b.Property<double?>("LAVoteScore");

                    b.Property<string>("MAVote");

                    b.Property<double?>("MAVoteScore");

                    b.Property<string>("MDVote");

                    b.Property<double?>("MDVoteScore");

                    b.Property<string>("MEVote");

                    b.Property<double?>("MEVoteScore");

                    b.Property<string>("MIVote");

                    b.Property<double?>("MIVoteScore");

                    b.Property<string>("MNVote");

                    b.Property<double?>("MNVoteScore");

                    b.Property<string>("MOVote");

                    b.Property<double?>("MOVoteScore");

                    b.Property<string>("MSVote");

                    b.Property<double?>("MSVoteScore");

                    b.Property<string>("MTVote");

                    b.Property<double?>("MTVoteScore");

                    b.Property<string>("NCVote");

                    b.Property<double?>("NCVoteScore");

                    b.Property<string>("NDVote");

                    b.Property<double?>("NDVoteScore");

                    b.Property<string>("NEVote");

                    b.Property<double?>("NEVoteScore");

                    b.Property<string>("NHVote");

                    b.Property<double?>("NHVoteScore");

                    b.Property<string>("NJVote");

                    b.Property<double?>("NJVoteScore");

                    b.Property<string>("NMVote");

                    b.Property<double?>("NMVoteScore");

                    b.Property<string>("NVVote");

                    b.Property<double?>("NVVoteScore");

                    b.Property<string>("NYVote");

                    b.Property<double?>("NYVoteScore");

                    b.Property<string>("NosterId");

                    b.Property<string>("OHVote");

                    b.Property<double?>("OHVoteScore");

                    b.Property<string>("OKVote");

                    b.Property<double?>("OKVoteScore");

                    b.Property<string>("ORVote");

                    b.Property<double?>("ORVoteScore");

                    b.Property<string>("PAVote");

                    b.Property<double?>("PAVoteScore");

                    b.Property<string>("PopularVoteWinner");

                    b.Property<double?>("PopularVoteWinnerScore");

                    b.Property<string>("RIVote");

                    b.Property<double?>("RIVoteScore");

                    b.Property<string>("SCVote");

                    b.Property<double?>("SCVoteScore");

                    b.Property<string>("SDVote");

                    b.Property<double?>("SDVoteScore");

                    b.Property<double?>("ScoreTotal");

                    b.Property<bool>("Scored");

                    b.Property<DateTime?>("SnapEndDate");

                    b.Property<DateTime?>("SnapStartDate");

                    b.Property<string>("TNVote");

                    b.Property<double?>("TNVoteScore");

                    b.Property<string>("TXVote");

                    b.Property<double?>("TXVoteScore");

                    b.Property<string>("UTVote");

                    b.Property<double?>("UTVoteScore");

                    b.Property<string>("VAVote");

                    b.Property<double?>("VAVoteScore");

                    b.Property<string>("VTVote");

                    b.Property<double?>("VTVoteScore");

                    b.Property<bool>("Valid");

                    b.Property<string>("WAVote");

                    b.Property<double?>("WAVoteScore");

                    b.Property<string>("WIVote");

                    b.Property<double?>("WIVoteScore");

                    b.Property<string>("WVVote");

                    b.Property<double?>("WVVoteScore");

                    b.Property<string>("WYVote");

                    b.Property<double?>("WYVoteScore");

                    b.Property<string>("Why");

                    b.HasKey("Id");

                    b.HasIndex("NosterId");

                    b.ToTable("PresidentialPrediction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Nostradamus.Models.Noster")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nostradamus.Models.GenericEvent", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster", "Noster")
                        .WithMany("GenericEvents")
                        .HasForeignKey("NosterId");
                });

            modelBuilder.Entity("Nostradamus.Models.GenericPrediction", b =>
                {
                    b.HasOne("Nostradamus.Models.GenericEvent", "GenericEvent")
                        .WithMany("GenericPredictions")
                        .HasForeignKey("GenericEventId");

                    b.HasOne("Nostradamus.Models.Noster", "Noster")
                        .WithMany("GenericPredictions")
                        .HasForeignKey("NosterId");
                });

            modelBuilder.Entity("Nostradamus.Models.NosterMessage", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster", "Noster")
                        .WithMany("NosterMessages")
                        .HasForeignKey("NosterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nostradamus.Models.NosterRelation", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster", "Noster")
                        .WithMany("NosterRelations")
                        .HasForeignKey("NosterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nostradamus.Models.PresidentialPrediction", b =>
                {
                    b.HasOne("Nostradamus.Models.Noster", "Noster")
                        .WithMany()
                        .HasForeignKey("NosterId");
                });
#pragma warning restore 612, 618
        }
    }
}
