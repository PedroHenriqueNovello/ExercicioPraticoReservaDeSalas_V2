using System;
using System.Collections.Generic;

namespace ReservaDeSalas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("  SISTEMA DE RESERVA DE SALAS - V2   ");
            Console.WriteLine("=====================================\n");

            // 1. SINGLETON: Instância única do Gerenciador
            var gerenciador = GerenciadorDeReservasSala.getInstance();

            // 2. FACTORY METHOD: Criando salas
            SalaFactory fabricaIndividual = new SalaIndividualFactory();
            Sala salaA1 = fabricaIndividual.CriarSala("A1");

            // 3. Criando os Usuários
            Usuario aluno = new Usuario("Pedro Henrique") { IsDocente = false };
            Usuario professor = new Usuario("Profa. Letícia") { IsDocente = true };

            // 4. OBSERVER: Inscrevendo usuários para receberem notificações
            gerenciador.AddObserver(aluno);
            gerenciador.AddObserver(professor);

            // 5. STRATEGY: Escolhendo a regra de colisão
            IPoliticaDeReserva politica = new PoliticaPrimeiroChegar();

            // 6. BUILDER: Criando uma Reserva Complexa com Opcionais
            Console.WriteLine("[SISTEMA] Construindo reserva com padrão Builder...\n");
            
            Reserva reserva1 = new ReservaBuilder()
                .ComId("RES-V2-001")
                .ComSala(salaA1)
                .ComUsuario(aluno)
                .ComHorario(DateTime.Now, DateTime.Now.AddHours(2))
                .ComLimpeza()        // Configurando atributo opcional
                .ComEquipamento()    // Configurando atributo opcional
                .ComAcessibilidade() // Configurando atributo opcional
                .Build();

            // Imprimindo no terminal para provar que o Builder funcionou
            Console.WriteLine($"[DEBUG] Detalhes da Reserva Montada:");
            Console.WriteLine($" - ID: {reserva1.Id}");
            Console.WriteLine($" - Sala: {reserva1.Sala.Id}");
            Console.WriteLine($" - Usuário: {reserva1.Usuario.Nome}");
            Console.WriteLine($" - Limpeza Solicitada: {reserva1.TemLimpeza}");
            Console.WriteLine($" - Equipamento Solicitado: {reserva1.TemEquipamento}");
            Console.WriteLine($" - Acessibilidade: {reserva1.Acessibilidade}\n");

            Console.WriteLine("[SISTEMA] Tentando processar a reserva...\n");

            // Validando a reserva com a Política de Colisão
            if (politica.AprovarReserva(reserva1, gerenciador.GetReservas()))
            {
                // Se aprovada, o gerenciador adiciona e notifica os Observers automaticamente!
                gerenciador.AdicionarReserva(reserva1);
            }
            else
            {
                Console.WriteLine("[ERRO] Conflito de horário detectado!");
            }

            Console.WriteLine("\n[SISTEMA] Pressione qualquer tecla para fechar...");
            Console.ReadKey();
        }
    }
}