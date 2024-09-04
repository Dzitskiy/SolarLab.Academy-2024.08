namespace SolarLab.Academy.AppServices.Exceptions;

public class EntitiesNotFoundException : HumanReadableException
{
    public EntitiesNotFoundException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public EntitiesNotFoundException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}