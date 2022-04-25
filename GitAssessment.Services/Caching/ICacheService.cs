using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAssessment.Services.Caching
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task<T> Set<T>(string key, T value);
    }
}
