using Mido.PlatformService.Models;

namespace Mido.PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Adds provided object to collection of Platform objects found in instance of AppDbContext
        /// Call SaveChanges() when done.
        /// </summary>
        /// <param name="platform"></param>
        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        /// <summary>
        /// Return collection of Platform objects found in instance of AppDbContext
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Platform? GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault<Platform>(p => p.Id == id);
        }

        /// <summary>
        /// Saves changes using DbContext.
        /// </summary>
        /// <returns>true on success, false otherwise.</returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}