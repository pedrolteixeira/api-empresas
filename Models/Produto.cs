using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Produto
    {
        public int Id {get; set;}

        public string Nome {get; set;}

        public int Quantidade {get; set;}

        public float Valor {get; set;}
    }
}