using MonitoramentoApagao.Models;

namespace MonitoramentoApagao.Services
{
    public class Sistema
    {
        private Usuario usuario;
        private List<Evento> eventos = new List<Evento>();

        public void Iniciar()
        {
            Console.WriteLine("=== Central de Monitoramento ===");
            Console.Write("Usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            usuario = new Usuario(nome, "1234"); // senha padrão
            if (!usuario.Autenticar(senha))
            {
                Console.WriteLine("❌ Senha incorreta.");
                return;
            }

            Menu();
        }

        private void Menu()
        {
            int opcao = -1;
            while (opcao != 0)
            {
                Console.WriteLine("\n=== Menu Principal ===");
                Console.WriteLine("1 - Registrar Falha");
                Console.WriteLine("2 - Ver Histórico");
                Console.WriteLine("3 - Simular Ataque");
                Console.WriteLine("4 - Gerar Relatório");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1: RegistrarFalha(); break;
                        case 2: VerHistorico(); break;
                        case 3: SimularAtaque(); break;
                        case 4: GerarRelatorio(); break;
                        case 0: Console.WriteLine("Encerrando..."); break;
                        default: Console.WriteLine("Opção inválida."); break;
                    }
                }
                catch
                {
                    Console.WriteLine("Erro: entrada inválida.");
                }
            }
        }

        private void RegistrarFalha()
        {
            Console.Write("Descrição da falha: ");
            string desc = Console.ReadLine();
            eventos.Add(new Evento(desc));
            Console.WriteLine("✅ Falha registrada.");
        }

        private void VerHistorico()
        {
            Console.WriteLine("--- Histórico de Eventos ---");
            if (eventos.Count == 0)
            {
                Console.WriteLine("Nenhum evento registrado.");
                return;
            }
            foreach (var e in eventos)
                Console.WriteLine(e);
        }

        private void SimularAtaque()
        {
            Console.WriteLine("⚠️ Tentativa de acesso não autorizado detectada!");
            Console.WriteLine("Ação bloqueada e registrada.");
            eventos.Add(new MonitoramentoApagao.Models.Evento("Tentativa de invasão simulada"));
        }

        private void GerarRelatorio()
        {
            string caminho = "relatorio_eventos.txt";
            try
            {
                File.WriteAllLines(caminho, eventos.Select(e => e.ToString()));
                Console.WriteLine($"📄 Relatório gerado: {caminho}");
            }
            catch
            {
                Console.WriteLine("Erro ao gerar o relatório.");
            }
        }
    }
}
