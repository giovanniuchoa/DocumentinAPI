namespace DocumentinAPI.Domain.DTOs.Email
{
    public class CommentEmailTemplateDTO
    {

        public string UserDocument { get; set; }
        public string UserComment { get; set; }
        public string DocumentTitle { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
