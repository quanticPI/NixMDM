using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

using Google.Apis.Services;
using Google.Apis.AndroidManagement.v1;
using Google.Apis.AndroidManagement.v1.Data;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;

namespace NixMdm.GoogleAPI.AndroidManagement
{
    public class EnterpriseClient
    {
        public EnterpriseClient(){
            
        }

        public async Task<string> GetSignupUrl(IGoogleAuthProvider authProvider)
        {
            GoogleCredential cred = await authProvider.GetCredentialAsync();
            var service = new AndroidManagementService(new BaseClientService.Initializer
            {
                HttpClientInitializer = cred                  
            });
            var createsignupUrlReq = service.SignupUrls.Create();            
            createsignupUrlReq.ProjectId = "nixmdm";
            createsignupUrlReq.CallbackUrl = "https://localhost:5001";            
            SignupUrl signupUrl = await createsignupUrlReq.ExecuteAsync();
            return signupUrl.Url;
        }
    }
}