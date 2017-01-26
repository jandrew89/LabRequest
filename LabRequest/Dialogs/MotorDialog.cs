using LabRequest.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading.Tasks;

namespace LabRequest.Dialogs
{
    [Serializable]
    public class MotorDialog
    {
        public static IDialog<string> dialog = Chain.PostToChain()
            .Select(msg => msg.Text)
            .Switch(
                new RegexCase<IDialog<string>>(new Regex("hi", RegexOptions.IgnoreCase), (context, text) =>
                {
                    return Chain.ContinueWith(new GreetingDialog(), MotorContinuation);
                }),
                new DefaultCase<string, IDialog<string>>((context, text) =>
                {
                    return Chain.ContinueWith(FormDialog.FromForm(Motor.BuildForm, FormOptions.PromptInStart), MotorFinish);
                }))
            .Unwrap()
            .PostToUser();

        private static async Task<IDialog<string>> MotorContinuation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = "User";
            context.UserData.TryGetValue<string>("User", out name);
            return Chain.Return($"{name}, press any key to get started.");
        }

        private static async Task<IDialog<string>> MotorFinish(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = "User";
            context.UserData.TryGetValue<string>("User", out name);
            return Chain.Return($"Here are your test results {name}.");
        }
    }
}