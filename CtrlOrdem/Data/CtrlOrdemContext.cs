using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CtrlOrdem.Models;

namespace CtrlOrdem.Data
{
    public class CtrlOrdemContext : DbContext
    {
        public CtrlOrdemContext (DbContextOptions<CtrlOrdemContext> options)
            : base(options)
        {
        }

        public DbSet<CtrlOrdem.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<CtrlOrdem.Models.Financeiro> Financeiro { get; set; } = default!;
        public DbSet<CtrlOrdem.Models.Ordem> Ordem { get; set; } = default!;
        public DbSet<CtrlOrdem.Models.Servico> Servico { get; set; } = default!;
        public DbSet<CtrlOrdem.Models.Tecnico> Tecnico { get; set; } = default!;
    }
}
