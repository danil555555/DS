using System.Collections;

namespace DS.Domain.Shared;

public class Errors : IEnumerable<Error>
{
    private readonly List<Error> _errors;
    
    public Errors(IEnumerable<Error> errors)
    {
        _errors = [..errors];
    }
    
    public Errors(Error error)
    {
        _errors = new List<Error> { error };
    }

    public IEnumerator<Error> GetEnumerator()
    {
        return _errors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}