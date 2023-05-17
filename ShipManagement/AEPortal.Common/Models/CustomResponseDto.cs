using System.Text.Json.Serialization;

namespace AEPortal.Common.Models;

public class CustomResponseDto<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }
    [JsonPropertyName("data")]
    public T Data { get; set; }
    [JsonPropertyName("errors")]
    public List<string> Errors { get; set; }
    [JsonPropertyName("message")]
    public List<string> Message { get; set; }
    public static CustomResponseDto<T> SuccessResponse(int statusCode, T data)
    {
        return new CustomResponseDto<T> { Success = true, Data = data, StatusCode = statusCode };
    }

    public static CustomResponseDto<T> SuccessResponse(int statusCode, List<string> msg)
    {
        return new CustomResponseDto<T> { Success = true, StatusCode = statusCode, Message = msg };
    }

    public static CustomResponseDto<T> SuccessResponse(int statusCode)
    {
        return new CustomResponseDto<T> { Success = true, StatusCode = statusCode };
    }

    public static CustomResponseDto<T> FailResponse(int statusCode, List<string> errors)
    {
        return new CustomResponseDto<T> { Success = false, StatusCode = statusCode, Errors = errors };
    }

    public static CustomResponseDto<T> FailResponse(int statusCode, string error)
    {
        return new CustomResponseDto<T> { Success = false, StatusCode = statusCode, Errors = new List<string> { error } };
    }
}

