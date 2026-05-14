using System;

namespace ReservaDeSalas
{
    public class ReservaBuilder
    {
        private string   _id;
        private Sala     _sala;       
        private Usuario  _usuario;   
        private DateTime _inicio;     
        private DateTime _fim;
        private bool _temLimpeza     = false;
        private bool _temEquipamento = false;
        private bool _acessibilidade = false;

        public ReservaBuilder()
        {
            Reset();
        }

        public ReservaBuilder Reset()
        {
            _id             = null;
            _sala           = null;
            _usuario        = null;
            _inicio         = default;
            _fim            = default;
            _temLimpeza     = false;
            _temEquipamento = false;
            _acessibilidade = false;
            return this;
        }

        public ReservaBuilder ComId(string id)
        {
            _id = id;
            return this;
        }

        public ReservaBuilder ComSala(Sala sala)     
        {
            _sala = sala;
            return this;
        }

        public ReservaBuilder ComUsuario(Usuario usuario) 
        {
            _usuario = usuario;
            return this;
        }

        public ReservaBuilder ComHorario(DateTime inicio, DateTime fim)  
        {
            _inicio = inicio;
            _fim    = fim;
            return this;
        }

        public ReservaBuilder ComLimpeza()
        {
            _temLimpeza = true;
            return this;
        }

        public ReservaBuilder ComEquipamento()
        {
            _temEquipamento = true;
            return this;
        }

        public ReservaBuilder ComAcessibilidade()
        {
            _acessibilidade = true;
            return this;
        }

        public Reserva Build()
        {
            if (string.IsNullOrEmpty(_id) || _sala == null
                || _usuario == null || _inicio == default || _fim == default)
            {
                throw new InvalidOperationException(
                    "Id, Sala, Usuário e Horário são campos obrigatórios para a reserva.");
            }

            var reserva = new Reserva   
            {
                Id             = _id,
                Sala           = _sala,
                Usuario        = _usuario,
                Inicio         = _inicio,
                Fim            = _fim,
                TemLimpeza     = _temLimpeza,
                TemEquipamento = _temEquipamento,
                Acessibilidade = _acessibilidade,
                Detalhes       = "ATIVA"
            };

            Reset();
            return reserva;
        }
    }
}