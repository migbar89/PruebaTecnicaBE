using System.Runtime.Serialization;
using AppUsers.Dominio.Interfaces;

namespace AppUsers.Dominio.Exceptions;

public class CoreValidationException : Exception, ICoreException
{
    private const int HttpCode = 412;
    private readonly GenericResponse _genericResponse;

    public CoreValidationException(string errorMessage, List<Validation> validationList)
    {
        _genericResponse = new GenericResponse
        {
            ErrorMessage = errorMessage,
            ValidationErrors = validationList,
            StatusCode = HttpCode
        };
    }

    public GenericResponse GenericResponse()
    {
        return _genericResponse;
    }




}