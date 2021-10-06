namespace Core.Specifications
{
    public class ProductoSpecificationsParams
    {
        public int? Marca { get; set; }
        public int? Categoria { get; set; }
        public string Sort { get; set; }
        public int PageIndex { get; set; } = 1;

        private const int MaxPageSize = 50;

        private int _pageSize = 3; /*numero de elementos que 
                                    * devuelve por pagina,
                                    en este caso por defecto es 3*/

        /*si por ejm se envia 1000 como pageSize, entonces va a devolver unicamente 50, porque 
         es el tamaño que define la logica en este caso, pero si solicita 25 devuelve esos 25*/
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Search { get; set; }
    }
}
