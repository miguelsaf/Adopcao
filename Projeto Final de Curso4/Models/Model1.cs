using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Projeto_Final_de_Curso4.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<tb_adopcao> tb_adopcao { get; set; }
        public virtual DbSet<tb_animal> tb_animal { get; set; }
        public virtual DbSet<tb_cliente> tb_cliente { get; set; }
        public virtual DbSet<tb_cor> tb_cor { get; set; }
        public virtual DbSet<tb_devolucao_de_animal> tb_devolucao_de_animal { get; set; }
        public virtual DbSet<tb_disponibilidade_do_animal> tb_disponibilidade_do_animal { get; set; }
        public virtual DbSet<tb_estado_da_adopcao> tb_estado_da_adopcao { get; set; }
        public virtual DbSet<tb_funcionario> tb_funcionario { get; set; }
        public virtual DbSet<tb_genero> tb_genero { get; set; }
        public virtual DbSet<tb_municipio> tb_municipio { get; set; }
        public virtual DbSet<tb_tipo_de_animal> tb_tipo_de_animal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tb_adopcao>()
                .Property(e => e.data_de_entrega)
                .IsUnicode(false);

            modelBuilder.Entity<tb_adopcao>()
                .Property(e => e.data_de_solicitacao_do_animal)
                .IsUnicode(false);

            modelBuilder.Entity<tb_adopcao>()
                .HasMany(e => e.tb_devolucao_de_animal)
                .WithRequired(e => e.tb_adopcao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_animal>()
                .Property(e => e.idade)
                .IsUnicode(false);

            modelBuilder.Entity<tb_animal>()
                .Property(e => e.raca)
                .IsUnicode(false);

            modelBuilder.Entity<tb_animal>()
                .Property(e => e.peso)
                .IsUnicode(false);

            modelBuilder.Entity<tb_animal>()
                .HasMany(e => e.tb_adopcao)
                .WithRequired(e => e.tb_animal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_cliente>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cliente>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cliente>()
                .Property(e => e.rua_casa)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cliente>()
                .Property(e => e.n_BI)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cliente>()
                .Property(e => e.ocupacao)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cliente>()
                .Property(e => e.data_de_nascimento)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cor>()
                .Property(e => e.cor)
                .IsUnicode(false);

            modelBuilder.Entity<tb_cor>()
                .HasMany(e => e.tb_animal)
                .WithRequired(e => e.tb_cor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_devolucao_de_animal>()
                .Property(e => e.motivo_da_devolucao)
                .IsUnicode(false);

            modelBuilder.Entity<tb_devolucao_de_animal>()
                .Property(e => e.data_da_devolucao)
                .IsUnicode(false);

            modelBuilder.Entity<tb_disponibilidade_do_animal>()
                .Property(e => e.disponibilidade_do_animal)
                .IsUnicode(false);

            modelBuilder.Entity<tb_disponibilidade_do_animal>()
                .HasMany(e => e.tb_animal)
                .WithRequired(e => e.tb_disponibilidade_do_animal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_estado_da_adopcao>()
                .Property(e => e.estado_da_adopcao)
                .IsUnicode(false);

            modelBuilder.Entity<tb_estado_da_adopcao>()
                .HasMany(e => e.tb_adopcao)
                .WithRequired(e => e.tb_estado_da_adopcao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_funcionario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tb_funcionario>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<tb_funcionario>()
                .Property(e => e.rua_casa)
                .IsUnicode(false);

            modelBuilder.Entity<tb_funcionario>()
                .Property(e => e.n_BI)
                .IsUnicode(false);

            modelBuilder.Entity<tb_genero>()
                .Property(e => e.genero)
                .IsUnicode(false);

            modelBuilder.Entity<tb_genero>()
                .HasMany(e => e.tb_animal)
                .WithRequired(e => e.tb_genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_genero>()
                .HasMany(e => e.tb_cliente)
                .WithRequired(e => e.tb_genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_genero>()
                .HasMany(e => e.tb_funcionario)
                .WithRequired(e => e.tb_genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_municipio>()
                .Property(e => e.municipio)
                .IsUnicode(false);

            modelBuilder.Entity<tb_municipio>()
                .HasMany(e => e.tb_cliente)
                .WithRequired(e => e.tb_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_municipio>()
                .HasMany(e => e.tb_funcionario)
                .WithRequired(e => e.tb_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_tipo_de_animal>()
                .Property(e => e.tipo_de_animal)
                .IsUnicode(false);

            modelBuilder.Entity<tb_tipo_de_animal>()
                .HasMany(e => e.tb_animal)
                .WithRequired(e => e.tb_tipo_de_animal)
                .WillCascadeOnDelete(false);
        }
    }
}
