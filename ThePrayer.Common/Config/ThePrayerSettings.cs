using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThePrayer.Common.Config
{

    public class ThePrayerSettings
    {

        #region Constants

        private const string ConfigFileLocationEnvironmentVariableName = "ThePrayerConfigFile";

        #endregion

        #region Properties

        public OAuthConfigs OAuth { get; set; }

        #endregion

        #region Constructors

        public ThePrayerSettings()
        {
            this.LoadSettings();
        }

        private void LoadSettings()
        {
            var configFilePath = Environment.GetEnvironmentVariable(ConfigFileLocationEnvironmentVariableName);

            if (string.IsNullOrEmpty(configFilePath) || !File.Exists(configFilePath))
            {
                throw new IOException($"Config file is not found. Please make sure " +
                    $"the environment variable {ConfigFileLocationEnvironmentVariableName} exists. " +
                    $"Current value: {configFilePath}");
            }

            CommonUtils.DeserializeJsonFile(configFilePath, this);
        }

        #endregion

        #region Inner Types

        public class OAuthConfigs
        {

            public OAuthClientConfig Google { get; set; }
            public OAuthClientConfig Facebook { get; set; }
            public OAuthClientConfig Microsoft { get; set; }
            public OAuthClientConfig Twitter { get; set; }

            public class OAuthClientConfig
            {
                public string ClientId { get; set; }
                public string ClientSecret { get; set; }
            }

        }

        #endregion

    }

}
