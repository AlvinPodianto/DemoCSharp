﻿// <auto-generated />
using System;
using DemoAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DemoAPI.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20201006092638_FixForeignKey")]
    partial class FixForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DemoAPI.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .HasColumnName("location")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("modified_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id")
                        .HasName("pk_departments");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("DemoAPI.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("DepartmentId")
                        .HasColumnName("department_id")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnName("join_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("modified_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.HasIndex("DepartmentId")
                        .HasName("ix_employees_department_id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("DemoAPI.Models.Employee", b =>
                {
                    b.HasOne("DemoAPI.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_employees_departments_department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
