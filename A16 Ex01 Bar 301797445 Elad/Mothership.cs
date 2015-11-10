using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A16_Ex01_Bar_301797445_Elad
{
    class Mothership : AbstractShip
    {
        public Mothership(Game i_Game)
            : base(i_Game)
        {
            m_TexturePath = @"Sprites\MotherShip_32x120";
            m_Color = Color.Red;
            this.Score = 750;
        }
        public int Score { get; set; }
    }       
}
