using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba38.Models {
    public class Familia {
        public Int32 ID {get;set;}
        public String Description {get;set;}   
        public  Int32? IDGrupo {get;set;}
        [ForeignKey("Grupo")]
        public Int32? grupoId {get;set;}
        public virtual Grupo grupo {get;set;}
        
    }
}