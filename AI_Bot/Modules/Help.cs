﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace AI_Bot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("h")]
        public async Task helpMenu()
        {
            var builder = new EmbedBuilder()
            {
                Color = Color.Orange,
                Description = "You can find help specific to commands that you are looking for.  Currently the following commands have a help command.\n\n" +
                               "!h-Admin  |  !h-AddRoles  |  !h-iam"
            };
            await ReplyAsync("", false, builder.Build());
            Console.WriteLine("Help was requested by user: " + Context.User);
        }

        [Command("h-Admin")]
        public async Task helpAdmin()
        {
            var builder = new EmbedBuilder()
            {
                Color = Color.Orange,
                Description = "The administration module allows you different administration tasks for your channel  Below is a list of current options:\n\n" + 
                              "- Add roles to a list of approved roles.\n" +
                              "- Delete roles.\n" +
                              "- Allow users to assign themselves to roles."
            };
            await ReplyAsync("", false, builder.Build());
            Console.WriteLine("Help topic administration was requested by user: " + Context.User);
        }

        [Command("h-AddRoles")]
        public async Task helpAddRoles()
        {
            var builder = new EmbedBuilder()
            {
                Color = Color.Orange,
                Description = "The add roles command allows authorized users to add roles to the authorized roles list.  This is the list that is used for users to assign" +
                  " different roles to their own users."
            };
            await ReplyAsync("", false, builder.Build());
            Console.WriteLine("Help topic add role was requested by user: " + Context.User);
        }

        [Command("h-iam")]
        public async Task helpIAm()
        {
            var builder = new EmbedBuilder()
            {
                Color = Color.Orange,
                Description = "The !iam command allows users to add roles to their user within the discord channel.  This allows users to gain access to other areas of the discord."
            };
            await ReplyAsync("", false, builder.Build());
            Console.WriteLine("Help topic add role was requested by user: " + Context.User);
        }
    }
}
