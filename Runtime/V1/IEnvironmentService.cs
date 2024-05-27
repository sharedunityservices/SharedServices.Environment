using SharedServices;
using SharedServices.V1;

namespace Services.Environment
{
    public interface IEnvironmentService : IService
    {
        string Get(string key);
        void Set(string key, string value);
    }
}
