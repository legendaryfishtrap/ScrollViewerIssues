using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum.Forms;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using ScrollViewerIssues.Runtimes;
using ToolsUtilities;

namespace ScrollViewerIssues
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GraphicalUiElement currentScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 960;
        }

        protected override void Initialize()
        {
            base.Initialize();

            SystemManagers.Default = new SystemManagers();
            SystemManagers.Default.Initialize(_graphics.GraphicsDevice, fullInstantiation: true);
            FormsUtilities.InitializeDefaults();

            FileManager.RelativeDirectory = "Content/GumDefaults2/";

            var gumProject = GumProjectSave.Load("GumProject.gumx");
            ObjectFinder.Self.GumProjectSave = gumProject;
            gumProject.Initialize();

            #region Register Gue Types
            ElementSaveExtensions.RegisterGueInstantiation(
                "ingame\\Default",
                () => new InGameDefaultRuntime()
            );

            ElementSaveExtensions.RegisterGueInstantiationType(
                "Ultrawave/ScrollBar",
                typeof(CustomScrollBarRuntime)
            );

            ElementSaveExtensions.RegisterGueInstantiationType(
                "Ultrawave/ScrollViewer",
                typeof(CustomScrollViewerRuntime)
            );

            ElementSaveExtensions.RegisterGueInstantiationType(
                "Ultrawave/InGame/Drawer/Upgrades/DrawerBody",
                typeof(DrawerBodyRuntime)
            );

            ElementSaveExtensions.RegisterGueInstantiationType(
                "Ultrawave/InGame/Drawer/RightDrawer",
                typeof(RightDrawerRuntime)
            );

            ElementSaveExtensions.RegisterGueInstantiationType(
                "Ultrawave/ButtonIcon",
                typeof(CustomButtonRuntime)
            );

            ElementSaveExtensions.RegisterGueInstantiationType(
                "Ultrawave/ButtonSolid",
                typeof(CustomButtonRuntime)
            );
            #endregion

            currentScreen = gumProject.Screens.Find(screen => screen.Name == "ingame\\Default").ToGraphicalUiElement(SystemManagers.Default, addToManagers: false);
            currentScreen.AddToManagers(SystemManagers.Default, null);

            var ScrollViewerInstance = ((InGameDefaultRuntime)currentScreen).GetElement<RightDrawerRuntime>("RightDrawerInstance").Body.ContentContainer.GetGraphicalUiElementByName("ScrollViewerInstance") as CustomScrollViewerRuntime;
            ScrollViewerInstance.FormsControl.InnerPanel.ChildrenLayout = ChildrenLayout.TopToBottomStack;
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

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            FormsUtilities.Update(gameTime, currentScreen);
            SystemManagers.Default.Activity(gameTime.TotalGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SystemManagers.Default.Draw();

            base.Draw(gameTime);
        }
    }
}
