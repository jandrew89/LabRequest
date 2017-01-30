using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace LabRequest.Dialogs
{
    [Serializable]
    public class GreetingDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await Respond(context);
            context.Wait(MessageRecievedAsync);
        }

        private static async Task Respond(IDialogContext context)
        {
            var user = string.Empty;
            context.UserData.TryGetValue<string>("User", out user);
            if (string.IsNullOrEmpty(user))
            {
                await context.PostAsync("What is your username?");
                context.UserData.SetValue<bool>("GetUser", true);
            }
            else
            {
                await context.PostAsync($"Hello {user}. Lets get started!");
            }
        }

        public async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            var user = string.Empty;
            var getUser = false;
            context.UserData.TryGetValue<string>("User", out user);
            context.UserData.TryGetValue<bool>("GetUser", out getUser);

            if (getUser)
            {
                user = message.Text;
                context.UserData.SetValue<string>("User", user);
                context.UserData.SetValue<bool>("GetUser", false);
            }

            await Respond(context);
            context.Done(message);

        }
    }
}