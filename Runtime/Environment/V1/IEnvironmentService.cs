using SharedServices.V1;

namespace SharedServices.Environment.V1
{
    public interface IEnvironmentService : IService
    {
        string Get(string key);
        void Set(string key, string value);
    }
}
