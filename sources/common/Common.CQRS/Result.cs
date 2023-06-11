namespace Common.CQRS;

public class Result<T> : Result
{
    public T Value { get; set; }

    protected internal Result(
        T value,
        bool success,
        string error) : base(success, error) => Value = value;
}

public class Result
{
    public bool Success { get; }
    public string Error { get; private set; }
    public bool IsFailure => !Success;

    public Result(bool success, string error)
    {
        if (success && error != string.Empty)
            throw new InvalidOperationException();
        if (!success && error == string.Empty)
            throw new InvalidOperationException();

        Success = success;
        Error = error;
    }

    public static Result Fail(string message) => new(false, message);

    public static Result<T> Fail<T>(string message)
        => new(default!, false, message);

    public static Result Ok() => new(true, string.Empty);

    public static Result<T> Ok<T>(T value)
        => new(value, true, string.Empty);
}