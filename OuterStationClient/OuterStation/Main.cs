using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace OuterStation
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Main : Game
	{
		GraphicsDeviceManager _graphicsDeviceManager;
		SpriteBatch _spriteBatch;

		Texture2D _sphereTexture;
		float _position = 0;

		public Main()
		{
			_graphicsDeviceManager = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
            
			base.Initialize();
		}
			
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			_sphereTexture = Content.Load<Texture2D>("sphere");
		}

		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
            
			_position += 0.2f;

			// TODO: Add your update logic here
			base.Update (gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			_graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            
			//TODO: Add your drawing code here
			_spriteBatch.Begin();
			for (int i = 0; i < 60; i += 10) {
				_spriteBatch.Draw (_sphereTexture, new Vector2 (_position + _sphereTexture.Width / 2f, _sphereTexture.Height / 2f + i), null, null, new Vector2 (_sphereTexture.Width / 2f, _sphereTexture.Height / 2f), _position, Vector2.One, Color.DarkRed, SpriteEffects.None, 1);
			}
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}

