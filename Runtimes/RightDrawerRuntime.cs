using ScrollViewerIssues.Runtimes;

namespace ScrollViewerIssues
{
    public class RightDrawerRuntime : DisposableInteractiveGue
    {
        public DrawerBodyRuntime Body { get; protected set; }

        public RightDrawerRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base() { }

        public override void AfterFullCreation()
        {
            base.AfterFullCreation();

            Body = GetElement<DrawerBodyRuntime>("DrawerBodyInstance");
        }
    }
}
