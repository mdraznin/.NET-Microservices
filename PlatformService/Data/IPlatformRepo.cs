using Mido.PlatformService.Models;

namespace Mido.PlatformService.Data
{
    public interface IPlatformRepo 
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform? GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}