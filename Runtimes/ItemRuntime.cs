using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using Microsoft.Xna.Framework;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using System;

namespace ScrollViewerIssues.Runtimes
{
    public class ItemRuntime : InteractiveGue
    {
        public SpriteRuntime SpriteInstance { get; protected set; }

        public ItemRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base()
        {
            if (fullInstantiation)
            {
                var element = ObjectFinder.Self.GetComponent("Item");
                element.SetGraphicalUiElement(this, SystemManagers.Default);
            }
        }

        public SpriteRuntime GetElement(string name)
        {
            var element = GetGraphicalUiElementByName(name) as SpriteRuntime;
            if (element == null)
            {
                throw new Exception("Failed to load properly from Gum");
            }
            return element;
        }

        public override void AfterFullCreation()
        {
            SpriteInstance = GetElement("SpriteInstance");

            SpriteInstance.Texture = Game1.texture;
            SpriteInstance.TextureAddress = TextureAddress.Custom;
            SpriteInstance.TextureLeft = 0;
            SpriteInstance.TextureTop = 0;
            SpriteInstance.TextureWidth = 150;
            SpriteInstance.TextureHeight = 150;
        }
    }
}
