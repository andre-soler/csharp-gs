using System;

namespace MonitoramentoApagao.Models
{
    public class Evento
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

        public Evento(string descricao)
        {
            DataHora = DateTime.Now;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"[{DataHora:dd/MM/yyyy HH:mm}] {Descricao}";
        }
    }
}
