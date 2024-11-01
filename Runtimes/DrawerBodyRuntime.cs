using MonoGameGum.GueDeriving;
using ScrollViewerIssues.Runtimes;

namespace ScrollViewerIssues
{
    public class DrawerBodyRuntime : DisposableInteractiveGue
    {
        public ContainerRuntime ContentContainer { get; protected set; }

        public DrawerBodyRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base() { }

        public override void AfterFullCreation()
        {
            base.AfterFullCreation();

            ContentContainer = GetElement<ContainerRuntime>("ContentContainer");
        }
    }
}
