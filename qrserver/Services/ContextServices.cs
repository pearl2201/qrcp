public enum ServerAction
{
    SEND,
    RECEIVE
}
public class ContextServices
{
    public ServerAction CurrentAction { get; set; }
    public string CurrentPath { get; set; }
}