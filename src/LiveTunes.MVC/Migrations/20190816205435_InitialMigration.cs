﻿//using System;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace LiveTunes.MVC.Migrations
//{
//    public partial class InitialMigration : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "AspNetRoles",
//                columns: table => new
//                {
//                    Id = table.Column<string>(nullable: false),
//                    Name = table.Column<string>(maxLength: 256, nullable: true),
//                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
//                    ConcurrencyStamp = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUsers",
//                columns: table => new
//                {
//                    Id = table.Column<string>(nullable: false),
//                    UserName = table.Column<string>(maxLength: 256, nullable: true),
//                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
//                    Email = table.Column<string>(maxLength: 256, nullable: true),
//                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
//                    EmailConfirmed = table.Column<bool>(nullable: false),
//                    PasswordHash = table.Column<string>(nullable: true),
//                    SecurityStamp = table.Column<string>(nullable: true),
//                    ConcurrencyStamp = table.Column<string>(nullable: true),
//                    PhoneNumber = table.Column<string>(nullable: true),
//                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
//                    TwoFactorEnabled = table.Column<bool>(nullable: false),
//                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
//                    LockoutEnabled = table.Column<bool>(nullable: false),
//                    AccessFailedCount = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Event",
//                columns: table => new
//                {
//                    EventId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    VenueId = table.Column<int>(nullable: false),
//                    Venue = table.Column<string>(nullable: true),
//                    Latitude = table.Column<double>(nullable: false),
//                    Longitude = table.Column<double>(nullable: false),
//                    EventName = table.Column<string>(nullable: true),
//                    DateTime = table.Column<DateTime>(nullable: false),
//                    Genre = table.Column<int>(nullable: true),
//                    Description = table.Column<string>(nullable: true),
//                    EventbriteEventId = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Event", x => x.EventId);
//                });

//            migrationBuilder.CreateTable(
//                name: "MusicCategories",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    CategoryName = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_MusicCategories", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetRoleClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    RoleId = table.Column<string>(nullable: false),
//                    ClaimType = table.Column<string>(nullable: true),
//                    ClaimValue = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    UserId = table.Column<string>(nullable: false),
//                    ClaimType = table.Column<string>(nullable: true),
//                    ClaimValue = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserLogins",
//                columns: table => new
//                {
//                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
//                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
//                    ProviderDisplayName = table.Column<string>(nullable: true),
//                    UserId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
//                    table.ForeignKey(
//                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserRoles",
//                columns: table => new
//                {
//                    UserId = table.Column<string>(nullable: false),
//                    RoleId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
//                    table.ForeignKey(
//                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserTokens",
//                columns: table => new
//                {
//                    UserId = table.Column<string>(nullable: false),
//                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
//                    Name = table.Column<string>(maxLength: 128, nullable: false),
//                    Value = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
//                    table.ForeignKey(
//                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Business Profile",
//                columns: table => new
//                {
//                    BusinessProfileId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    VenueId = table.Column<int>(nullable: false),
//                    BusinessName = table.Column<string>(nullable: true),
//                    UserId = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Business Profile", x => x.BusinessProfileId);
//                    table.ForeignKey(
//                        name: "FK_Business Profile_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "User Profile",
//                columns: table => new
//                {
//                    UserProfileId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    FirstName = table.Column<string>(nullable: true),
//                    LastName = table.Column<string>(nullable: true),
//                    UserId = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_User Profile", x => x.UserProfileId);
//                    table.ForeignKey(
//                        name: "FK_User Profile_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "Address",
//                columns: table => new
//                {
//                    AddressId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    AddressLine1 = table.Column<string>(nullable: true),
//                    AddressLine2 = table.Column<string>(nullable: true),
//                    City = table.Column<string>(nullable: true),
//                    State = table.Column<string>(nullable: true),
//                    ZipCode = table.Column<int>(nullable: false),
//                    BusinessId = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Address", x => x.AddressId);
//                    table.ForeignKey(
//                        name: "FK_Address_Business Profile_BusinessId",
//                        column: x => x.BusinessId,
//                        principalTable: "Business Profile",
//                        principalColumn: "BusinessProfileId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Comment",
//                columns: table => new
//                {
//                    CommentId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    CommentText = table.Column<string>(nullable: true),
//                    DateTime = table.Column<DateTime>(nullable: false),
//                    UserId = table.Column<int>(nullable: false),
//                    EventId = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Comment", x => x.CommentId);
//                    table.ForeignKey(
//                        name: "FK_Comment_Event_EventId",
//                        column: x => x.EventId,
//                        principalTable: "Event",
//                        principalColumn: "EventId",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Comment_User Profile_UserId",
//                        column: x => x.UserId,
//                        principalTable: "User Profile",
//                        principalColumn: "UserProfileId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Like",
//                columns: table => new
//                {
//                    LikeId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    EventId = table.Column<int>(nullable: false),
//                    UserId = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Like", x => x.LikeId);
//                    table.ForeignKey(
//                        name: "FK_Like_Event_EventId",
//                        column: x => x.EventId,
//                        principalTable: "Event",
//                        principalColumn: "EventId",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Like_User Profile_UserId",
//                        column: x => x.UserId,
//                        principalTable: "User Profile",
//                        principalColumn: "UserProfileId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Music Preferences",
//                columns: table => new
//                {
//                    MusicPreferenceId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    UserId = table.Column<int>(nullable: false),
//                    ArtistName = table.Column<string>(nullable: true),
//                    SongName = table.Column<string>(nullable: true),
//                    Genre = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Music Preferences", x => x.MusicPreferenceId);
//                    table.ForeignKey(
//                        name: "FK_Music Preferences_User Profile_UserId",
//                        column: x => x.UserId,
//                        principalTable: "User Profile",
//                        principalColumn: "UserProfileId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Survey",
//                columns: table => new
//                {
//                    SurverId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    ArtistName = table.Column<string>(nullable: true),
//                    FavoriteGenre1 = table.Column<string>(nullable: true),
//                    FavoriteGenre2 = table.Column<string>(nullable: true),
//                    FavoriteGenre3 = table.Column<string>(nullable: true),
//                    UserId = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Survey", x => x.SurverId);
//                    table.ForeignKey(
//                        name: "FK_Survey_User Profile_UserId",
//                        column: x => x.UserId,
//                        principalTable: "User Profile",
//                        principalColumn: "UserProfileId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Address_BusinessId",
//                table: "Address",
//                column: "BusinessId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetRoleClaims_RoleId",
//                table: "AspNetRoleClaims",
//                column: "RoleId");

//            migrationBuilder.CreateIndex(
//                name: "RoleNameIndex",
//                table: "AspNetRoles",
//                column: "NormalizedName",
//                unique: true,
//                filter: "[NormalizedName] IS NOT NULL");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserClaims_UserId",
//                table: "AspNetUserClaims",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserLogins_UserId",
//                table: "AspNetUserLogins",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserRoles_RoleId",
//                table: "AspNetUserRoles",
//                column: "RoleId");

//            migrationBuilder.CreateIndex(
//                name: "EmailIndex",
//                table: "AspNetUsers",
//                column: "NormalizedEmail");

//            migrationBuilder.CreateIndex(
//                name: "UserNameIndex",
//                table: "AspNetUsers",
//                column: "NormalizedUserName",
//                unique: true,
//                filter: "[NormalizedUserName] IS NOT NULL");

//            migrationBuilder.CreateIndex(
//                name: "IX_Business Profile_UserId",
//                table: "Business Profile",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Comment_EventId",
//                table: "Comment",
//                column: "EventId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Comment_UserId",
//                table: "Comment",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Like_EventId",
//                table: "Like",
//                column: "EventId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Like_UserId",
//                table: "Like",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Music Preferences_UserId",
//                table: "Music Preferences",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Survey_UserId",
//                table: "Survey",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_User Profile_UserId",
//                table: "User Profile",
//                column: "UserId");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Address");

//            migrationBuilder.DropTable(
//                name: "AspNetRoleClaims");

//            migrationBuilder.DropTable(
//                name: "AspNetUserClaims");

//            migrationBuilder.DropTable(
//                name: "AspNetUserLogins");

//            migrationBuilder.DropTable(
//                name: "AspNetUserRoles");

//            migrationBuilder.DropTable(
//                name: "AspNetUserTokens");

//            migrationBuilder.DropTable(
//                name: "Comment");

//            migrationBuilder.DropTable(
//                name: "Like");

//            migrationBuilder.DropTable(
//                name: "Music Preferences");

//            migrationBuilder.DropTable(
//                name: "MusicCategories");

//            migrationBuilder.DropTable(
//                name: "Survey");

//            migrationBuilder.DropTable(
//                name: "Business Profile");

//            migrationBuilder.DropTable(
//                name: "AspNetRoles");

//            migrationBuilder.DropTable(
//                name: "Event");

//            migrationBuilder.DropTable(
//                name: "User Profile");

//            migrationBuilder.DropTable(
//                name: "AspNetUsers");
//        }
//    }
//}