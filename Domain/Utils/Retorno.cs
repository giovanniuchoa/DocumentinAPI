namespace DocumentinAPI.Domain.Utils
{
    public class Retorno<T>
    {

        public string Mensagem { get; set; }

        public T Objeto { get; set; }

        public bool Erro { get; set; }


        #region Sucesso

        public void SetSucesso()
        {
            SetSucesso(null);
        }

        public void SetSucesso(string mensagem)
        {
            this.Erro = false;
            this.Mensagem = string.IsNullOrEmpty(mensagem) ? "success" : mensagem;
        }

        #endregion

        #region Erro

        public void SetErro()
        {
            SetErro(null);
        }

        public void SetErro(string mensagem)
        {
            this.Erro = true;
            this.Mensagem = string.IsNullOrEmpty(mensagem) ? "error" : mensagem;
        }

        #endregion

    }
}
