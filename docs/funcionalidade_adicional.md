#Funcionalidade adicional para a implementacao do padrao builder 

## Descrição:
Implementa o padrão na hora da criação a classe Reserva.A funcionalidade permite configurar recursos opcionais como limpeza, equipamentos e acessibilidade.

## Justificativa: 
O padrão Builder foi escolhido porque a classe Reserva possui campos obrigatórios (Id, Sala, Usuario, Horario) e opcionais (TemLimpeza, TemEquipamento, Acessibilidade). Sem o Builder, qualquer parte do sistema poderia criar uma reserva incompleta sem perceber. Com ele, o
objeto só é gerado depois que o Build() confirma que os campos obrigatórios estão presentes.

## Como Testar
1. Instancie a classe `ReservaBuilder`.
2. Utilize os métodos encadeados (ex: `.ComSala()`, `.ComLimpeza()`).
3. Chame o método `.Build()` para gerar o objeto `Reserva`.