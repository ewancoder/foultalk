namespace FoulTalk.Domain;

/// <summary>
/// Messenger interface to send messages to people.
/// </summary>
public interface IMessageSender
{
    ValueTask SendMessageAsync(string message);
}

/// <summary>
/// Receives message from the user and dispatches it for handling.
/// </summary>
public interface IMessageReceiver
{
    ValueTask ReceiveMessageAsync(ReceivedMessage message);
}

public enum MessageType
{
    None,

    /// <summary>
    /// Regular context-aware conversation message that expects a reply.
    /// </summary>
    Conversation = 1,

    /// <summary>
    /// System message - addresses AI directly, expects a reply.
    /// </summary>
    System = 2,

    /// <summary>
    /// Updates character ambient information, does not expect a reply.
    /// </summary>
    UpdateCharacter = 3
}

public sealed record ConversationParticipant(string Id, string Name)
{
    public static ConversationParticipant System => new("System", "System");
}

public sealed class ReceivedMessage
{
    private ReceivedMessage(string value, MessageType messageType, bool expectingReply, ConversationParticipant from)
    {
        Value = value;
        MessageType = messageType;
        ExpectingReply = expectingReply;
        From = from;
    }

    public string Value { get; }
    public MessageType MessageType { get; }
    public bool ExpectingReply { get; }
    public ConversationParticipant From { get; }

    public static ReceivedMessage Conversation(string value, ConversationParticipant from) => new(
        value, MessageType.Conversation, true, from);

    public static ReceivedMessage System(string value, ConversationParticipant from) => new(
        value, MessageType.System, true, from);

    public static ReceivedMessage UpdateCharacter(string value) => new(
        value, MessageType.UpdateCharacter, false, ConversationParticipant.System);
}
