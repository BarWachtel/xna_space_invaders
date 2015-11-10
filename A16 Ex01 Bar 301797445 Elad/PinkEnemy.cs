using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A16_Ex01_Bar_301797445_Elad
{
    class PinkEnemy : Enemy
    {
        public PinkEnemy(Game i_Game) : base(i_Game)
        {
            m_TexturePath = @"Sprites\Enemy0101_32x32";
            m_Color = Color.Pink;
            this.Score = 250;
        }
    }
}
