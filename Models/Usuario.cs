﻿namespace MonitoramentoApagao.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public bool Autenticar(string senhaDigitada)
        {
            return Senha == senhaDigitada;
        }
    }
}
