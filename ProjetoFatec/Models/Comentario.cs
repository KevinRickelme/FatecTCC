namespace ProjetoFatec.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int IdPublicacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
    }
}
