namespace DS.Domain.Shared;

public static class GeneralErrors
{

    public static Error ValueIsValid(string? field, string message)
    {
        var lable = field ?? "value";
        return Error.Validation($"{lable} is not a valid value", $"{message}", $"{field}");
    }

}