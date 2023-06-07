using Discord;
using Discord.WebSocket;

public class Program
{
    private DiscordSocketClient _client;

    public static Task Main(string[] args) => new Program().MainAsync();

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;  // Agora pode usar o método Log desta classe

        //Guardar o Token (Utilizar algum método/forma para o Token nao ficar no código, por motivos de segurança)
        var token = File.ReadAllText("C:\\Users\\Felipe\\Desktop\\C#\\BotHyu\\BotHyu\\token.txt"); //O Token do bot está sendo puxado por um arquivo .txt no computador local
        
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
        
        await Task.Delay(-1);

    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}