using Microsoft.AspNetCore.Http.HttpResults;

namespace FoulTalk.Api;

public static class ConversationsApi
{
    public static RouteGroupBuilder MapConversationsApi(this RouteGroupBuilder conversationsGroup)
    {
        conversationsGroup.MapGet("/{conversationId}", GetConversationById);
        conversationsGroup.MapPost("/", StartConversation);

        return conversationsGroup;
    }

    [EndpointSummary("Get conversation by ID")]
    private static Results<Ok<Conversation>, NotFound> GetConversationById(string conversationId)
    {
        return TypedResults.NotFound();
    }

    [EndpointSummary("Start a new conversation")]
    private static Results<Created<ConversationStarted>, BadRequest<string>> StartConversation(
        StartConversation startConversation)
    {
        return TypedResults.BadRequest("Not implemented.");
    }
}

public sealed record Conversation(string Id);

public sealed record ConversationStarted(string Id);

public sealed record StartConversation(string Id);
