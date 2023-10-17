using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especie", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "laboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratorio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipomovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipomovimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEspecieFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raza_especie_IdEspecieFk",
                        column: x => x.IdEspecieFk,
                        principalTable: "especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    IdLaboratorioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_laboratorio_IdLaboratorioFk",
                        column: x => x.IdLaboratorioFk,
                        principalTable: "laboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdTipoMovimientoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimiento_tipomovimiento_IdTipoMovimientoFk",
                        column: x => x.IdTipoMovimientoFk,
                        principalTable: "tipomovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdPropietarioFk = table.Column<int>(type: "int", nullable: false),
                    IdRazaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mascota_propietario_IdPropietarioFk",
                        column: x => x.IdPropietarioFk,
                        principalTable: "propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_raza_IdRazaFk",
                        column: x => x.IdRazaFk,
                        principalTable: "raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamentoProveedor",
                columns: table => new
                {
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentoProveedor", x => new { x.IdMedicamentoFk, x.IdProveedorFk });
                    table.ForeignKey(
                        name: "FK_medicamentoProveedor_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamentoProveedor_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoMedicamento",
                columns: table => new
                {
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    IdMovimientoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoMedicamento", x => new { x.IdMedicamentoFk, x.IdMovimientoFk });
                    table.ForeignKey(
                        name: "FK_movimientoMedicamento_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoMedicamento_movimiento_IdMovimientoFk",
                        column: x => x.IdMovimientoFk,
                        principalTable: "movimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hora = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Motivo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMascotaFk = table.Column<int>(type: "int", nullable: false),
                    IdVeterinarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cita_mascota_IdMascotaFk",
                        column: x => x.IdMascotaFk,
                        principalTable: "mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_veterinario_IdVeterinarioFk",
                        column: x => x.IdVeterinarioFk,
                        principalTable: "veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamientomedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dosis = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAdministracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCitaFk = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientomedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tratamientomedico_cita_IdCitaFk",
                        column: x => x.IdCitaFk,
                        principalTable: "cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tratamientomedico_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "especie",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perro" },
                    { 2, "Felina" },
                    { 3, "Conejo" },
                    { 4, "Ave" }
                });

            migrationBuilder.InsertData(
                table: "laboratorio",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle Veterinaria 123", "AnimalMed", "555-111-1111" },
                    { 2, "Avenida de Mascotas 456", "Genfar", "555-222-2222" },
                    { 3, "Carrera Animal 789", "PetCare Labs", "555-333-3333" },
                    { 4, "Calle de Cuidados 567", "AnimalHealth Solutions", "555-444-4444" },
                    { 5, "Avenida de Salud 321", "VetMedix", "555-555-5555" },
                    { 6, "Carrera Bienestar 654", "AnimalWellness Labs", "555-666-6666" },
                    { 7, "Calle de Farmacia 890", "AnimalPharmaceuticals", "555-777-7777" },
                    { 8, "Avenida de Medicamentos 987", "VetRx", "555-888-8888" },
                    { 9, "Carrera Innovación 123", "AnimalCare Innovations", "555-999-9999" },
                    { 10, "Avenida Principal Animal", "BioVet", "555-123-4567" }
                });

            migrationBuilder.InsertData(
                table: "propietario",
                columns: new[] { "Id", "CorreoElectronico", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juan.perez@example.com", "Juan Pérez", "555-123-4567" },
                    { 2, "maria.rodriguez@example.com", "María Rodríguez", "555-987-6543" },
                    { 3, "luis.gonzalez@example.com", "Luis González", "555-567-8901" },
                    { 4, "ana.martinez@example.com", "Ana Martínez", "555-111-2222" },
                    { 5, "carlos.sanchez@example.com", "Carlos Sánchez", "555-333-4444" },
                    { 6, "laura.lopez@example.com", "Laura López", "555-555-6666" },
                    { 7, "pedro.ramirez@example.com", "Pedro Ramírez", "555-777-8888" },
                    { 8, "sofia.torres@example.com", "Sofía Torres", "555-999-0000" }
                });

            migrationBuilder.InsertData(
                table: "proveedor",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle de Suministros 123", "AnimalPharma", "555-111-1111" },
                    { 2, "Avenida de Productos 456", "PetMedSupplies", "555-222-2222" },
                    { 3, "Carrera de Veterinaria 789", "VetSupplies Co.", "555-333-3333" },
                    { 4, "Calle de Distribución 567", "AnimalHealth Distributors", "555-444-4444" },
                    { 5, "Avenida de Farmacia 321", "PetPharmaceuticals Inc.", "555-555-5555" },
                    { 6, "Carrera de Suministros 654", "AnimalCare Supplies", "555-666-6666" }
                });

            migrationBuilder.InsertData(
                table: "tipomovimiento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Compra" },
                    { 2, "Venta" }
                });

            migrationBuilder.InsertData(
                table: "veterinario",
                columns: new[] { "Id", "CorreoElectronico", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juan.perez@example.com", "Cirujano vascular", "Dr. Juan Pérez", "555-123-4567" },
                    { 2, "maria.rodriguez@example.com", "Cirujano vascular", "Dra. María Rodríguez", "555-987-6543" },
                    { 3, "luis.gonzalez@example.com", "Cardiología", "Dr. Luis González", "555-567-8901" },
                    { 4, "ana.martinez@example.com", "Cirujano vascular", "Dra. Ana Martínez", "555-111-2222" },
                    { 5, "carlos.sanchez@example.com", "Dermatología", "Dr. Carlos Sánchez", "555-333-4444" },
                    { 6, "laura.lopez@example.com", "Cirujano vascular", "Dra. Laura López", "555-555-6666" },
                    { 7, "pedro.ramirez@example.com", "Oftalmología", "Dr. Pedro Ramírez", "555-777-8888" },
                    { 8, "sofia.torres@example.com", "Cirujano vascular", "Dra. Sofía Torres", "555-999-0000" },
                    { 9, "diego.mendoza@example.com", "Neurología", "Dr. Diego Mendoza", "555-444-3333" },
                    { 10, "patricia.gomez@example.com", "Peluqueria", "Dra. Patricia Gómez", "555-222-1111" }
                });

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "Id", "IdLaboratorioFk", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 2, "PetRelief", 10.99, 100 },
                    { 2, 2, "AnimalGuardian", 8.9900000000000002, 75 },
                    { 3, 4, "VetMediCure", 12.99, 50 },
                    { 4, 5, "PetRxPlus", 15.99, 120 },
                    { 5, 6, "AnimalVitality", 11.99, 90 }
                });

            migrationBuilder.InsertData(
                table: "movimiento",
                columns: new[] { "Id", "Cantidad", "FechaMovimiento", "IdTipoMovimientoFk", "Precio" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 50 },
                    { 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 80 },
                    { 3, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 60 },
                    { 4, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 120 },
                    { 5, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 70 }
                });

            migrationBuilder.InsertData(
                table: "raza",
                columns: new[] { "Id", "IdEspecieFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Golden Retriever" },
                    { 2, 1, "Labrador Retriever" },
                    { 3, 1, "Bulldog" },
                    { 4, 2, "Siamese" },
                    { 5, 2, "Maine Coon" },
                    { 6, 3, "Holandés Enano" },
                    { 7, 3, "Cabeza de León" },
                    { 8, 4, "Canario" },
                    { 9, 4, "Periquito" }
                });

            migrationBuilder.InsertData(
                table: "mascota",
                columns: new[] { "Id", "FechaNacimiento", "IdPropietarioFk", "IdRazaFk", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Max" },
                    { 2, new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Luna" },
                    { 3, new DateTime(2018, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, "Rocky" },
                    { 4, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, "Bella" },
                    { 5, new DateTime(2017, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Coco" }
                });

            migrationBuilder.InsertData(
                table: "medicamentoProveedor",
                columns: new[] { "IdMedicamentoFk", "IdProveedorFk" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 4 },
                    { 4, 3 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "movimientoMedicamento",
                columns: new[] { "IdMedicamentoFk", "IdMovimientoFk" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "cita",
                columns: new[] { "Id", "Fecha", "Hora", "IdMascotaFk", "IdVeterinarioFk", "Motivo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "09:00 AM", 1, 1, "Vacunación" },
                    { 2, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "11:30 AM", 2, 2, "Consulta General" },
                    { 3, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "03:15 PM", 3, 3, "Vacunación" },
                    { 4, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "02:00 PM", 4, 2, "Cirugía" },
                    { 5, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "10:45 AM", 5, 3, "Consulta General" },
                    { 6, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "04:30 PM", 3, 4, "Vacunación" }
                });

            migrationBuilder.InsertData(
                table: "tratamientomedico",
                columns: new[] { "Id", "Dosis", "FechaAdministracion", "IdCitaFk", "IdMedicamentoFk", "Observacion" },
                values: new object[,]
                {
                    { 1, "2 tabletas", new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "Tomar después de las comidas" },
                    { 2, "1 cápsula", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, "Tomar con agua" },
                    { 3, "3 ml", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, "Inyectar en el músculo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdMascotaFk",
                table: "cita",
                column: "IdMascotaFk");

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdVeterinarioFk",
                table: "cita",
                column: "IdVeterinarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdPropietarioFk",
                table: "mascota",
                column: "IdPropietarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdRazaFk",
                table: "mascota",
                column: "IdRazaFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdLaboratorioFk",
                table: "medicamento",
                column: "IdLaboratorioFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentoProveedor_IdProveedorFk",
                table: "medicamentoProveedor",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_IdTipoMovimientoFk",
                table: "movimiento",
                column: "IdTipoMovimientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoMedicamento_IdMovimientoFk",
                table: "movimientoMedicamento",
                column: "IdMovimientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_raza_IdEspecieFk",
                table: "raza",
                column: "IdEspecieFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientomedico_IdCitaFk",
                table: "tratamientomedico",
                column: "IdCitaFk");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientomedico_IdMedicamentoFk",
                table: "tratamientomedico",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolId",
                table: "userRol",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamentoProveedor");

            migrationBuilder.DropTable(
                name: "movimientoMedicamento");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "tratamientomedico");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "movimiento");

            migrationBuilder.DropTable(
                name: "cita");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "tipomovimiento");

            migrationBuilder.DropTable(
                name: "mascota");

            migrationBuilder.DropTable(
                name: "veterinario");

            migrationBuilder.DropTable(
                name: "laboratorio");

            migrationBuilder.DropTable(
                name: "propietario");

            migrationBuilder.DropTable(
                name: "raza");

            migrationBuilder.DropTable(
                name: "especie");
        }
    }
}
