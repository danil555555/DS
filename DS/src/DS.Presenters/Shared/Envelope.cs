using DS.Domain.Shared;

namespace DS.Presenters.Shared;

public class Envelope<T>
{
    public T? Result { get; }

    public List<Error>? Errors { get; }

    public DateTime TimeGenerated { get; }

    private Envelope(T? result, List<Error>? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.UtcNow;
    }

    public static Envelope<T> Ok(T result)
    {
        return new Envelope<T>(result, null);
    }

    public static Envelope<T> Fail(List<Error> errors)
    {
        return new Envelope<T>(default, errors);
    }

    public static Envelope<T> FromErrors(Errors errors)
    {
        return new Envelope<T>(default, errors.ToList());
    }
}