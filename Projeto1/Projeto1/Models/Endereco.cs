namespace Teste
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string EnderecoCompleto { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public int Empresa { get; set; }

        Endereco(int id, int cep, string enderecoCompleto, string bairro, int numero, string cidade, int empresa)
        {
            Id = id;
            Cep = cep;
            EnderecoCompleto = enderecoCompleto;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Empresa = empresa;
        }

        public Endereco(int empresa)
        {
            Empresa = empresa;
        }
    }
}