using graphics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace graphics
{
    class Lightning : Moving
    {
        public Image? lightning;
        public override void Move(int width, int height)
        {
            wd = lightning!.Width;
            hg = lightning!.Height;
            x = Random.Shared.Next(0, width - wd);
            y = Random.Shared.Next((height - hg) / 2, height - hg);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(lightning!, x, y);
        }
    }
}

