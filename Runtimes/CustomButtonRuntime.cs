using Gum.Wireframe;
using MonoGameGum.Forms.Controls;

namespace ScrollViewerIssues.Runtimes
{
    public class CustomButtonRuntime : InteractiveGue
    {
        public CustomButtonRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base() { }

        public Button FormsControl => FormsControlAsObject as Button;

        public override void AfterFullCreation()
        {
            base.AfterFullCreation();

            if (FormsControlAsObject == null)
            {
                FormsControlAsObject = new Button(this);
            }
        }
    }
}
