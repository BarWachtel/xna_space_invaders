using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace A16_Ex01_Bar_301797445_Elad
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Invaders : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        EnemyCollection m_EnemyCollection;
        PlayerShip m_PlayerShip;

        Texture2D m_TextureBackground;

        Vector2 m_PositionBackground;

        Color m_TintBackground = Color.White;

        float m_ShipDirection = 1f;

        public Invaders()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            m_EnemyCollection = new EnemyCollection(this);
            m_PlayerShip = new PlayerShip(this);

            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            m_TextureBackground = Content.Load<Texture2D>(@"Sprites\BG_Space01_1024x768");
            m_PlayerShip.LoadContent();

            m_EnemyCollection.Initialize();
            InitPositions();
        }

        private void InitPositions()
        {
            // 1. init the ship position
            // Get the bottom and center:
            float x = (float)GraphicsDevice.Viewport.Width / 2;
            float y = (float)GraphicsDevice.Viewport.Height;

            // Offset:
            x -= m_PlayerShip.Width / 2;
            y -= m_PlayerShip.Height / 2;

            // Put it a little bit higher:
            y -= 30;

            m_PlayerShip.Location = new Vector2(x, y);

            // 2. Init the enemy position
            x = (float)GraphicsDevice.Viewport.Width / 2;
            y = 50;

            // 3. Init the bg position:
            m_PositionBackground = Vector2.Zero;

            //create an alpah channel for background:
            Vector4 bgTint = Vector4.One;
            bgTint.W = 0.4f; // set the alpha component to 0.2
            m_TintBackground = new Color(bgTint);
        }

        MouseState? m_PrevMouseState;

        private Vector2 GetMousePositionDelta()
        {
            Vector2 retVal = Vector2.Zero;

            MouseState currState = Mouse.GetState();

            if (m_PrevMouseState != null)
            {
                retVal.X = (currState.X - m_PrevMouseState.Value.X);
                retVal.Y = (currState.Y - m_PrevMouseState.Value.Y);
            }

            m_PrevMouseState = currState;

            return retVal;
        }

        protected override void Update(GameTime gameTime)
        {
            // get the current input devices state:
            GamePadState currGamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState currKeyboardState = Keyboard.GetState();

            
            // Allows the game to exit by GameButton 'back' button or Esc:
            if (currGamePadState.Buttons.Back == ButtonState.Pressed
                || currKeyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // move the ship using the GamePad left thumb stick and set viberation according to movement:
            m_PlayerShip.Move(currGamePadState.ThumbSticks.Left.X * 120 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            GamePad.SetVibration(PlayerIndex.One, 0, Math.Abs(currGamePadState.ThumbSticks.Left.X));

            // move the ship using the mouse:
            m_PlayerShip.Move(GetMousePositionDelta().X);

            // clam the position between screen boundries:
            m_PlayerShip.Location = new Vector2(MathHelper.Clamp(m_PlayerShip.Location.X, 0, this.GraphicsDevice.Viewport.Width - m_PlayerShip.Width), m_PlayerShip.Location.Y);

            // if we hit the wall, lets change direction:
            if (m_PlayerShip.Location.X == 0 || m_PlayerShip.Location.X == this.GraphicsDevice.Viewport.Width - m_PlayerShip.Width)
            {
                m_ShipDirection *= -1f;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(m_TextureBackground, m_PositionBackground, m_TintBackground); // tinting with alpha channel
            m_EnemyCollection.Draw(spriteBatch);
            m_PlayerShip.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
