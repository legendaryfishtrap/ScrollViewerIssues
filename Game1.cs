using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum.Forms;
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

        public static Texture2D texture;

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

            ElementSaveExtensions.RegisterGueInstantiation(
                "Item",
                () => new ItemRuntime()
            );

            currentScreen = gumProject.Screens.Find(screen => screen.Name == "Default").ToGraphicalUiElement(SystemManagers.Default, addToManagers: false);
            currentScreen.AddToManagers(SystemManagers.Default, null);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("GumDefaults2/UISpriteSheet");
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
