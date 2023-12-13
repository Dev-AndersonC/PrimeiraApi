using System.Collections.Generic;


namespace Apizinha.src.Models
{
    public class Person
    { //Nome, cpf, idade, ativada
        public Person()
        {
            this.Nome = "Guilo";
            this.Idade = 0;
            this.Ativo = true;
            this.contratos = new List<Contract>();
        }

        public Person(string nome, int idade,string cpf)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;
            this.Ativo = true;
            this.contratos = new List<Contract>();

        }

        public int Id { get; set; }
        public string Nome {  get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public string? Cpf { get; set; }

        public List<Contract> contratos { get; set; }


    }


}
