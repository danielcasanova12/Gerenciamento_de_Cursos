﻿// <auto-generated />
using System;
using Curso.RazorPages.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Curso.RazorPages.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230908204909_V10")]
    partial class V10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("AlunoModelCursoModel", b =>
                {
                    b.Property<int>("AlunosAlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursosCursoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunosAlunoId", "CursosCursoId");

                    b.HasIndex("CursosCursoId");

                    b.ToTable("AlunoModelCursoModel");
                });

            modelBuilder.Entity("Curso.RazorPages.Models.AlunoCurso", b =>
                {
                    b.Property<int?>("AlunoCursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CursoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoCursoId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunoCursos");
                });

            modelBuilder.Entity("Curso.RazorPages.Models.AlunoModel", b =>
                {
                    b.Property<int?>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataInscricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeAluno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Curso.RazorPages.Models.CursoModel", b =>
                {
                    b.Property<int?>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataInicio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataTermino")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("AlunoModelCursoModel", b =>
                {
                    b.HasOne("Curso.RazorPages.Models.AlunoModel", null)
                        .WithMany()
                        .HasForeignKey("AlunosAlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Curso.RazorPages.Models.CursoModel", null)
                        .WithMany()
                        .HasForeignKey("CursosCursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Curso.RazorPages.Models.AlunoCurso", b =>
                {
                    b.HasOne("Curso.RazorPages.Models.AlunoModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("Curso.RazorPages.Models.CursoModel", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });
#pragma warning restore 612, 618
        }
    }
}