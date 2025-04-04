namespace FoulTalk.Api;

// Character & Conversation.
public static class FoulTalkApi
{
    public static void AddFoulTalkApi(this WebApplication app)
    {
        app.MapGroup("/api/characters")
            .WithTags("Characters")
            .RequireAuthorization()
            .MapCharactersApi();

        app.MapGroup("/api/conversations")
            .WithTags("Conversations")
            .RequireAuthorization()
            .MapConversationsApi();
    }
}
