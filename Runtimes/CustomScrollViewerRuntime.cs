using Gum.Wireframe;
using MonoGameGum.Forms.Controls;

namespace ScrollViewerIssues.Runtimes
{
    public class CustomScrollViewerRuntime : InteractiveGue
    {
        public CustomScrollViewerRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base() { }

        public ScrollViewer FormsControl => FormsControlAsObject as ScrollViewer;

        public override void AfterFullCreation()
        {
            base.AfterFullCreation();

            if (FormsControlAsObject == null)
            {
                FormsControlAsObject = new ScrollViewer(this);
            }
        }
    }
}
