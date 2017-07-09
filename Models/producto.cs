using System;

namespace prueba38.Models{
    public class Producto{
        public Int32 ID {get;set;}
        public String Description {get;set;}
        
        public Int32 IDGrupo {get;set;}
        
        public Int32 IDFamilia {get;set;}
        
        public Grupo grupo {get;set;}
        
        public Familia familia{get;set;}
        
    }
}