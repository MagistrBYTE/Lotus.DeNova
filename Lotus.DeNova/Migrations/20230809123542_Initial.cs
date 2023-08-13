﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lotus.DeNova.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "denova");

            migrationBuilder.EnsureSchema(
                name: "adm");

            migrationBuilder.EnsureSchema(
                name: "security");

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
                name: "Avatar",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SmallImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    FullImage = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Family = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Brand = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Model = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CodeId = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    IsMobileDevice = table.Column<bool>(type: "boolean", nullable: false),
                    Platform = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldActivity",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
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
                    table.PrimaryKey("PK_Notification", x => x.Id);
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
                name: "Permission",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SystemName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DispalyName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SystemName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DispalyName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
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
                name: "RolePermission",
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
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "adm",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "adm",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    RoleSystemName = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: true),
                    AvatarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Avatar_AvatarId",
                        column: x => x.AvatarId,
                        principalSchema: "adm",
                        principalTable: "Avatar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Position_PostId",
                        column: x => x.PostId,
                        principalSchema: "adm",
                        principalTable: "Position",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "adm",
                        principalTable: "Role",
                        principalColumn: "Id");
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
                name: "Message",
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
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_User_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Browser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BeginTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeviceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "adm",
                        principalTable: "Device",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Session_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFieldActivity",
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
                    table.PrimaryKey("PK_UserFieldActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFieldActivity_FieldActivity_FieldActivityId",
                        column: x => x.FieldActivityId,
                        principalSchema: "adm",
                        principalTable: "FieldActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFieldActivity_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
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
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "adm",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroup_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "adm",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AddressInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeginPeriodDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndPeriodDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressInfo_AddressElement_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "denova",
                        principalTable: "AddressElement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AstrologyInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZodiacSign = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    StoneZodiac = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TreeZodiac = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AstrologyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvatarInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoadPath = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    DataImage = table.Column<byte[]>(type: "bytea", nullable: false),
                    BeginPeriodDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndPeriodDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvatarInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BirthdayInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthdayInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthdayInfo_AddressElement_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "denova",
                        principalTable: "AddressElement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BirthdayInfoId = table.Column<int>(type: "integer", nullable: true),
                    FatherId = table.Column<Guid>(type: "uuid", nullable: true),
                    MotherId = table.Column<Guid>(type: "uuid", nullable: true),
                    AstrologyInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_AstrologyInfo_AstrologyInfoId",
                        column: x => x.AstrologyInfoId,
                        principalSchema: "denova",
                        principalTable: "AstrologyInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_BirthdayInfo_BirthdayInfoId",
                        column: x => x.BirthdayInfoId,
                        principalSchema: "denova",
                        principalTable: "BirthdayInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_Person_FatherId",
                        column: x => x.FatherId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_Person_MotherId",
                        column: x => x.MotherId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CodeID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BeginPeriodDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndPeriodDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityInfo_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonFamilyTies",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChildId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFamilyTies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFamilyTies_Person_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFamilyTies_Person_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "Group",
                columns: new[] { "Id", "Name", "ShortName" },
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
                table: "Permission",
                columns: new[] { "Id", "DispalyName", "SystemName" },
                values: new object[,]
                {
                    { 1, "Администрирование системы", "admin" },
                    { 2, "Модератор", "editor" },
                    { 3, "Пользователь", "user" }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "Position",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Инспектор", "Инспектор" },
                    { 2, "Старший инспектор", "Старший инспектор" },
                    { 3, "Ведущий специалист", "Ведущий специалист" },
                    { 4, "Начальник отдела", "Начальник отдела" }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "Role",
                columns: new[] { "Id", "DispalyName", "SystemName" },
                values: new object[,]
                {
                    { 1, "Администратор", "admin" },
                    { 2, "Редактор", "editor" },
                    { 3, "Пользователь", "user" }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                schema: "adm",
                table: "User",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "EmailConfirmed", "Login", "Name", "PasswordHash", "Patronymic", "PostId", "RoleId", "RoleSystemName", "Surname" },
                values: new object[] { new Guid("e3182c8f-87bc-4e27-a27f-b32e3e2b8018"), null, null, "dementevds@gmail.com", false, "DanielDem", "Даниил", "012f28fd2973783520fa3115f886102a09c8a15e", "Сергеевич", null, 1, "admin", "Дементьев" });

            migrationBuilder.CreateIndex(
                name: "IX_AddressElement_StreetId",
                schema: "denova",
                table: "AddressElement",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressInfo_AddressId",
                schema: "denova",
                table: "AddressInfo",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressInfo_PersonId",
                schema: "denova",
                table: "AddressInfo",
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
                name: "IX_AstrologyInfo_PersonId",
                schema: "denova",
                table: "AstrologyInfo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AvatarInfo_PersonId",
                schema: "denova",
                table: "AvatarInfo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayInfo_AddressId",
                schema: "denova",
                table: "BirthdayInfo",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayInfo_PersonId",
                schema: "denova",
                table: "BirthdayInfo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityInfo_PersonId",
                schema: "denova",
                table: "IdentityInfo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_AuthorId",
                schema: "adm",
                table: "Message",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                schema: "adm",
                table: "Message",
                column: "ReceiverId");

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
                name: "IX_Person_AstrologyInfoId",
                schema: "denova",
                table: "Person",
                column: "AstrologyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthdayInfoId",
                schema: "denova",
                table: "Person",
                column: "BirthdayInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FatherId",
                schema: "denova",
                table: "Person",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MotherId",
                schema: "denova",
                table: "Person",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamilyTies_ChildId",
                schema: "denova",
                table: "PersonFamilyTies",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFamilyTies_ParentId",
                schema: "denova",
                table: "PersonFamilyTies",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                schema: "adm",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                schema: "adm",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_DeviceId",
                schema: "adm",
                table: "Session",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_UserId",
                schema: "adm",
                table: "Session",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AvatarId",
                schema: "adm",
                table: "User",
                column: "AvatarId");

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
                name: "IX_UserFieldActivity_FieldActivityId",
                schema: "adm",
                table: "UserFieldActivity",
                column: "FieldActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFieldActivity_UserId",
                schema: "adm",
                table: "UserFieldActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                schema: "adm",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_UserId",
                schema: "adm",
                table: "UserGroup",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressInfo_Person_PersonId",
                schema: "denova",
                table: "AddressInfo",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AstrologyInfo_Person_PersonId",
                schema: "denova",
                table: "AstrologyInfo",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvatarInfo_Person_PersonId",
                schema: "denova",
                table: "AvatarInfo",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayInfo_Person_PersonId",
                schema: "denova",
                table: "BirthdayInfo",
                column: "PersonId",
                principalSchema: "denova",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressElement_AddressStreet_StreetId",
                schema: "denova",
                table: "AddressElement");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayInfo_AddressElement_AddressId",
                schema: "denova",
                table: "BirthdayInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_AstrologyInfo_Person_PersonId",
                schema: "denova",
                table: "AstrologyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayInfo_Person_PersonId",
                schema: "denova",
                table: "BirthdayInfo");

            migrationBuilder.DropTable(
                name: "AddressInfo",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AvatarInfo",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "IdentityInfo",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes",
                schema: "security");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens",
                schema: "security");

            migrationBuilder.DropTable(
                name: "PersonFamilyTies",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserFieldActivity",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Device",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "FieldActivity",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "User",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Avatar",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "AddressStreet",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AddressVillage",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AddressVillageSettlement",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AddressElement",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "AstrologyInfo",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "BirthdayInfo",
                schema: "denova");
        }
    }
}
