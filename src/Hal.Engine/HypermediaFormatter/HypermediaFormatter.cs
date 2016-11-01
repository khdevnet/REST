using System.Reflection;
using Hal.Engine.Extensibility;

namespace Hal.Engine.HypermediaFormatter
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