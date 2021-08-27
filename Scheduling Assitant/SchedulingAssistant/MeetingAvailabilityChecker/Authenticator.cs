using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Linq;

namespace MeetingAvailabilityChecker
{
	public class Authenticator
	{
		
			public GraphServiceClient GetGraphServiceClient()
			{
				string[] scopes = new string[] { "Calendars.ReadWrite.Shared" };
				IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
					.Create("") // is the APPLICATION id of the APPLICATION with the display name "aadapp_infrcepa"
					.WithTenantId("")
					.WithRedirectUri("http://localhost")
					.Build();

				var accounts = publicClientApplication.GetAccountsAsync().Result;
				AuthenticationResult result;

				try
				{
					result = publicClientApplication.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
						.ExecuteAsync().Result; //Trying to use existing bearer token or valid refresh token
				}
				catch (Exception e)
				{

					result = publicClientApplication.AcquireTokenInteractive(scopes)
						.ExecuteAsync().Result; // No bearer token or bearer/refresh token has expired.				
				}

				IntegratedWindowsAuthenticationProvider authenticationProvider = new IntegratedWindowsAuthenticationProvider(publicClientApplication, scopes);

				return new GraphServiceClient(authenticationProvider);
			}
	}
}
