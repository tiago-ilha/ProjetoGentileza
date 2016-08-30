using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Data.Mapeamentos.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoGentileza.ControleDeAcesso.Data.Mapeamentos
{
	public class HistoricoPerfilMap : EntityTypeConfiguration<HistoricoPerfil>, IMapeamento
	{
		public HistoricoPerfilMap()
		{
			ToTable("HistoricoPerfil");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(x => x.Observacao).HasColumnType("varchar").HasMaxLength(320).IsOptional();
		}
	}
}
