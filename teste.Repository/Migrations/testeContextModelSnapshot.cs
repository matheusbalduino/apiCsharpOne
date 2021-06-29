﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using teste.Repository;

namespace teste.Repository.Migrations
{
    [DbContext(typeof(testeContext))]
    partial class testeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("teste.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dataEvento");

                    b.Property<string>("email");

                    b.Property<string>("imageUrl");

                    b.Property<string>("local");

                    b.Property<int>("qtdPessoas");

                    b.Property<string>("telefone");

                    b.Property<string>("tema");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("teste.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("dataFim");

                    b.Property<DateTime?>("dataInicio");

                    b.Property<int>("eventoId");

                    b.Property<string>("nome");

                    b.Property<decimal>("preco");

                    b.Property<int>("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("eventoId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("teste.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("imagemURL");

                    b.Property<string>("miniCurriculo");

                    b.Property<string>("nome");

                    b.Property<string>("telefone");

                    b.HasKey("Id");

                    b.ToTable("Palestrante");
                });

            modelBuilder.Entity("teste.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("eventoId");

                    b.Property<int>("palestranteId");

                    b.Property<int>("Id");

                    b.HasKey("eventoId", "palestranteId");

                    b.HasIndex("palestranteId");

                    b.ToTable("PalestranteEvento");
                });

            modelBuilder.Entity("teste.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("URL");

                    b.Property<int?>("eventoId");

                    b.Property<string>("nome");

                    b.Property<int?>("palestranteId");

                    b.HasKey("Id");

                    b.HasIndex("eventoId");

                    b.HasIndex("palestranteId");

                    b.ToTable("RedeSocial");
                });

            modelBuilder.Entity("teste.Domain.Lote", b =>
                {
                    b.HasOne("teste.Domain.Evento", "evento")
                        .WithMany("lotes")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("teste.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("teste.Domain.Evento", "evento")
                        .WithMany("palestrantesEventos")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("teste.Domain.Palestrante", "palestrante")
                        .WithMany("palestrantesEventos")
                        .HasForeignKey("palestranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("teste.Domain.RedeSocial", b =>
                {
                    b.HasOne("teste.Domain.Evento", "evento")
                        .WithMany("redeSociais")
                        .HasForeignKey("eventoId");

                    b.HasOne("teste.Domain.Palestrante", "palestrante")
                        .WithMany("redeSociais")
                        .HasForeignKey("palestranteId");
                });
#pragma warning restore 612, 618
        }
    }
}