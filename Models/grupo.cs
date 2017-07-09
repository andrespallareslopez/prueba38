using System;
using System.Collections.Generic;
namespace prueba38.Models {
    public class Grupo {

      public Grupo() {
        familias = new HashSet<Familia>();
      }
      public Int32 Id {get;set;}
      public string Descripcion{get;set;}

      public virtual ICollection<Familia> familias {get;set;}
    }
}

