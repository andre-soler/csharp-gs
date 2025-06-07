using MonitoramentoApagao.Models;
using MonitoramentoApagao.Services;

class Program
{
    static void Main(string[] args)
    {
       MonitoramentoApagao.Services.Sistema sistema = new MonitoramentoApagao.Services.Sistema();
        sistema.Iniciar();
    }
}
