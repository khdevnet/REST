namespace Hal.Engine.Extensibility
{
    public interface IContentHypermedia<TContent>
    {
        TContent Content { get; set; }
    }
}