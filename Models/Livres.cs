using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioApi.Models
{
    public class Livres
    {
        public Guid Id {get; set;}
        [Required, MinLength(8, ErrorMessage ="Veillez saisir au moins 8 caractères !!!"), MaxLength(55, ErrorMessage ="Veillez sisir au plus 55 caractères !!!")]
        public string Titre {get; set;} = string.Empty;
        [Required, MinLength(100, ErrorMessage ="Veillez saisir au moins 8 caractères !!!"), MaxLength(255, ErrorMessage ="Veillez sisir au plus 55 caractères !!!")]
        public string? Description {get; set;}
        [Required, 
            MinLength(8, ErrorMessage ="Veillez saisir au moins 8 caractères !!!"), 
            MaxLength(55, ErrorMessage ="Veillez sisir au plus 55 caractères !!!"),
            RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
            ErrorMessage = "Pas de caractère spéciaux svp !")]
        public string? Editeur {get; set; }
        public long anneeEdition {get; set;}
        [Column(TypeName="image")]
        public byte[]? ImageBook {get; set;}


       
    }
}