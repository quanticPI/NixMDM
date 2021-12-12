using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NixMdm
{
    public class ClientInfo 
    {
        private const string ClientSecretFilename = "/home/nikolay/Documents/client_secret_698465692157-jrj9s17ofndmbe4ag9ndpv5tgu8k2g38.apps.googleusercontent.com.json";
        public static ClientInfo Load()
        {
            var secrets = JObject.Parse(File.ReadAllText(ClientSecretFilename))["web"];
            if(secrets == null)
            {
                throw new InvalidOperationException(
                     $"The type of the OAuth2 client ID specified in {ClientSecretFilename} should be Web Application");
            }
            var projectId = secrets["project_id"].Value<string>();
            var clientId = secrets["client_id"].Value<string>();
            var clientSecret = secrets["client_secret"].Value<string>();

            return new ClientInfo(projectId, clientId, clientSecret);
        }

        private ClientInfo(string projectId, string clientId, string clientSecret)
        {
            ProjectId = projectId;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ProjectId { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
    }
}