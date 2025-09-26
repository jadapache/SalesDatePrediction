
namespace SalesDatePrediction.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key, string propertyName)
            : base($"Entidad '{name}' con {propertyName} : {key} no encontrada.")
        {
        }
    }
}
