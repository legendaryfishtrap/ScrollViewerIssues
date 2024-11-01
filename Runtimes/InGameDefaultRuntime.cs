using ScrollViewerIssues.Runtimes;

namespace ScrollViewerIssues
{
    public class InGameDefaultRuntime : DisposableInteractiveGue
    {
        private RightDrawerRuntime rightDrawer;

        public override void AfterFullCreation()
        {
            base.AfterFullCreation();

            rightDrawer = GetElement<RightDrawerRuntime>("RightDrawerInstance");
        }
    }
}
