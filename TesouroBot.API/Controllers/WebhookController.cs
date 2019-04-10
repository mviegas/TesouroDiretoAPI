using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TesouroBot.API.Helpers;
using static TesouroBot.API.Helpers.TesouroBotTableParser;

namespace tesourobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WebhookController()
        {
            var configBuilder =
                new ConfigurationBuilder()
                .AddJsonFile($"secrets.json", optional: false, reloadOnChange: true);

            _configuration = configBuilder.Build();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Update update)
        {
            try
            {
                var tokenSection = _configuration.GetSection("Token");

                var telegramBotClient = new TelegramBotClient(tokenSection.Value);

                switch (update.Type)
                {
                    case (UpdateType.Message):
                        {
                            if (update.Message.Text == "/start")
                            {
                                await IniciarContato(update.Message.Chat.Id, telegramBotClient);
                            }
                            break;
                        }
                    case (UpdateType.CallbackQuery):
                        {
                            if (update.CallbackQuery.Data == "/voltar")
                            {
                                await IniciarContato(update.CallbackQuery.From.Id, telegramBotClient);
                            }

                            else
                            {
                                var bonds = await FetchAsync();

                                if (update.CallbackQuery.Data == "/comprar")
                                {
                                    await EnviarTitulosDisponiveis(update, telegramBotClient, bonds, TipoDeTitulo.Compra);
                                }

                                if (update.CallbackQuery.Data == "/vender")
                                {
                                    await EnviarTitulosDisponiveis(update, telegramBotClient, bonds, TipoDeTitulo.Venda);
                                }

                                if (bonds.Any(b => b.NomeNormalizado == update.CallbackQuery.Data.Replace("/", string.Empty)))
                                {
                                    await EnviarDadosDoTitulo(update, telegramBotClient, bonds);
                                }
                            }

                            break;
                        }
                    default:
                        await IniciarContato(update.Message.Chat.Id, telegramBotClient);
                        break;
                }
            }
            catch (Exception) { }

            return Ok();
        }

        private static async Task EnviarDadosDoTitulo(Update update, TelegramBotClient telegramBotClient, IEnumerable<Titulo> bonds)
        {
            var bond = bonds.FirstOrDefault(b => b.NomeNormalizado == update.CallbackQuery.Data.Replace("/", string.Empty));

            var message = new StringBuilder();
            message.AppendLine($"Os dados do título *{bond.Nome}* são:");
            message.AppendLine(string.Empty);
            message.AppendLine($"Disponível para: {bond.TipoDeTitulo}");
            message.AppendLine($"Data de Vencimento: {bond.Vencimento}");
            message.AppendLine($"Taxa: {bond.Taxa}");
            message.AppendLine($"Preço Unitário: {bond.PrecoUnitario}");

            var buttons = new List<InlineKeyboardButton[]>();
            buttons.Add(new[] { new InlineKeyboardButton() { Text = "Voltar", CallbackData = $"/voltar" } });

            var inlineKeyboardMarkup = new InlineKeyboardMarkup(buttons);

            await telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, message.ToString(), ParseMode.Markdown, replyMarkup: inlineKeyboardMarkup);
        }

        private static async Task IniciarContato(long chatId, TelegramBotClient telegramBotClient)
        {
            var buttons = new List<InlineKeyboardButton>();

            buttons.Add(new InlineKeyboardButton() { Text = "Comprar", CallbackData = "/comprar" });
            buttons.Add(new InlineKeyboardButton() { Text = "Vender", CallbackData = "/vender" });

            var inlineKeyboardMarkup = new InlineKeyboardMarkup(buttons);

            var message = new StringBuilder();
            message.AppendLine("Olá, eu sou o Kiko, seu assistente do Tesouro Direto! 💰");
            message.AppendLine("O que você deseja fazer hoje?");

            await telegramBotClient.SendTextMessageAsync(chatId, message.ToString(), ParseMode.Markdown, replyMarkup: inlineKeyboardMarkup);
        }

        private static async Task EnviarTitulosDisponiveis(Update update, TelegramBotClient telegramBotClient, IEnumerable<Titulo> bonds, TesouroBotTableParser.TipoDeTitulo tipoDeTitulo)
        {
            var message = new StringBuilder();

            if (tipoDeTitulo == TipoDeTitulo.Compra)
            {
                message.AppendLine("Certo! Vamos aumentar essa poupança que a aposentadoria tá longe ainda, tá ok?");
                message.AppendLine("Os títulos disponíveis para comprar são:");
            }
            else
            {
                message.AppendLine("Não vai gastar essa poupança no boteco ein!");
                message.AppendLine("Os títulos disponíveis para vender são:");
            }

            var buttons = new List<InlineKeyboardButton[]>();

            foreach (var bond in bonds.Where(b => b.TipoDeTitulo == tipoDeTitulo))
            {
                buttons.Add(new[] { new InlineKeyboardButton() { Text = bond.Nome, CallbackData = $"/{bond.NomeNormalizado}" } });
            }

            var inlineKeyboardMarkup = new InlineKeyboardMarkup(buttons);

            await telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, message.ToString(), ParseMode.Markdown, replyMarkup: inlineKeyboardMarkup);
        }
    }
}