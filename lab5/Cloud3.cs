using graphics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace graphics
{
    class Cloud3 : Moving
    {
        public int dx;
        public Image? cloud3;

        public override void Move(int width, int height)
        {
            x = Random.Shared.Next(0, width - wd);
            y = Random.Shared.Next((height - hg) / 2, height - hg);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(cloud3!, x, y);
        }
    }
}
