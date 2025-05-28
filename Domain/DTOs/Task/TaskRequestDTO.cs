using Swashbuckle.AspNetCore.Annotations;


namespace DocumentinAPI.Domain.DTOs.Task
{

    /// <summary>
    /// DTO de Tarefa para requisições de criação ou atualização.
    /// </summary>
    public class TaskRequestDTO
    {

        /// <summary>
        /// Identificador da tarefa. Deve ser nulo para criação de uma nova tarefa.
        /// </summary>
        public int? TaskId { get; set; }

        /// <summary>
        /// Título da tarefa.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição da tarefa.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data limite para conclusão da tarefa.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Enumerador de prioridade da tarefa.
        /// </summary>
        public short Priority { get; set; }

        /// <summary>
        /// Enumerador de status da tarefa.
        /// </summary>
        public short Status { get; set; }

        /// <summary>
        /// Identificador do usuário que a tarefa será destinada.
        /// </summary>
        public int AssigneeId { get; set; } /* Assinalado para */

        /// <summary>
        /// Identificador da tarefa pai, caso seja uma subtarefa.
        /// </summary>
        public int? ParentTaskId { get; set; }

    }
}
