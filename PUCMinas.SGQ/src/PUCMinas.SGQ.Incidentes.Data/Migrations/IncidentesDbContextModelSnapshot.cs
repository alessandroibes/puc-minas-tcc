﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PUCMinas.SGQ.Incidentes.Data.Context;

namespace PUCMinas.SGQ.Incidentes.Data.Migrations
{
    [DbContext(typeof(IncidentesDbContext))]
    partial class IncidentesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PUCMinas.SGQ.Incidentes.Business.Models.Acao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<DateTime?>("DataUltimaAtualizacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Acoes");
                });

            modelBuilder.Entity("PUCMinas.SGQ.Incidentes.Business.Models.Causa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<DateTime?>("DataUltimaAtualizacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Causas");
                });

            modelBuilder.Entity("PUCMinas.SGQ.Incidentes.Business.Models.Gravidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<DateTime?>("DataUltimaAtualizacao");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Gravidades");
                });

            modelBuilder.Entity("PUCMinas.SGQ.Incidentes.Business.Models.RNC", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AcaoId");

                    b.Property<Guid>("CausaId");

                    b.Property<int>("Classificacao");

                    b.Property<DateTime?>("DataCriacao");

                    b.Property<DateTime>("DataFechamento");

                    b.Property<DateTime>("DataOcorrencia");

                    b.Property<DateTime>("DataResolucao");

                    b.Property<DateTime?>("DataUltimaAtualizacao");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("EngenheiroResponsavel");

                    b.Property<Guid>("GerenteCriador");

                    b.Property<Guid>("GestorAvaliador");

                    b.Property<Guid>("GravidadeId");

                    b.Property<string>("Ocorrencia")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("Prazo");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AcaoId");

                    b.HasIndex("CausaId");

                    b.HasIndex("GravidadeId");

                    b.ToTable("RNCs");
                });

            modelBuilder.Entity("PUCMinas.SGQ.Incidentes.Business.Models.RNC", b =>
                {
                    b.HasOne("PUCMinas.SGQ.Incidentes.Business.Models.Acao", "Acao")
                        .WithMany("RNCs")
                        .HasForeignKey("AcaoId");

                    b.HasOne("PUCMinas.SGQ.Incidentes.Business.Models.Causa", "Causa")
                        .WithMany("RNCs")
                        .HasForeignKey("CausaId");

                    b.HasOne("PUCMinas.SGQ.Incidentes.Business.Models.Gravidade", "Gravidade")
                        .WithMany("RNCs")
                        .HasForeignKey("GravidadeId");
                });
#pragma warning restore 612, 618
        }
    }
}
