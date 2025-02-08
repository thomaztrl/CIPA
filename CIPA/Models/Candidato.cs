// Models/Candidato.cs
namespace CIPA.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        private int _numeroPartido;
        public int NumeroPartido
        {
            get => _numeroPartido;
            set
            {
                if (value.ToString().Length != 4)
                {
                    throw new ArgumentException("O número do partido deve ter exatamente 4 dígitos.");
                }
                _numeroPartido = value;
            }
        }

        public int Votos { get; set; }
    }
}
// Models/Eleitor.cs
namespace CIPA.Models
{
    public class Eleitor
    {
        public int Id { get; set; }
        public string? Nome { get; set; } // Permite valores nulos
        public string? CPF { get; set; } // Permite valores nulos
        public bool Votou { get; set; }
    }
}