using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A16_Ex01_Bar_301797445_Elad
{
    // I will refactor this, but for now you can use this for implementation!
    class Bullet : AbstractShip
    {
        public Bullet(Game i_Game) : base(i_Game)
        {
            m_TexturePath = @"Sprites\Bullet";
            m_Color = Color.Red;
        }
    }
}
