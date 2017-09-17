using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OficinaBertelli.Models
{
    public partial class OficinaBertelliContext : DbContext
    {
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<HistItem> HistItem { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<Modelos> Modelos { get; set; }
        public virtual DbSet<Montadoras> Montadoras { get; set; }
        public virtual DbSet<TipoItem> TipoItem { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<Vistoria> Vistoria { get; set; }

        public OficinaBertelliContext(DbContextOptions<OficinaBertelliContext> options)
            :base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK_Clientes");

                entity.Property(e => e.CodigoCliente)
                    .HasColumnName("CODIGO_CLIENTE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .HasColumnName("BAIRRO")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Celular)
                    .HasColumnName("CELULAR")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasColumnType("varchar(9)");

                entity.Property(e => e.Cgc)
                    .HasColumnName("CGC")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Cidade)
                    .HasColumnName("CIDADE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Complemento)
                    .HasColumnName("COMPLEMENTO")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Endereco)
                    .HasColumnName("ENDERECO")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasColumnName("NOME_CLIENTE")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Pais)
                    .HasColumnName("PAIS")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.TelCom)
                    .HasColumnName("TEL_COM")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TelRes)
                    .HasColumnName("TEL_RES")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<HistItem>(entity =>
            {
                entity.HasKey(e => e.IdHitem)
                    .HasName("PK_HistItem");

                entity.Property(e => e.IdHitem).HasColumnName("ID_HITEM");

                entity.Property(e => e.Historico)
                    .HasColumnName("HISTORICO")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Item).HasColumnName("ITEM");

                entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");

                entity.Property(e => e.Sequencia).HasColumnName("SEQUENCIA");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.OrdemServico)
                    .HasName("PK_Historico");

                entity.Property(e => e.OrdemServico)
                    .HasColumnName("ORDEM_SERVICO")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoCliente).HasColumnName("CODIGO_CLIENTE");

                entity.Property(e => e.CodigoVeiculo).HasColumnName("CODIGO_VEICULO");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.Obs)
                    .HasColumnName("OBS")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("PLACA")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Sequencia).HasColumnName("SEQUENCIA");

                entity.Property(e => e.Tecnico)
                    .IsRequired()
                    .HasColumnName("TECNICO")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ValorTotal)
                    .IsRequired()
                    .HasColumnName("VALOR_TOTAL")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Modelos>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_Modelos");

                entity.Property(e => e.Codigo)
                    .HasColumnName("CODIGO")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodMontadora).HasColumnName("COD_MONTADORA");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("MODELO")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Montadoras>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_Montadoras");

                entity.Property(e => e.Codigo)
                    .HasColumnName("CODIGO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Montadora)
                    .IsRequired()
                    .HasColumnName("MONTADORA")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TipoItem>(entity =>
            {
                entity.HasKey(e => e.Tipo)
                    .HasName("PK_TipoItem");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ano)
                    .IsRequired()
                    .HasColumnName("ANO")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.CodCliente).HasColumnName("COD_CLIENTE");

                entity.Property(e => e.CodModelo).HasColumnName("COD_MODELO");

                entity.Property(e => e.CodMontadora).HasColumnName("COD_MONTADORA");

                entity.Property(e => e.CodVeiculo).HasColumnName("COD_VEICULO");

                entity.Property(e => e.Combustivel)
                    .IsRequired()
                    .HasColumnName("COMBUSTIVEL")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Cor)
                    .HasColumnName("COR")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("MODELO")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("PLACA")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Vistoria>(entity =>
            {
                entity.HasKey(e => e.Sequencia)
                    .HasName("PK_Vistoria");

                entity.Property(e => e.Sequencia)
                    .HasColumnName("SEQUENCIA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Km)
                    .HasColumnName("KM")
                    .HasColumnType("varchar(10)");
            });
        }
    }
}