// <auto-generated />
using System;
using Fiap.GlobalSolution.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap.GlobalSolution.Migrations
{
    [DbContext(typeof(GlobalSolutionContext))]
    [Migration("20221109004102_BancoInicial")]
    partial class BancoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Corrida", b =>
                {
                    b.Property<int>("CorridaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CorridaId"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_corrida");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_destino");

                    b.Property<int>("MotoristaId")
                        .HasColumnType("int");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_origem");

                    b.Property<int>("PassageiroId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Vl_corrida");

                    b.Property<bool>("isFinalizada")
                        .HasColumnType("bit")
                        .HasColumnName("st_finalizado");

                    b.HasKey("CorridaId");

                    b.HasIndex("MotoristaId");

                    b.HasIndex("PassageiroId");

                    b.ToTable("TB_FB_CORRIDA");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Motorista", b =>
                {
                    b.Property<int>("MotoristaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MotoristaId"), 1L, 1);

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_cnh");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_cpf");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_cadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_email");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit")
                        .HasColumnName("St_ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nm_motorista");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_senha");

                    b.Property<int>("TelefoneId")
                        .HasColumnType("int");

                    b.HasKey("MotoristaId");

                    b.HasIndex("TelefoneId");

                    b.ToTable("TB_FB_MOTORISTA");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.MotoristaPontoTrabalho", b =>
                {
                    b.Property<int>("PontoTrabalhoId")
                        .HasColumnType("int");

                    b.Property<int>("MotoristaId")
                        .HasColumnType("int");

                    b.HasKey("PontoTrabalhoId", "MotoristaId");

                    b.HasIndex("MotoristaId");

                    b.ToTable("MotoristaPontoTrabalhos");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Passageiro", b =>
                {
                    b.Property<int>("PassageiroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassageiroId"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nm_passageiro");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_rg");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_senha");

                    b.HasKey("PassageiroId");

                    b.ToTable("TB_FB_PASSAGEIRO");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.PontoTrabalho", b =>
                {
                    b.Property<int>("PontoTrabalhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PontoTrabalhoId"), 1L, 1);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ds_endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ds_nome");

                    b.HasKey("PontoTrabalhoId");

                    b.ToTable("TB_FB_PRONTO_TRABALHO");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelefoneId"), 1L, 1);

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_ddd");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_telefone");

                    b.HasKey("TelefoneId");

                    b.ToTable("TB_FB_TELEFONE");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeiculoId"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ds_ano");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_cor");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ds_modelo");

                    b.Property<int>("MotoristaId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nr_placa");

                    b.HasKey("VeiculoId");

                    b.HasIndex("MotoristaId");

                    b.ToTable("TB_FB_VEICULO");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Corrida", b =>
                {
                    b.HasOne("Fiap.GlobalSolution.Models.Motorista", "Motorista")
                        .WithMany("Corridas")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.GlobalSolution.Models.Passageiro", "Passageiro")
                        .WithMany("Corridas")
                        .HasForeignKey("PassageiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");

                    b.Navigation("Passageiro");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Motorista", b =>
                {
                    b.HasOne("Fiap.GlobalSolution.Models.Telefone", "Telefone")
                        .WithMany()
                        .HasForeignKey("TelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.MotoristaPontoTrabalho", b =>
                {
                    b.HasOne("Fiap.GlobalSolution.Models.Motorista", "Motorista")
                        .WithMany("MotoristaPontoTrabalhos")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.GlobalSolution.Models.PontoTrabalho", "PontoTrabalho")
                        .WithMany("MotoristaPontoTrabalhos")
                        .HasForeignKey("PontoTrabalhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");

                    b.Navigation("PontoTrabalho");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Veiculo", b =>
                {
                    b.HasOne("Fiap.GlobalSolution.Models.Motorista", "Motorista")
                        .WithMany("Veiculos")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Motorista", b =>
                {
                    b.Navigation("Corridas");

                    b.Navigation("MotoristaPontoTrabalhos");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.Passageiro", b =>
                {
                    b.Navigation("Corridas");
                });

            modelBuilder.Entity("Fiap.GlobalSolution.Models.PontoTrabalho", b =>
                {
                    b.Navigation("MotoristaPontoTrabalhos");
                });
#pragma warning restore 612, 618
        }
    }
}
