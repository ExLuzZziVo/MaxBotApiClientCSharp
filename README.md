# MaxBotApiClientCSharp

Неофициальный клиент для работы с MAX Bot API.

Создан по [официальной документации](https://dev.max.ru/docs).

Пример использования:

```csharp
var botClient = new MaxBotApiClient("ТОКЕН");

var messageBody = new NewMessageBody { Text = "Тест" };

var result = await botClient.SendMessageToChatAsync(ИД_ЧАТА, messageBody);
```

Доступен в пакетном менеджере NuGet.

Зависимости CoreLib вы можете найти [тут](https://github.com/ExLuzZziVo/CoreLib).
