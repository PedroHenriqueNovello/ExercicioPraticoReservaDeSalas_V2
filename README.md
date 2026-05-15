# Sistema de Reserva de Salas de Estudo - Extensão V2

## 📖 Visão Geral do Projeto
Este repositório contém a extensão do sistema de "Reserva de Salas de Estudo", desenvolvido originalmente para aplicar conceitos de Programação Orientada a Objetos e Padrões de Projeto. Esta versão foca na modularização da criação de reservas através da implementação de funcionalidades complexas e opcionais, permitindo uma experiência mais personalizada para o campus universitário.

## 🚀 Extensão e Colaboração
Dando continuidade ao trabalho iniciado com **Letícia Abrahão Moreira**, esta extensão foi modelada e implementada em colaboração com **Rafael Kenzo**, visando atender aos novos requisitos de flexibilidade e expansão do sistema.

## 🏗️ Padrão de Projeto Adicionado: Builder
Conforme proposto nas diretrizes de extensão do projeto, implementamos o padrão GoF **Builder** para gerenciar a construção de objetos de reserva que possuem múltiplos atributos opcionais.

### Justificativa do Padrão
O padrão Builder foi escolhido para separar a construção de um objeto complexo da sua representação final. Isso traz as seguintes vantagens:
* **Separação de Responsabilidades**: A classe `Reserva` permanece focada no domínio, enquanto o `ReservaBuilder` cuida da lógica de montagem.
* **Flexibilidade**: Permite criar diferentes representações do mesmo tipo de objeto sem a necessidade de múltiplos construtores.
* **Legibilidade**: A implementação utiliza uma *Fluent Interface*, tornando o código de criação altamente intuitivo.
* **Segurança na Criação**: O método `Build()` inclui validações que garantem que campos obrigatórios (Id, Sala, Usuário e Horário) sejam preenchidos antes da instância ser gerada.

## ⚙️ Funcionalidades Adicionais (Itens Opcionais)
Através do `ReservaBuilder`, o sistema agora permite configurar modularmente as seguintes funcionalidades para cada reserva:
* **Serviço de Limpeza (`TemLimpeza`)**: Solicitação de higienização prévia ou posterior ao uso da sala.
* **Equipamento Multimídia (`TemEquipamento`)**: Reserva automática de projetores ou sistemas de som integrados.
* **Acessibilidade (`Acessibilidade`)**: Configuração que garante que a sala atenda a requisitos de acesso para pessoas com deficiência.

## 💻 Exemplo de Uso (Fluent Interface)
```csharp
// Exemplo de criação de uma reserva completa usando o Builder
Reserva reservaV2 = new ReservaBuilder()
    .ComId("RES-V2-001")
    .ComSala(salaTrabalhoGrupo)
    .ComUsuario(alunoPedro)
    .ComHorario(DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(4))
    .ComLimpeza()        // Opcional
    .ComEquipamento()    // Opcional
    .ComAcessibilidade() // Opcional
    .Build();