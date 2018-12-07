using System;
using System.Collections.Generic;
using AppAssociados.Domain;

namespace AppAssociados.API.DTO
{
    public class AssociadoDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }  

    }
}