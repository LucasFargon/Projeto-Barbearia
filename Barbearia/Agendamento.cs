using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia
{
    public class Agendamento
    {
        public Cliente Cliente { get; set; }
        public Barbeiro Barbeiro { get; set; }
        public DateTime DataHora { get; set; }
        public Cabelo Cabelo { get; set; }
        public Barba Barba { get; set; }
        public Outros Outros { get; set; }
        public double PrecoTotal
        {
            get
            {
                double total = 0;
                if (Cabelo != null) total += Cabelo.Preco;
                if (Barba != null) total += Barba.Preco;
                if (Outros != null) total += Outros.Preco;
                return total;
            }
        }

    }
}