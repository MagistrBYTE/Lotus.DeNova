using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lotus.DeNova.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "denova");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.EnsureSchema(
                name: "adm");

            migrationBuilder.CreateTable(
                name: "AddressVillageSettlement",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VillageSettlementType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressVillageSettlement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AstrologyType",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameSettingTypeId = table.Column<int>(type: "integer", nullable: true),
                    ZodiacSign = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StoneZodiac = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TreeZodiac = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AstrologyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScenarioId = table.Column<int>(type: "integer", nullable: false),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSave",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSettingType",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSettingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    Permissions = table.Column<string>(type: "text", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedirectUris = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Descriptions = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Resources = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterType",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameSettingTypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceType",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameSettingTypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StorageType = table.Column<int>(type: "integer", nullable: false),
                    SaveFormat = table.Column<int>(type: "integer", nullable: false),
                    LoadPath = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    SizeInBytes = table.Column<int>(type: "integer", nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileTypeId = table.Column<int>(type: "integer", nullable: true),
                    GroupId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioType",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameSettingTypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFieldActivity",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFieldActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    Sender = table.Column<string>(type: "text", nullable: true),
                    Importance = table.Column<int>(type: "integer", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPosition",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressVillage",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    VillageType = table.Column<int>(type: "integer", nullable: false),
                    OKTMO = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    OKATO = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    VillageSettlementId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressVillage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressVillage_AddressVillageSettlement_VillageSettlementId",
                        column: x => x.VillageSettlementId,
                        principalSchema: "denova",
                        principalTable: "AddressVillageSettlement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Scopes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_Application~",
                        column: x => x.ApplicationId,
                        principalSchema: "security",
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParameterAspectType",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameSettingTypeId = table.Column<int>(type: "integer", nullable: true),
                    ParameterTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterAspectType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterAspectType_ParameterType_ParameterTypeId",
                        column: x => x.ParameterTypeId,
                        principalSchema: "denova",
                        principalTable: "ParameterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Patronymic = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    RoleSystemName = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: true),
                    AvatarId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserPosition_PostId",
                        column: x => x.PostId,
                        principalSchema: "adm",
                        principalTable: "UserPosition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "adm",
                        principalTable: "UserRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRolePermissionRelation",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PermissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolePermissionRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolePermissionRelation_UserPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "adm",
                        principalTable: "UserPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRolePermissionRelation_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "adm",
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressStreet",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    VillageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressStreet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressStreet_AddressVillage_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "denova",
                        principalTable: "AddressVillage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReferenceId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "security",
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalSchema: "security",
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFieldActivityRelation",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FieldActivityId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFieldActivityRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFieldActivityRelation_UserFieldActivity_FieldActivityId",
                        column: x => x.FieldActivityId,
                        principalSchema: "adm",
                        principalTable: "UserFieldActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFieldActivityRelation_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupRelation",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroupRelation_UserGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "adm",
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroupRelation_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMessage",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMessage_User_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMessage_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AddressElement",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ElementType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Number = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    CadastralNumber = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Code = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    StreetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressElement_AddressStreet_StreetId",
                        column: x => x.StreetId,
                        principalSchema: "denova",
                        principalTable: "AddressStreet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AddressState",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    BeginPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndPeriod = table.Column<DateOnly>(type: "date", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressState_AddressElement_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "denova",
                        principalTable: "AddressElement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AvatarState",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AvatarStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvatarState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvatarState_ResourceFile_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ResourceFile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirthdayState",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthdayState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthdayState_AddressElement_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "denova",
                        principalTable: "AddressElement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityState",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentityStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FatherName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CodeID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BeginPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AvatarId = table.Column<Guid>(type: "uuid", nullable: true),
                    RaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    AstrologyTypeId = table.Column<int>(type: "integer", nullable: true),
                    PhysicalStrengthId = table.Column<Guid>(type: "uuid", nullable: false),
                    DexterityId = table.Column<Guid>(type: "uuid", nullable: false),
                    EnduranceId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhysiqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerceptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    MindId = table.Column<Guid>(type: "uuid", nullable: false),
                    WillpowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpiritualityId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppearanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharismaId = table.Column<Guid>(type: "uuid", nullable: false),
                    InfluenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_AstrologyType_AstrologyTypeId",
                        column: x => x.AstrologyTypeId,
                        principalSchema: "denova",
                        principalTable: "AstrologyType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_RaceType_RaceTypeId",
                        column: x => x.RaceTypeId,
                        principalSchema: "denova",
                        principalTable: "RaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_ResourceFile_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "ResourceFile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonParameter",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterTypeId = table.Column<int>(type: "integer", nullable: false),
                    BaseValue = table.Column<float>(type: "real", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonParameter_ParameterType_ParameterTypeId",
                        column: x => x.ParameterTypeId,
                        principalSchema: "denova",
                        principalTable: "ParameterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonParameter_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlacementState",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlacementStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionX = table.Column<int>(type: "integer", nullable: false),
                    PositionY = table.Column<int>(type: "integer", nullable: false),
                    PositionZ = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacementState_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonParameterAspect",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterAspectTypeId = table.Column<int>(type: "integer", nullable: false),
                    PersonParameterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonParameterAspect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonParameterAspect_ParameterAspectType_ParameterAspectTy~",
                        column: x => x.ParameterAspectTypeId,
                        principalSchema: "denova",
                        principalTable: "ParameterAspectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonParameterAspect_PersonParameter_PersonParameterId",
                        column: x => x.PersonParameterId,
                        principalSchema: "denova",
                        principalTable: "PersonParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonParameterAspect_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "AstrologyType",
                columns: new[] { "Id", "GameSettingTypeId", "StoneZodiac", "TreeZodiac", "ZodiacSign" },
                values: new object[,]
                {
                    { 1, 1, "Алмаз", "Лиана", "Змееносец" },
                    { 2, 1, "Изумруд", "Ива", "Кецалькоатль" },
                    { 3, 1, "Топаз", "Дуб", "Телец" }
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "GameSettingType",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { 1, "Сентра", "Sentra" });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "ParameterType",
                columns: new[] { "Id", "AdditionalInfo", "DisplayName", "GameSettingTypeId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Физическая сила", 1, "PhysicalStrength" },
                    { 2, null, "Ловкость", 1, "Dexterity" },
                    { 3, null, "Выносливость", 1, "Endurance" },
                    { 4, null, "Телосложение", 1, "Physique" },
                    { 5, null, "Восприятие", 1, "Perception" },
                    { 6, null, "Разум", 1, "Mind" },
                    { 7, null, "Сила воли", 1, "Willpower" },
                    { 8, null, "Духовность", 1, "Spirituality" },
                    { 9, null, "Внешность", 1, "Appearance" },
                    { 10, null, "Харизма", 1, "Charisma" },
                    { 11, null, "Влияние", 1, "Influence" },
                    { 12, null, "Статус", 1, "Status" }
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "RaceType",
                columns: new[] { "Id", "AdditionalInfo", "DisplayName", "GameSettingTypeId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Эриец", 1, "Erian" },
                    { 2, null, "Завротеанен", 1, "Zavroteanen" },
                    { 3, null, "Леохарт", 1, "Leohart" },
                    { 4, null, "Триб", 1, "Tribe" },
                    { 5, null, "Гвелл", 1, "Gwell" },
                    { 6, null, "Эль`гоу", 1, "Elgou" },
                    { 7, null, "Фергариец", 1, "Fergarian" }
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "ScenarioType",
                columns: new[] { "Id", "AdditionalInfo", "DisplayName", "GameSettingTypeId", "Name" },
                values: new object[] { 1, null, "Песочница", 1, "Sandbox" });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "UserGroup",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, "Хранители", "Хранители" },
                    { 2, "Север", "Север" },
                    { 3, "Юг", "Юг" },
                    { 4, "Восток", "Восток" },
                    { 5, "Запад", "Запад" }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "UserPermission",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, "Администратор", "admin" },
                    { 2, "Модератор", "editor" },
                    { 3, "Пользователь", "user" }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "UserPosition",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, "Инспектор", "Инспектор" },
                    { 2, "Старший инспектор", "Старший инспектор" },
                    { 3, "Ведущий специалист", "Ведущий специалист" },
                    { 4, "Начальник отдела", "Начальник отдела" }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "UserRole",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, "Администратор", "admin" },
                    { 2, "Редактор", "editor" },
                    { 3, "Пользователь", "user" }
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "ParameterAspectType",
                columns: new[] { "Id", "AdditionalInfo", "DisplayName", "GameSettingTypeId", "Name", "ParameterTypeId" },
                values: new object[] { 1, null, "Сильные руки", 1, "StrongArms", 1 });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "User",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "EmailConfirmed", "Login", "Name", "PasswordHash", "Patronymic", "PostId", "RoleId", "RoleSystemName", "Surname" },
                values: new object[] { new Guid("e3182c8f-87bc-4e27-a27f-b32e3e2b8018"), null, null, "dementevds@gmail.com", false, "DanielDem", "Даниил", "012f28fd2973783520fa3115f886102a09c8a15e", "Сергеевич", null, 1, "Нет роли", "Дементьев" });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "UserRolePermissionRelation",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressElement_StreetId",
                schema: "denova",
                table: "AddressElement",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressState_AddressId",
                schema: "denova",
                table: "AddressState",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressState_PersonId",
                schema: "denova",
                table: "AddressState",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressStreet_VillageId",
                schema: "denova",
                table: "AddressStreet",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressVillage_VillageSettlementId",
                schema: "denova",
                table: "AddressVillage",
                column: "VillageSettlementId");

            migrationBuilder.CreateIndex(
                name: "IX_AvatarState_ImageId",
                schema: "denova",
                table: "AvatarState",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AvatarState_PersonId",
                schema: "denova",
                table: "AvatarState",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayState_AddressId",
                schema: "denova",
                table: "BirthdayState",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayState_PersonId",
                schema: "denova",
                table: "BirthdayState",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityState_PersonId",
                schema: "denova",
                table: "IdentityState",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                schema: "security",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                schema: "security",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                schema: "security",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                schema: "security",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                schema: "security",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                schema: "security",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParameterAspectType_ParameterTypeId",
                schema: "denova",
                table: "ParameterAspectType",
                column: "ParameterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AppearanceId",
                schema: "denova",
                table: "Person",
                column: "AppearanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_AstrologyTypeId",
                schema: "denova",
                table: "Person",
                column: "AstrologyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AvatarId",
                schema: "denova",
                table: "Person",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CharismaId",
                schema: "denova",
                table: "Person",
                column: "CharismaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_DexterityId",
                schema: "denova",
                table: "Person",
                column: "DexterityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_EnduranceId",
                schema: "denova",
                table: "Person",
                column: "EnduranceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_InfluenceId",
                schema: "denova",
                table: "Person",
                column: "InfluenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_MindId",
                schema: "denova",
                table: "Person",
                column: "MindId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PerceptionId",
                schema: "denova",
                table: "Person",
                column: "PerceptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PhysicalStrengthId",
                schema: "denova",
                table: "Person",
                column: "PhysicalStrengthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PhysiqueId",
                schema: "denova",
                table: "Person",
                column: "PhysiqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_RaceTypeId",
                schema: "denova",
                table: "Person",
                column: "RaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SpiritualityId",
                schema: "denova",
                table: "Person",
                column: "SpiritualityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_StatusId",
                schema: "denova",
                table: "Person",
                column: "StatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_WillpowerId",
                schema: "denova",
                table: "Person",
                column: "WillpowerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonParameter_ParameterTypeId",
                schema: "denova",
                table: "PersonParameter",
                column: "ParameterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonParameter_PersonId",
                schema: "denova",
                table: "PersonParameter",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonParameterAspect_ParameterAspectTypeId",
                schema: "denova",
                table: "PersonParameterAspect",
                column: "ParameterAspectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonParameterAspect_PersonId",
                schema: "denova",
                table: "PersonParameterAspect",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonParameterAspect_PersonParameterId",
                schema: "denova",
                table: "PersonParameterAspect",
                column: "PersonParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementState_PersonId",
                schema: "denova",
                table: "PlacementState",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PostId",
                schema: "adm",
                table: "User",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "adm",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFieldActivityRelation_FieldActivityId",
                schema: "adm",
                table: "UserFieldActivityRelation",
                column: "FieldActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFieldActivityRelation_UserId",
                schema: "adm",
                table: "UserFieldActivityRelation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupRelation_GroupId",
                schema: "adm",
                table: "UserGroupRelation",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupRelation_UserId",
                schema: "adm",
                table: "UserGroupRelation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_AuthorId",
                schema: "adm",
                table: "UserMessage",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_ReceiverId",
                schema: "adm",
                table: "UserMessage",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissionRelation_PermissionId",
                schema: "adm",
                table: "UserRolePermissionRelation",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissionRelation_RoleId",
                schema: "adm",
                table: "UserRolePermissionRelation",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressState_Person_PersonId",
                schema: "denova",
                table: "AddressState",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvatarState_Person_PersonId",
                schema: "denova",
                table: "AvatarState",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayState_Person_PersonId",
                schema: "denova",
                table: "BirthdayState",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityState_Person_PersonId",
                schema: "denova",
                table: "IdentityState",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_AppearanceId",
                schema: "denova",
                table: "Person",
                column: "AppearanceId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_CharismaId",
                schema: "denova",
                table: "Person",
                column: "CharismaId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_DexterityId",
                schema: "denova",
                table: "Person",
                column: "DexterityId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_EnduranceId",
                schema: "denova",
                table: "Person",
                column: "EnduranceId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_InfluenceId",
                schema: "denova",
                table: "Person",
                column: "InfluenceId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_MindId",
                schema: "denova",
                table: "Person",
                column: "MindId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_PerceptionId",
                schema: "denova",
                table: "Person",
                column: "PerceptionId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_PhysicalStrengthId",
                schema: "denova",
                table: "Person",
                column: "PhysicalStrengthId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_PhysiqueId",
                schema: "denova",
                table: "Person",
                column: "PhysiqueId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_SpiritualityId",
                schema: "denova",
                table: "Person",
                column: "SpiritualityId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_StatusId",
                schema: "denova",
                table: "Person",
                column: "StatusId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonParameter_WillpowerId",
                schema: "denova",
                table: "Person",
                column: "WillpowerId",
                principalSchema: "denova",
                principalTable: "PersonParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonParameter_Person_PersonId",
                schema: "denova",
                table: "PersonParameter");

            migrationBuilder.DropTable(
                name: "AddressState",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AvatarState",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "BirthdayState",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "Game",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "GameSave",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "GameSettingType",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "IdentityState",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes",
                schema: "security");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens",
                schema: "security");

            migrationBuilder.DropTable(
                name: "PersonParameterAspect",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "PlacementState",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "ScenarioType",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "UserFieldActivityRelation",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserGroupRelation",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserMessage",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserNotification",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserRolePermissionRelation",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "AddressElement",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations",
                schema: "security");

            migrationBuilder.DropTable(
                name: "ParameterAspectType",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "UserFieldActivity",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "User",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "AddressStreet",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications",
                schema: "security");

            migrationBuilder.DropTable(
                name: "UserPosition",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "AddressVillage",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AddressVillageSettlement",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AstrologyType",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "PersonParameter",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "RaceType",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "ResourceFile");

            migrationBuilder.DropTable(
                name: "ParameterType",
                schema: "denova");
        }
    }
}
