using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A16_Ex01_Bar_301797445_Elad
{
    class PlayerShip : AbstractShip
    {
        public PlayerShip(Game i_Game)
            : base(i_Game)
        {
            m_TexturePath = @"Sprites\Ship01_32x32";
            m_Color = Color.White;
        }

        public void Move(float i_XValue)
        {
            this.Move(new Vector2(i_XValue, 0));
        }
    }
}
