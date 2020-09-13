using Microsoft.AspNetCore.Http;

namespace Airline_Yurchenko.FiltersApp
{
    public interface IMyImage<TEntity> where TEntity : class
    {
        string UploadedFile(IFormFile profileImage);
    }
}
