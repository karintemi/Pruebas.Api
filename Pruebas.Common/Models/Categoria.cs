using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Pruebas.Common.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        // Relacion de una categoria con N productos
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return "sinimagen";
                }

                return $"http://ventasapi1307.azurewebsites.net{this.ImagePath.Substring(1)}";
            }
        }
    }
}
