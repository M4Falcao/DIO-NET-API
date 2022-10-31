using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DIO_NET_API.Entities;

namespace DIO_NET_API.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { } //REcebe a config do bando de dados e passa para o EF

        public DbSet<Contato> Contatos { get; set; } //Para ligar á tabela
    }
}