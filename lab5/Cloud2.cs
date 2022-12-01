using graphics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;


namespace graphics
{
    class Cloud2 : Moving
    {
        public int dx;
        public Image? cloud2;

        public override void Move(int width, int height)
        {
            var nx = x + dx;
            if (nx > width - wd) x = 0;
            x += dx;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(cloud2!, x, y);
        }
    }
}
