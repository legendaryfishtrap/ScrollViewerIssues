using Gum.Wireframe;
using MonoGameGum.Forms.Controls;

namespace ScrollViewerIssues.Runtimes
{
    public class CustomScrollBarRuntime : InteractiveGue
    {
        public CustomScrollBarRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base() { }

        public ScrollBar FormsControl => FormsControlAsObject as ScrollBar;

        public override void AfterFullCreation()
        {
            base.AfterFullCreation();

            if (FormsControlAsObject == null)
            {
                FormsControlAsObject = new ScrollBar(this);
            }
        }
    }
}
