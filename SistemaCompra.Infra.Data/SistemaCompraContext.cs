using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }
        public DbSet<SolicitacaoAgg.SolicitacaoCompra> Solicitacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Produto>();
                //.HasData(
                //    //new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100)
                //);

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            modelBuilder.Entity<SolicitacaoAgg.SolicitacaoCompra>();
                //.HasData(
                //    new SolicitacaoAgg.SolicitacaoCompra("Usuario01", "Fornecedor01")
                //);

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SDSQ0C8\\SQLEXPRESS;Initial Catalog=WebApiDb;Integrated Security=True");
            }

            //optionsBuilder.UseLoggerFactory(loggerFactory)  
            //    .UseSqlServer(@"Data Source=DESKTOP-SDSQ0C8\\SQLEXPRESS;Initial Catalog=WebApiDb;Persist Security Info=True;User ID=sa;Password=Intgaia010265");
        }
    }
}
