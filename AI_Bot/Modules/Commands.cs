using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System.Linq;

namespace AI_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

        [Command("Matt")]
        public async Task Matt()
        {
            await ReplyAsync("Is a smelly pirate Hooker!");
        }

        [Command("Scott")]
        public async Task Scott()
        {
            await ReplyAsync("Is a n00b at everything");
        }

        [Command("Kody")]
        public async Task Kody()
        {
            var builder = new EmbedBuilder()
            {
                Color = Color.Green,
                Description = "League of legend God.... All bow down!"
            };
            await ReplyAsync("", false, builder.Build());
        }

        [Command("accept")]
        public async Task acceptRules()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Member");
            await (user as IGuildUser).AddRoleAsync(role);

        }

    }
}
