using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNet_core.Models
{
    public class ObjetoEscuelaBase
    {
        [Key]
        public string UniqueId { get; private set; }
        public virtual string Nombre { get; set; }


        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }


}