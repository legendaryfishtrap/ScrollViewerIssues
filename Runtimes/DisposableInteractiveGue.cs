using Gum.Wireframe;
using System;

namespace ScrollViewerIssues.Runtimes
{
    public abstract class DisposableInteractiveGue : InteractiveGue, IDisposable
    {
        public virtual void Dispose() { }

        public T GetElement<T>(string name) where T : GraphicalUiElement
        {
            var element = GetGraphicalUiElementByName(name) as T;
            if (element == null)
            {
                Console.WriteLine($"Must have a component named `{name}` defined.");
                throw new Exception("Failed to load properly from Gum");
            }
            return element;
        }
    }
}
