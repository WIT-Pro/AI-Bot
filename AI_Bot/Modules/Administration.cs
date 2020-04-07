using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;

namespace AI_Bot.Modules
{
    public class Administration : ModuleBase<SocketCommandContext>
    {

        [Command("listRoles")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task getRoles()
        {
            string filePath = @"c:\AIBot\roleList.txt";
            if (File.Exists(filePath))
            {
                Console.WriteLine("Opening List...");
                var contents = File.ReadAllLines(filePath);
                var conList = new List<string>(contents);
                string roleList = "";
                for (int i = 0; i < conList.Count; i++)
                {
                    roleList += conList[i] + "\n";
                }
                await ReplyAsync(roleList);
            }
            else
            {
                Console.WriteLine("List doesn't exist.... Creating a list");
            }
        }


        [Command("addRole")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task iList(string role)
        {
            string filePath = @"c:\AIBot\roleList.txt";
            if (File.Exists(filePath))
            {
                Console.WriteLine("List Exists... Opening List.");
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(role);
                    await ReplyAsync(role + " Has been added to the roles list");
                }
            }
            else
            {
                Console.WriteLine("List doesn't exist.... Creating a list");
                try
                {
                    using (FileStream fs = File.Create(filePath)) ;
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(role);
                        await ReplyAsync(role + " Has been added to the roles list");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        [Command("iam")]
        public async Task iAm(string inputRole)
        {
            try
            {
                        var user = Context.User;
                        var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == inputRole);

                        await (user as IGuildUser).AddRoleAsync(role);
                        var builder = new EmbedBuilder()
                        {
                            Color = Color.Green,
                            Description = "Your requested role has been added."
                        };
                        await ReplyAsync("", false, builder.Build());
                        Console.WriteLine(user + " has requested the role " + role.ToString() + "Your requested role has been added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var builder = new EmbedBuilder()
                {
                    Color = Color.Red,
                    Description = "The role that you have requested is not available.  This is case sensitive and if a role contains spaces please use quotes around the role."
                };
                await ReplyAsync("", false, builder.Build());
            }
        }


    }
}
