namespace Mango.web.Models
{
    public class RequestDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; }=true
        public string Message { get; set; }="";

    }
}
