using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XMSBS.Common.NetCore.RepositoryBase
{
    public abstract class EFTBase<IDT>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public IDT Id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacionUTC { get; set; }
       
    }
}
