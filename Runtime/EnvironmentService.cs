using System.IO;
using UnityEngine;

namespace Services.Environment
{
    public class EnvironmentService : IEnvironmentService
    {
        public string Get(string key)
        {
            // Check Environment Variable First
            var value = System.Environment.GetEnvironmentVariable(key);
            if (value != null) return value;
            
            // Check PlayerPrefs
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetString(key);
            
            // Check local .env file
            value = GetFromFile(key, $".env");
            if (value != null) return value;
            
            // Check persistent data path .env file
            value = GetFromFile(key, $"{Application.persistentDataPath}/.env");
            return value;
        }

        private string GetFromFile(string key, string path)
        {
            if (!File.Exists(path)) return null;
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length == 2 && parts[0] == key)
                {
                    return parts[1];
                }
            }
            return null;
        }

        public void Set(string key, string value)
        {
            System.Environment.SetEnvironmentVariable(key, value);
        }
    }
}