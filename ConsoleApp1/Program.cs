using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new TelegramBotClient("7104368282:AAGZpJpKlNPHQP32hsTr-JyghMfBckmCG08");
        client.StartReceiving(Update, Error);
        Console.ReadLine();
    }

    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var message = update.Message;
        if (message.Text != null)
        {
            if (message.Text.ToLower().Contains("привет"))
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "добрый день");
                Console.WriteLine("добрый день");
                return;
            }
        }
        if (message.Photo != null)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "мне пришло фото");
            Console.WriteLine("мне пришло фото");
            return;
        }
        if (message.Document != null)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "мне пришёл документ");
            Console.WriteLine("мне пришел документ");
            return;
        }
    }
}
