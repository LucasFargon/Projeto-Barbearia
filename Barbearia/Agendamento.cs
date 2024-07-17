using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Barbearia
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Barbeiro Barbeiro { get; set; }
        public DateTime DataHora { get; set; }
        public Cabelo Cabelo { get; set; }
        public Barba Barba { get; set; }
        public List<Outros> Outros { get; set; } = new List<Outros>();
        public double PrecoTotal
        {
            get
            {
                double total = 0;
                if (Cabelo != null) total += Cabelo.Preco;
                if (Barba != null) total += Barba.Preco;
                if (Outros != null)
                {
                    foreach (var outro in Outros) { total += outro.Preco;}
                }
                return total;
            }
            set { }
        }
        public static int GerarID()
        {
           int proximoID = 1;
            
           if (File.Exists("Pasta de Registros\\registrosBarbearia.txt"))
            {
                if(new FileInfo("Pasta de Registros\\registrosBarbearia.txt").Length > 0)
                {
                    using (StreamReader reader = new StreamReader("Pasta de Registros\\registrosBarbearia.txt"))
                    {
                        string linhaAtual;
                        while((linhaAtual = reader.ReadLine()) != null)
                        {
                            string[] partesLinha = linhaAtual.Split(';');
                            string id = partesLinha[0];
                            proximoID = int.Parse(id) + 1;
                        }
                    }
                }
            }
            return proximoID;
        }
    }
}