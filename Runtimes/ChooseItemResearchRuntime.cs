using Gum.Managers;
using GumRuntime;
using Microsoft.Xna.Framework;
using MonoGameGum.GueDeriving;
using RenderingLibrary;

namespace ScrollViewerIssues.Runtimes
{
    public class ChooseItemResearchRuntime : DisposableInteractiveGue
    {
        public CustomScrollViewerRuntime ScrollViewerInstance { get; protected set; }

        public ChooseItemResearchRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base()
        {
            if (fullInstantiation)
            {
                var element = ObjectFinder.Self.GetComponent("Ultrawave/InGame/Drawer/Upgrades/ChooseItemResearch");
                element.SetGraphicalUiElement(this, SystemManagers.Default);
            }
        }

        public override void AfterFullCreation()
        {
            ScrollViewerInstance = GetElement<CustomScrollViewerRuntime>("ScrollViewerInstance");
            ScrollViewerInstance.FormsControl.InnerPanel.ChildrenLayout = ChildrenLayout.LeftToRightStack;
            ScrollViewerInstance.FormsControl.InnerPanel.StackSpacing = 8;

            var random = new System.Random();
            for (int i = 0; i < 30; i++)
            {
                var innerRectangle = new ColoredRectangleRuntime();
                innerRectangle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                innerRectangle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                innerRectangle.X = 0;
                innerRectangle.Y = 0;
                innerRectangle.Width = 50;
                innerRectangle.Height = 50;
                innerRectangle.Color = new Color(random.Next(255), random.Next(255), random.Next(255));

                ScrollViewerInstance.FormsControl.InnerPanel.Children.Add(innerRectangle);
            }
        }
    }
}
