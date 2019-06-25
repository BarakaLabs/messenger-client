using System;
using Messenger.Client.Config;
using Messenger.Client.Services;
using Messenger.Client.Services.Impl;
using Messenger.Client.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Client.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddMessengerClient(this IServiceCollection services, String accessToken = "", String urlBase = "")
        {
            if (!String.IsNullOrEmpty(accessToken))
            {
                MessengerConfig.AccessToken = accessToken;
            }
            if (!String.IsNullOrEmpty(urlBase))
            {
                MessengerConfig.UrlBase = urlBase;
            }

            services.AddSingleton<IMessengerSerializer, JsonMessengerSerializer>();
            services.AddSingleton<IMessengerMessageSender, MessengerMessageSender>();
            services.AddSingleton<IMessengerProfileProvider, MessengerProfileProvider>();
            services.AddSingleton<IMessengerThreadSettingsService, MessengerThreadSettingsService>();
            services.AddSingleton<IMessengerRestClient, MessengerRestClient>();
            services.AddSingleton<IMessengerThreadSettingsService, MessengerThreadSettingsService>();
            services.AddSingleton<IMessengerProfileService, MessengerProfileService>();
        }
    }
}
