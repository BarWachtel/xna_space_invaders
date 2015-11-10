using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A16_Ex01_Bar_301797445_Elad
{
    abstract class Enemy : AbstractShip
    {
        static Random m_RandomGenerator = new Random();

        private long m_TimeTillNextShot;
        private readonly int r_MinTimeMilli = 3000;
        private readonly int r_MaxTimeMilli = 15000;
        private bool m_ReadyToFire = false;
        protected Enemy (Game i_Game) : base(i_Game) 
        {
            m_TimeTillNextShot = randomTimeTillNextShot();
        }
        public int Score { get; protected set; }

        public void Update(GameTime i_GameTime)
        {
            m_TimeTillNextShot -= i_GameTime.ElapsedGameTime.Milliseconds;
            if (m_TimeTillNextShot < 0)
            {
                m_ReadyToFire = true;
                m_TimeTillNextShot = randomTimeTillNextShot();
            }
        }

        public bool GetReadyToFireAndSetToFalse()
        {
            bool readyToFire = m_ReadyToFire;
            m_ReadyToFire = false;
            return readyToFire;
        }

        private int randomTimeTillNextShot()
        {
            return m_RandomGenerator.Next(r_MinTimeMilli, r_MaxTimeMilli);
        }
    }
}
        