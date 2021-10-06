using Core.Entities;

namespace Core.Specifications
{
    public class ProductoForCountingSpecifications : BaseSpecification<Producto>
    {
        public ProductoForCountingSpecifications(ProductoSpecificationsParams parametros)
            : base(x =>
                   (string.IsNullOrEmpty(parametros.Search) || x.Nombre.Contains(parametros.Search)) &&
                   (!parametros.Marca.HasValue || x.MarcaId == parametros.Marca) &&
                   (!parametros.Categoria.HasValue || x.CategoriaId == parametros.Categoria))
        {

        }
    }
}
