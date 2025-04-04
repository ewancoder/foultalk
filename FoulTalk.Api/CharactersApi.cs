using Microsoft.AspNetCore.Http.HttpResults;

namespace FoulTalk.Api;

public static class CharactersApi
{
    public static RouteGroupBuilder MapCharactersApi(this RouteGroupBuilder charactersGroup)
    {
        charactersGroup.MapGet("/{characterId}", GetCharacterById);
        charactersGroup.MapPost("/", CreateCharacter);

        return charactersGroup;
    }

    [EndpointSummary("Get character by ID")]
    private static Results<Ok<Character>, NotFound> GetCharacterById(string characterId)
    {
        return TypedResults.NotFound();
    }

    [EndpointSummary("Create a new character")]
    private static Results<Created<CharacterCreated>, BadRequest<string>> CreateCharacter(
        CreateCharacter createCharacter)
    {
        return TypedResults.BadRequest("Not implemented.");
    }
}

public sealed record Character(string Id);

public sealed record CharacterCreated(string Id);

public sealed record CreateCharacter(string Id, string Persona);
