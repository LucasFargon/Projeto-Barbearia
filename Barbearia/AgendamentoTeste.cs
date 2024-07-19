using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Barbearia
{
    public class AgendamentoTeste
    {
        [Fact]
        public static void GerarID()
        {
            int proximoID = 1;
            string conteudoRegistro = "1;Luigi;22222222222;222222222;28/07/2024 13:00:00;Mid Fade;Cavanhaque;Sobrancelha,Corte Navalhado;1;75";
            using (var reader = new StringReader(conteudoRegistro))
            {
                string linhaAtual;
                while ((linhaAtual = reader.ReadLine()) != null)
                {
                    string[] partesLinha = linhaAtual.Split(';');
                    string id = partesLinha[0];
                    proximoID = int.Parse(id) + 1;
                }
            }
            Assert.Equal(2, proximoID);
        }
    }
}
