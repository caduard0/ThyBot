using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Webhook;
using Discord;
using Discord.Commands;
using System.Runtime.InteropServices;
using System.IO;
using Discord.Audio;
using Discord.Audio.Streams;
using System.Media;

namespace bote.modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannel(IVoiceChannel channel = null)
        {
            // Get the audio channel
            channel = channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (channel == null)
            {
                await Context.Channel.SendMessageAsync("User must be in a voice channel, " +
                "or a voice channel must be passed as an argument."); return;
            }

            // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
            await channel.ConnectAsync(false, false, true);
        }

        [Command("exit", RunMode = RunMode.Async)]
        public async Task InjoinChannel(IVoiceChannel channel = null)
        {
            channel = channel ?? (Context.User as IGuildUser)?.VoiceChannel;

            await channel.DisconnectAsync();

        }

        [Command("rojao", RunMode = RunMode.Async)]
        public async Task rojao(IVoiceChannel channel = null) {
            await JoinChannel(channel);

            var mymusic = new SoundPlayer();
            mymusic.SoundLocation = @"C:\Users\guste\Desktop\ConsoleApp1\rojao-estourado.wav";
            mymusic.PlaySync();

            await ReplyAsync("TARRARRRRRRRRRRRRRSTASATAATTATATATATTAAPOW POW OPWPWPOPWWWPOWWWWWWWWWWW");
        }
    }
}
