using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGerenciadorDeTarefas.Context
{
    public enum StatusTarefa
{
    Pendente,
    EmAndamento,
    Concluida
}
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public StatusTarefa Status { get; set; }
    }
}