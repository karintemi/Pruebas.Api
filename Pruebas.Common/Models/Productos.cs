using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pruebas.Common.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        // Para que la descripcion no se pueda repetir
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notas { get; set; }
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }
        //[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Decimal Precio { get; set; }
        public bool Disponible { get; set; }
        [Display(Name = "Publicado el")]
        [DataType(DataType.Date)]
        public DateTime Publicado { get; set; }

        [Required]
        [StringLength(128)]
        public string IdUser { get; set; }
        //Esto hace la relacion de producto con categoria
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagePath))
                    return "sinimagen";
                return $"http://ventasapi1307.azurewebsites.net/{ImagePath.Substring(1)}".Replace(" ", "");
            }
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
