namespace Hal.Engine.Extensibility
{
    public interface IContentResource<TContent> 
    {
        TContent Content { get; set; }
    }
}