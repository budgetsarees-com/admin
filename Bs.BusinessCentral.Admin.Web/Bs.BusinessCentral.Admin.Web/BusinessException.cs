namespace Bs.BusinessCentral.Admin.Web;

/// <summary>
/// Business validation exception
/// </summary>
public class BusinessException : Exception
{
    public string[] Message { get; set; } = [];

    public BusinessException() : base() { }

    public BusinessException(string[] message) : base() { }

    public BusinessException(string message, System.Exception innerException) : base(message, innerException) { }
}