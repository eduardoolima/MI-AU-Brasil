using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIEAUBRASIL.Models
{
    public class AnimalDoador
    {
        //Animal
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite um Nome de 3 a 20 caracteres")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Digite um Nome de 3 a 20 caracteres")]
        public string NomeAnimal { get; set; }
        [Required]
        public string Especie { get; set; }
        [Required]
        public string Genero { get; set; }
        public string Deficiencia { get; set; }
        public bool Vacinado { get; set; }
        public bool Castrado { get; set; }
        public string Observacao { get; set; }
        [Required(ErrorMessage = "Insira uma data!")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataResgate { get; set; }
        public int? Idade { get; set; }
        public string Porte { get; set; }
        public string PathFoto { get; set; }
        [Required(ErrorMessage = "Digite uma senha de 3 a 5 caracteres")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Digite uma senha de 3 a 5 caracteres")]
        public string Codigo { get; set; }
        [NotMapped]
        public string ConfirmaCod { get; set; }
        [NotMapped]
        public string UrlWhatsapp { get; set; }

        //Doador
        [Required(ErrorMessage = "Digite um Nome de 3 a 20 caracteres")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Digite um Nome de 3 a 20 caracteres")]
        public string NomeDoador { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite um Número no formato (xx)9xxxx-xxxx")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$", ErrorMessage = "Digite um Número no formato (xx)9xxxx-xxxx")]
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Nome da sua Cidade")]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }        
    }

    public enum genero
    {
        Selecione, Macho, Fêmea
    }
    public enum porte
    {
        Selecione, Pequeno, Médio, Grande
    }
    public enum especie
    {
        Selecione, Cachorro, Gato
    }
    public enum Estado
    {
        Selecione, AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MG ,MS, MT, PA, PB, PE, PI, PR, RJ, RN, RO, RR, RS, SC, SE, SP, TO
    }
}
