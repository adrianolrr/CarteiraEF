using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarteiraEF.Models
{
    public class PessoaContext : DbContext
    {
        public PessoaContext() : base("DatabaseCarteira")
        { }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { }
    }
}