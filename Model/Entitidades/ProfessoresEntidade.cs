﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitidades
{
    public class ProfessoresEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }

        public DataRow Linha()
        {
            throw new NotImplementedException();
        }
    }
}
