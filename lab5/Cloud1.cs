using graphics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace graphics
{
    class Cloud1 : Moving
    {
        public int dx;
        public Image? cloud1;

        public override void Move(int width, int height)
        {
            var nx = x + dx;
            if (nx > width - wd) x = 0;
            x += dx;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(cloud1!, x, y);
        }
    }
}
