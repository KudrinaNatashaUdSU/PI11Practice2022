using graphics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace graphics
{
    class Moving
    {
         public int x;
         public int y;
         public int wd;
         public int hg;

         public virtual void Move(int width, int height) { }
         public virtual void Draw(Graphics g) { }
    }
}
