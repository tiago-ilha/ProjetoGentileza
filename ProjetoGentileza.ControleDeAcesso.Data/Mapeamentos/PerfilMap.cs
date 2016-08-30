using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Data.Mapeamentos.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoGentileza.ControleDeAcesso.Data.Mapeamentos
{
	public class PerfilMap : EntityTypeConfiguration<Perfil>, IMapeamento
	{
		public PerfilMap()
		{
			ToTable("Perfil");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(80).IsRequired();
			Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(280).IsOptional();

			HasMany(x => x.Historicos).WithRequired().HasForeignKey(x => x.IdPerfil);
		}
	}
}
