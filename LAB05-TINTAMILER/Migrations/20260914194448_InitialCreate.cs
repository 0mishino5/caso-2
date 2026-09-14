using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LAB05_TINTAMILER.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    clienteid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    razonsocial = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ruc = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    correo = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fecharegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("clientes_pkey", x => x.clienteid);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    empleadoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cargo = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    correo = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("empleados_pkey", x => x.empleadoid);
                });

            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    proyectoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    objetivos = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    fechainicio = table.Column<DateOnly>(type: "date", nullable: false),
                    fechafin = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "Planificado"),
                    clienteid = table.Column<int>(type: "integer", nullable: false),
                    responsableid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("proyectos_pkey", x => x.proyectoid);
                    table.ForeignKey(
                        name: "fk_proyectos_clientes",
                        column: x => x.clienteid,
                        principalTable: "clientes",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_proyectos_empleados",
                        column: x => x.responsableid,
                        principalTable: "empleados",
                        principalColumn: "empleadoid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comunicacionescliente",
                columns: table => new
                {
                    comunicacionclienteid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clienteid = table.Column<int>(type: "integer", nullable: false),
                    proyectoid = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    asunto = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    detalle = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    fechacomunicacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    registradopor = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("comunicacionescliente_pkey", x => x.comunicacionclienteid);
                    table.ForeignKey(
                        name: "fk_comunicaciones_clientes",
                        column: x => x.clienteid,
                        principalTable: "clientes",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comunicaciones_proyectos",
                        column: x => x.proyectoid,
                        principalTable: "proyectos",
                        principalColumn: "proyectoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hitosproyecto",
                columns: table => new
                {
                    hitoproyectoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    proyectoid = table.Column<int>(type: "integer", nullable: false),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    fechaplanificada = table.Column<DateOnly>(type: "date", nullable: false),
                    fechacumplimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("hitosproyecto_pkey", x => x.hitoproyectoid);
                    table.ForeignKey(
                        name: "fk_hitos_proyectos",
                        column: x => x.proyectoid,
                        principalTable: "proyectos",
                        principalColumn: "proyectoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "informesprogreso",
                columns: table => new
                {
                    informeprogresoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    proyectoid = table.Column<int>(type: "integer", nullable: false),
                    empleadoid = table.Column<int>(type: "integer", nullable: false),
                    fechainforme = table.Column<DateOnly>(type: "date", nullable: false),
                    avancegeneral = table.Column<int>(type: "integer", nullable: false),
                    hitosalcanzados = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    pendientes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    riesgos = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("informesprogreso_pkey", x => x.informeprogresoid);
                    table.CheckConstraint("ck_informes_avance", "avancegeneral >= 0 AND avancegeneral <= 100");
                    table.ForeignKey(
                        name: "fk_informes_empleados",
                        column: x => x.empleadoid,
                        principalTable: "empleados",
                        principalColumn: "empleadoid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_informes_proyectos",
                        column: x => x.proyectoid,
                        principalTable: "proyectos",
                        principalColumn: "proyectoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "presupuestosproyecto",
                columns: table => new
                {
                    presupuestoproyectoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    proyectoid = table.Column<int>(type: "integer", nullable: false),
                    concepto = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    montoestimado = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    gastoreal = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    fecharegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    observacion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("presupuestosproyecto_pkey", x => x.presupuestoproyectoid);
                    table.CheckConstraint("ck_presupuesto_estimado", "montoestimado >= 0");
                    table.CheckConstraint("ck_presupuesto_gasto", "gastoreal >= 0");
                    table.ForeignKey(
                        name: "fk_presupuestos_proyectos",
                        column: x => x.proyectoid,
                        principalTable: "proyectos",
                        principalColumn: "proyectoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tareasproyecto",
                columns: table => new
                {
                    tareaproyectoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    proyectoid = table.Column<int>(type: "integer", nullable: false),
                    empleadoid = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    fechalimite = table.Column<DateOnly>(type: "date", nullable: false),
                    estado = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "Pendiente"),
                    porcentajeavance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tareasproyecto_pkey", x => x.tareaproyectoid);
                    table.CheckConstraint("ck_tareas_avance", "porcentajeavance >= 0 AND porcentajeavance <= 100");
                    table.ForeignKey(
                        name: "fk_tareas_empleados",
                        column: x => x.empleadoid,
                        principalTable: "empleados",
                        principalColumn: "empleadoid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tareas_proyectos",
                        column: x => x.proyectoid,
                        principalTable: "proyectos",
                        principalColumn: "proyectoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_correo",
                table: "clientes",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ruc",
                table: "clientes",
                column: "ruc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comunicacionescliente_clienteid",
                table: "comunicacionescliente",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_comunicacionescliente_proyectoid",
                table: "comunicacionescliente",
                column: "proyectoid");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_correo",
                table: "empleados",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hitosproyecto_proyectoid",
                table: "hitosproyecto",
                column: "proyectoid");

            migrationBuilder.CreateIndex(
                name: "IX_informesprogreso_empleadoid",
                table: "informesprogreso",
                column: "empleadoid");

            migrationBuilder.CreateIndex(
                name: "IX_informesprogreso_proyectoid",
                table: "informesprogreso",
                column: "proyectoid");

            migrationBuilder.CreateIndex(
                name: "IX_presupuestosproyecto_proyectoid",
                table: "presupuestosproyecto",
                column: "proyectoid");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_clienteid",
                table: "proyectos",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_responsableid",
                table: "proyectos",
                column: "responsableid");

            migrationBuilder.CreateIndex(
                name: "IX_tareasproyecto_empleadoid",
                table: "tareasproyecto",
                column: "empleadoid");

            migrationBuilder.CreateIndex(
                name: "IX_tareasproyecto_proyectoid",
                table: "tareasproyecto",
                column: "proyectoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comunicacionescliente");

            migrationBuilder.DropTable(
                name: "hitosproyecto");

            migrationBuilder.DropTable(
                name: "informesprogreso");

            migrationBuilder.DropTable(
                name: "presupuestosproyecto");

            migrationBuilder.DropTable(
                name: "tareasproyecto");

            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "empleados");
        }
    }
}
