using Discord;
using Discord.Commands; // Importa o namespace do Discord
using Discord.WebSocket;               // Importa o namespace do Discord WebSocket

public class LoggingService
{
    public LoggingService(DiscordSocketClient client, CommandService command)
    {
        client.Log += LogAsync;          // Atribui o método LogAsync ao evento Log do cliente DiscordSocketClient
        command.Log += LogAsync;         // Atribui o método LogAsync ao evento Log do comando CommandService
    }

    private Task LogAsync(LogMessage message)   // Método assíncrono LogAsync que trata as mensagens de log
    {
        if (message.Exception is CommandException cmdException)   // Verifica se a mensagem de log é uma exceção de comando
        {
            Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
                              + $" failed to execute in {cmdException.Context.Channel}.");   // Imprime uma mensagem indicando a falha na execução do comando
            Console.WriteLine(cmdException);   // Imprime a exceção do comando
        }
        else 
            Console.WriteLine($"[General/{message.Severity}] {message}");   // Imprime uma mensagem de log geral

        return Task.CompletedTask;   // Retorna uma tarefa completada
    }
                                                                        //representa a mensagem após a atualização.
                                                                             // ↕
    private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
    {
        // Se a mensagem não estiver em cache, fazer o download dela resultará em obter uma cópia de `after`.
        var message = await before.GetOrDownloadAsync();
    
        // Imprime a mensagem original (antes da atualização) e a mensagem atualizada.
        Console.WriteLine($"{message} -> {after}");
    }
}