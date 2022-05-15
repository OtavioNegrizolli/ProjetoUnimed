namespace Api.Utils
{
    public class IndexOptions
    {
        public int NumeroPagina { get; set; } = 0;
        public int ElementosPagina { get; set; } = 10;
        public string CampoFiltro { get; set; } = "Id";
        public bool Decrescente { get; set; } = true;
        public static IndexOptions DefaultOptions 
        {
            get => new IndexOptions();
        }
    }
}
