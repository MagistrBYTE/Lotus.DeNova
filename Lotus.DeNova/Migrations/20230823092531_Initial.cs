using System;
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
                name: "Astrology",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignSettingId = table.Column<int>(type: "integer", nullable: true),
                    ZodiacSign = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StoneZodiac = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TreeZodiac = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astrology", x => x.Id);
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
                name: "CampaignSetting",
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
                    table.PrimaryKey("PK_CampaignSetting", x => x.Id);
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
                name: "GameContext",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignSettingId = table.Column<int>(type: "integer", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSave",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameContextId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSave", x => x.Id);
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
                name: "Image",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignSettingId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsLocal = table.Column<bool>(type: "boolean", nullable: false),
                    LoadPath = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    SizeInBytes = table.Column<int>(type: "integer", nullable: false),
                    DataImage = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
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
                name: "Race",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignSettingId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameContextId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndPeriod = table.Column<DateOnly>(type: "date", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "AvatarInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AvatarInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameContextId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: true),
                    BeginPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvatarInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvatarInfo_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "denova",
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BirthdayInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameContextId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    FatherId = table.Column<Guid>(type: "uuid", nullable: true),
                    MotherId = table.Column<Guid>(type: "uuid", nullable: true),
                    BirthdayInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    RaceId = table.Column<int>(type: "integer", nullable: true),
                    AstrologyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Astrology_AstrologyId",
                        column: x => x.AstrologyId,
                        principalSchema: "denova",
                        principalTable: "Astrology",
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
                    table.ForeignKey(
                        name: "FK_Person_Race_RaceId",
                        column: x => x.RaceId,
                        principalSchema: "denova",
                        principalTable: "Race",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentityInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameContextId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FatherName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CodeID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BeginPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "PlacementInfo",
                schema: "denova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlacementInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameContextId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSaveId = table.Column<Guid>(type: "uuid", nullable: true),
                    PositionX = table.Column<int>(type: "integer", nullable: false),
                    PositionY = table.Column<int>(type: "integer", nullable: false),
                    PositionZ = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacementInfo_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "denova",
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "Astrology",
                columns: new[] { "Id", "CampaignSettingId", "StoneZodiac", "TreeZodiac", "ZodiacSign" },
                values: new object[,]
                {
                    { 1, 1, "Алмаз", "Лиана", "Змееносец" },
                    { 2, 1, "Изумруд", "Ива", "Кецалькоатль" },
                    { 3, 1, "Топаз", "Дуб", "Телец" }
                });

            migrationBuilder.InsertData(
                schema: "denova",
                table: "CampaignSetting",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { 1, "Сентра", "Sentra" });

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
                schema: "denova",
                table: "Race",
                columns: new[] { "Id", "CampaignSettingId", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Эриец", "Erian" },
                    { 2, 1, "Завротеанен", "Zavroteanen" },
                    { 3, 1, "Леохарт", "Leohart" },
                    { 4, 1, "Триб", "Tribe" },
                    { 5, 1, "Гнол", "Gnol" },
                    { 6, 1, "Эль`гоу", "Elgou" },
                    { 7, 1, "Фергариец", "Fergarian" }
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
                name: "IX_AvatarInfo_ImageId",
                schema: "denova",
                table: "AvatarInfo",
                column: "ImageId");

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
                name: "IX_Person_AstrologyId",
                schema: "denova",
                table: "Person",
                column: "AstrologyId");

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
                name: "IX_Person_RaceId",
                schema: "denova",
                table: "Person",
                column: "RaceId");

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
                name: "IX_PlacementInfo_PersonId",
                schema: "denova",
                table: "PlacementInfo",
                column: "PersonId");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "CampaignSetting",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "GameContext",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "GameSave",
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
                name: "PersonFamilyTies",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "PlacementInfo",
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
                name: "Image",
                schema: "denova");

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
                name: "Astrology",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "BirthdayInfo",
                schema: "denova");

            migrationBuilder.DropTable(
                name: "Race",
                schema: "denova");
        }
    }
}
