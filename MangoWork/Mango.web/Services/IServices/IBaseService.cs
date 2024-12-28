using Mango.web.Models;

namespace Mango.web.Services.IServices
{
    public interface IBaseService
    {
       Task<ResponseDto?> sendAsync(RequestDto requestDto , bool withBearer);
        
    }
}
