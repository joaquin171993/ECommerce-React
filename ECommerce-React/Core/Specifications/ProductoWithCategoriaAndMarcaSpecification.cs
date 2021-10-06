using Core.Entities;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(ProductoSpecificationsParams parametros)
            : base(x =>
                 (string.IsNullOrEmpty(parametros.Search) || x.Nombre.Contains(parametros.Search)) &&
                 (!parametros.Marca.HasValue || x.MarcaId == parametros.Marca) &&
                 (!parametros.Categoria.HasValue || x.CategoriaId == parametros.Categoria))  /*en esa evaluacion se especifica que si no tiene o tiene una marca procede a realizar la condicion de criterio
                                                                          igual para categoria*/
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);

            /*aplicar la paginacion*/

            /*El primer parametro va a representar el indice desde el cual se
             van a extraer los elementos, representa al skip (valor desde el cual comienza
            la posicion de extraccion de registros)
            Por ejm: Si mando un page Index 1, entonces 1 - 1 = 0, y cualquier valor
            multiplicado por 0 da resultado 0, siempre empieza por el skip cero*/
            /*El segundo parametros es la cantidad de registros que requiere el cliente*/
            ApplyPaging(parametros.PageSize * (parametros.PageIndex - 1), parametros.PageSize);

            /*Esto es para evaluar el tipo de ordenamiento segun el filtro que 
             se mande por la url*/
            if (!string.IsNullOrEmpty(parametros.Sort))
            {
                switch (parametros.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;
                }
            }
        }

        /*en este caso el criterio de busqueda se envia por el constructor de la clase*/
        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }
    }
}
