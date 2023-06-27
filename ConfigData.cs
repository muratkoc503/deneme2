using System;
using System.IO;

namespace WebApplication5
{
    public class ConfigData
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static ConfigData ReadConfigData(string yamlName)
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, yamlName);

                if (!File.Exists(configPath))
                {
                    throw new FileNotFoundException();
                }

                string yamlContent = File.ReadAllText(configPath);

                var deserializer = new YamlDotNet.Serialization.Deserializer();
                var configData = deserializer.Deserialize<ConfigData>(yamlContent);

                return configData;
            }
            catch (FileNotFoundException)
            {
                string message = "Config.yaml dosyası bulunamadı!";
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                string message = "Config.yaml dosyası okunurken bir hata oluştu!";
                throw new Exception(message, ex);
            }
        }
    }
}
