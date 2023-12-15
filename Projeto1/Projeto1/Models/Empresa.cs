

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Teste
{
    public class Empresa
    {

        public int Id { get; set; }
        public string NomeSocial { get; set; }
        public string NomeFantasia { get; set; }
        public int CNPJ { get; set; }

        public Empresa(int id, string nomeSocial)
        {
            Id = id;
            NomeSocial = nomeSocial;           
        }
    }


}