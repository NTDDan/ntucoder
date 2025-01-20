﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CatName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CatOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compilers",
                columns: table => new
                {
                    CompilerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompilerName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompilerPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompilerOption = table.Column<int>(type: "int", nullable: false),
                    CompilerExtension = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compilers", x => x.CompilerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SaltMD5 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PwdResetCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PwdResetDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ReceiveEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coders",
                columns: table => new
                {
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    CoderName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoderEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coders", x => x.CoderID);
                    table.ForeignKey(
                        name: "FK_Coders_Accounts_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BlogDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Published = table.Column<int>(type: "int", nullable: false),
                    PinHome = table.Column<int>(type: "int", nullable: false),
                    CoderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contest",
                columns: table => new
                {
                    ContestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    ContestName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContestDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RuleType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FailedPenalty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Published = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    RankingFinished = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FrozenTime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contest", x => x.ContestID);
                    table.ForeignKey(
                        name: "FK_Contest_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    ProblemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProblemName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProblemCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeLimit = table.Column<int>(type: "int", nullable: true),
                    MemoryLimit = table.Column<int>(type: "int", nullable: true),
                    ProblemContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProblemExplanation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TestType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TestCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TestProgCompile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<int>(type: "int", nullable: false),
                    TestCompilerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.ProblemID);
                    table.ForeignKey(
                        name: "FK_Problems_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Problems_Compilers_TestCompilerID",
                        column: x => x.TestCompilerID,
                        principalTable: "Compilers",
                        principalColumn: "CompilerID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    AnnounceTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AnnounceContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementID);
                    table.ForeignKey(
                        name: "FK_Announcements_Contest_ContestID",
                        column: x => x.ContestID,
                        principalTable: "Contest",
                        principalColumn: "ContestID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    ParticipationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PointScore = table.Column<int>(type: "int", nullable: true),
                    TimeScore = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    SolvedCount = table.Column<int>(type: "int", nullable: true),
                    RegisterMAC = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.ParticipationID);
                    table.ForeignKey(
                        name: "FK_Participations_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_Contest_ContestID",
                        column: x => x.ContestID,
                        principalTable: "Contest",
                        principalColumn: "ContestID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.CoderID, x.ProblemID });
                    table.ForeignKey(
                        name: "FK_Favorites_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HasProblems",
                columns: table => new
                {
                    HasProblemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    ProblemOrder = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasProblems", x => x.HasProblemID);
                    table.ForeignKey(
                        name: "FK_HasProblems_Contest_ContestID",
                        column: x => x.ContestID,
                        principalTable: "Contest",
                        principalColumn: "ContestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasProblems_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProblemCategories",
                columns: table => new
                {
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemCategories", x => new { x.ProblemID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_ProblemCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemCategories_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Solved",
                columns: table => new
                {
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solved", x => new { x.CoderID, x.ProblemID });
                    table.ForeignKey(
                        name: "FK_Solved_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solved_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    TestCaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    TestCaseOrder = table.Column<int>(type: "int", nullable: false),
                    SampleTest = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreTest = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Input = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Output = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.TestCaseID);
                    table.ForeignKey(
                        name: "FK_TestCases_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TakeParts",
                columns: table => new
                {
                    TakePartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParticipationID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    TimeSolved = table.Column<int>(type: "int", nullable: true),
                    PointWon = table.Column<int>(type: "int", nullable: true),
                    MaxPoint = table.Column<int>(type: "int", nullable: true),
                    SubmissionCount = table.Column<int>(type: "int", nullable: true),
                    FrozenTimeSol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeParts", x => x.TakePartID);
                    table.ForeignKey(
                        name: "FK_TakeParts_Participations_ParticipationID",
                        column: x => x.ParticipationID,
                        principalTable: "Participations",
                        principalColumn: "ParticipationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeParts_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    SubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CoderID = table.Column<int>(type: "int", nullable: false),
                    CompilerID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    TakePartID = table.Column<int>(type: "int", nullable: false),
                    SubmitTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubmissionCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubmissionStatus = table.Column<int>(type: "int", nullable: false),
                    SubmitLineCount = table.Column<int>(type: "int", nullable: true),
                    TestRunCount = table.Column<int>(type: "int", nullable: true),
                    TestResult = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxMemorySize = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxTimeDuration = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubmitMinute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.SubmissionID);
                    table.ForeignKey(
                        name: "FK_Submissions_Coders_CoderID",
                        column: x => x.CoderID,
                        principalTable: "Coders",
                        principalColumn: "CoderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Compilers_CompilerID",
                        column: x => x.CompilerID,
                        principalTable: "Compilers",
                        principalColumn: "CompilerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_TakeParts_TakePartID",
                        column: x => x.TakePartID,
                        principalTable: "TakeParts",
                        principalColumn: "TakePartID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestRuns",
                columns: table => new
                {
                    TestRunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubmissionID = table.Column<int>(type: "int", nullable: false),
                    TestCaseID = table.Column<int>(type: "int", nullable: false),
                    TimeDuration = table.Column<int>(type: "int", nullable: false),
                    MemorySize = table.Column<int>(type: "int", nullable: false),
                    TestOutput = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Result = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CheckerLog = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.TestRunID);
                    table.ForeignKey(
                        name: "FK_TestRuns_Submissions_SubmissionID",
                        column: x => x.SubmissionID,
                        principalTable: "Submissions",
                        principalColumn: "SubmissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestRuns_TestCases_TestCaseID",
                        column: x => x.TestCaseID,
                        principalTable: "TestCases",
                        principalColumn: "TestCaseID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ContestID",
                table: "Announcements",
                column: "ContestID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CoderID",
                table: "Blogs",
                column: "CoderID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogID",
                table: "Comments",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CoderID",
                table: "Comments",
                column: "CoderID");

            migrationBuilder.CreateIndex(
                name: "IX_Contest_CoderID",
                table: "Contest",
                column: "CoderID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProblemID",
                table: "Favorites",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_HasProblems_ContestID",
                table: "HasProblems",
                column: "ContestID");

            migrationBuilder.CreateIndex(
                name: "IX_HasProblems_ProblemID",
                table: "HasProblems",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_CoderID",
                table: "Participations",
                column: "CoderID");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_ContestID",
                table: "Participations",
                column: "ContestID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemCategories_CategoryID",
                table: "ProblemCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_CoderID",
                table: "Problems",
                column: "CoderID");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_TestCompilerID",
                table: "Problems",
                column: "TestCompilerID");

            migrationBuilder.CreateIndex(
                name: "IX_Solved_ProblemID",
                table: "Solved",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CoderID",
                table: "Submissions",
                column: "CoderID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CompilerID",
                table: "Submissions",
                column: "CompilerID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ProblemID",
                table: "Submissions",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_TakePartID",
                table: "Submissions",
                column: "TakePartID");

            migrationBuilder.CreateIndex(
                name: "IX_TakeParts_ParticipationID",
                table: "TakeParts",
                column: "ParticipationID");

            migrationBuilder.CreateIndex(
                name: "IX_TakeParts_ProblemID",
                table: "TakeParts",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_ProblemID",
                table: "TestCases",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_SubmissionID",
                table: "TestRuns",
                column: "SubmissionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_TestCaseID",
                table: "TestRuns",
                column: "TestCaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "HasProblems");

            migrationBuilder.DropTable(
                name: "ProblemCategories");

            migrationBuilder.DropTable(
                name: "Solved");

            migrationBuilder.DropTable(
                name: "TestRuns");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "TakeParts");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Contest");

            migrationBuilder.DropTable(
                name: "Compilers");

            migrationBuilder.DropTable(
                name: "Coders");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
