using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia
{
    public class Barbeiro
    {
        public string Nome { get; set; }
        public string Id { get; set; }
        public List<Agendamento> Agenda { get; set; } = new List<Agendamento>();
    }
}