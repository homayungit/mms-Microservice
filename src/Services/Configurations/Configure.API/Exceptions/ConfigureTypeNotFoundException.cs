namespace Configure.API.Exceptions;

public class ConfigureTypeNotFoundException : NotFoundException
{
    public ConfigureTypeNotFoundException(Guid Id) : base("ConfigureType Not Found", $"ConfigureType with Id: {Id} not found.")
    {
    }
}
