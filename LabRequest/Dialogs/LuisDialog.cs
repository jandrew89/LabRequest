using LabRequest.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;

namespace LabRequest.Dialogs
{
    [LuisModel("1a726acf-48b4-433e-955b-bc91448a0ce0", "7156e37c3fac47ab9c23a84004b4426a")]
    [Serializable]
    public class LuisDialog : LuisDialog<Motor>
    {
        private readonly BuildFormDelegate<Motor> Motor;

        public LuisDialog(BuildFormDelegate<Motor> motor)
        {
            this.Motor = motor;
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            context.Call(new GreetingDialog(), Callback);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("StartMotorForm")]
        public async Task MotorForm(IDialogContext context, LuisResult result)
        {
            var motorForm = new FormDialog<Motor>(new Motor(), this.Motor, FormOptions.PromptInStart);
            context.Call<Motor>(motorForm, Callback);
        }

        [LuisIntent("QueryVoltages")]
        public async Task QueryVoltages(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Test");
            context.Wait(MessageReceived);
            return;
        }
    }
}