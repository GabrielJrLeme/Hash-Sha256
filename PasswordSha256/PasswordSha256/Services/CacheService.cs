using PasswordSha256.Models;
using System.Collections.Concurrent;

namespace PasswordSha256.Services
{
    public class CacheService
    {
        public ConcurrentDictionary<string, Registros> Cache { get;}

        public CacheService()
        {
            Cache = new ConcurrentDictionary<string, Registros>();
        }
    }
}
