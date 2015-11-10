using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A16_Ex01_Bar_301797445_Elad
{
    class EnemyCollection
    {
        List<Enemy> m_Enemies;
        Mothership m_Mothership;
        private Game m_Game;

        public EnemyCollection(Game i_Game)
        {
            m_Enemies = new List<Enemy>();
            m_Game = i_Game;
            m_Enemies.Add(new PinkEnemy(m_Game));
            m_Enemies.Add(new TealEnemy(m_Game));
            m_Enemies.Add(new YellowEnemy(m_Game));
            m_Mothership = new Mothership(m_Game);
        }

        public void Initialize()
        {
            float enemyXPosition, enemyYPosition;

            m_Enemies[0].LoadContent();
            Rectangle enemyBounds = m_Enemies[0].Bounds;

            // For test
            enemyXPosition = (float)(m_Game.GraphicsDevice.Viewport.Width / 2) - ((m_Enemies.Count / 2f) * (enemyBounds.Width * 1.6f));
            enemyYPosition = enemyBounds.Height * 3;

            foreach (Enemy enemy in m_Enemies)
            {
                enemy.LoadContent();
                enemy.InitPosition(enemyXPosition, enemyYPosition);
                enemyXPosition += enemy.Width * 1.6f;
            }

            m_Mothership.LoadContent();
            m_Mothership.InitPosition(enemyXPosition, enemyYPosition - enemyBounds.Height);
        }

        public void Draw(SpriteBatch i_SpriteBatch)
        {
            foreach (Enemy enemy in m_Enemies)
            {
                enemy.Draw(i_SpriteBatch);
            }
            m_Mothership.Draw(i_SpriteBatch);
        }
    }
}
