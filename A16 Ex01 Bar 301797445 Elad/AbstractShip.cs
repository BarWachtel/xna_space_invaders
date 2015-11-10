using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A16_Ex01_Bar_301797445_Elad
{
    abstract class AbstractShip
    {
        protected Color m_Color;
        protected string m_TexturePath;

        protected Texture2D m_Texture;
        private Vector2 m_Position;
        private Game m_Game;

        public AbstractShip(Game i_Game)
	    {
            m_Game = i_Game;
	    }

        public void LoadContent()
        {
            m_Texture = m_Game.Content.Load<Texture2D>(m_TexturePath);
        }

        public void InitPosition(float i_XPosition, float i_YPosition)
        {
            m_Position = new Vector2(i_XPosition, i_YPosition);
        }

        public Vector2 Location 
        { 
            get { return m_Position; } 
            set { m_Position = value; } 
        }
        public void Move(Vector2 i_Distance)
        {
            m_Position += i_Distance;
        }
        public bool WasHit(Rectangle i_Bullet)
        {
            return m_Texture.Bounds.Intersects(i_Bullet);
        }
        public void Draw(SpriteBatch i_SpriteBatch)
        {
            i_SpriteBatch.Draw(m_Texture, m_Position, m_Color); 
        }
        public float Width { get { return m_Texture.Width; } }
        public float Height { get { return m_Texture.Height; } }
        public Rectangle Bounds { get { return m_Texture.Bounds; } }

    }
}
