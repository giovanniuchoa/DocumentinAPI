namespace DocumentinAPI.Domain.Utils
{
    public class Enums
    {

        public enum StatusValidacao
        {
            EmAndamento = 0,
            Validado = 1,
            Retornado = 2
        }

        public enum TipoUsuario
        {
            AdministradorDev = 1,
            Gerente = 2,
            Funcionario = 3
        }

        public enum OpenAIModels
        {
            ResumoSimples = 1,
            ConteudoCurto = 2,
            ConteudoLongo = 3
        }


    }
}
