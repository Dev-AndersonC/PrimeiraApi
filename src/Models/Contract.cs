namespace Apizinha.src.Models
{
    public class Contract
    {
        public DateTime DataCriacao { get; set; }
        public string TokenId { get; set; }
        public double Valor { get; set; }
        public bool Pago { get; set; }
        public  int Id { get; set; }
        public int PessoaId { get; set; }

        public Contract()
        {
            this.DataCriacao = DateTime.Now;
            this.Valor = 0;
            this.TokenId = "000000";
            this.Pago = false;
        }
        public Contract(string token,double valor)
        {
            this.DataCriacao = DateTime.Now;
            this.TokenId = token;
            this.Valor = valor;
            this.Pago = false;
        }
    }

}
