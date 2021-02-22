﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Entities
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}
