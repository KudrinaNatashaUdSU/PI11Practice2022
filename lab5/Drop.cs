using graphics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
namespace graphics
{
    class Drop : Moving
    {
        public Image? drop;

        public override void Move(int width, int height)
        {
            const int dy = 15;
            const int dx = 15;
            var nx = x + dx;
            var ny = y + dy;
            if (ny > height - hg) y = height / 2;
            if (nx > width - wd) x = 0;
            y += dy;
            x += dx;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(drop!, x, y);
        }
    }
}
