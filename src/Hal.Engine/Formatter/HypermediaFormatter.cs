using System.Reflection;
using Hal.Engine.Extensibility.Formatter;
using Hal.Engine.Extensibility.Hypermedia;

namespace Hal.Engine.Formatter
{
    public class HypermediaFormatter : IHypermediaFormatter
    {
        public void Formating(IHypermedia resource)
        {
            MethodInfo methodInfo = typeof(IHypermedia).GetMethod("Bind");
            methodInfo?.Invoke(resource, null);
        }
    }
}