using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;

namespace WinFormsApp2
{
    public class PromptCodeReceiver : ICodeReceiver
    {
        public string RedirectUri => "urn:ietf:wg:oauth:2.0:oob";

        public Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl url, CancellationToken taskCancellationToken)
        {
            // Відкриваємо посилання у браузері
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url.Build().ToString(),
                UseShellExecute = true
            });

            // Просимо користувача вставити код вручну
            string code = Microsoft.VisualBasic.Interaction.InputBox(
                "Вставте код авторизації з браузера:",
                "Google Авторизація",
                ""
            );

            var responseUrl = new AuthorizationCodeResponseUrl
            {
                Code = code
            };

            return Task.FromResult(responseUrl);
        }
    }
}