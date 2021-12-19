using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace NixMdm
{
    public class ClientInfo 
    {
        public static ClientInfo Load(string secretsFile)
        {
            string ClientSecretFilename = secretsFile;
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