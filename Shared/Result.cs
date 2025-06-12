namespace Korrekturmanagementsystem.Shared;

public class Result
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    public static Result Success(string? message = "") => new Result { IsSuccess = true, Message = message };
    public static Result Failure(string message) => new Result { IsSuccess = false, Message = message };
}

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static Result<T> Success(T data, string? message = null)
        => new() { IsSuccess = true, Data = data, Message = message };

    public static Result<T> Failure(string message)
        => new() { IsSuccess = false, Message = message };
}
