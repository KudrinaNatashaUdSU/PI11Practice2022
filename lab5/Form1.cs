using System.Security.Cryptography.X509Certificates;

namespace graphics
{
    public partial class Form1 : Form
    {
        Image cloud1;
        Image cloud2;
        Image cloud3;
        Image drop;
        Image lightning;
        Bitmap buffer;
        Graphics back;
        List<Moving> list;

        public Form1()
        {
            InitializeComponent();
            buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            back = Graphics.FromImage(buffer);
            cloud1 = Image.FromFile("cloud1.png");
            cloud2 = Image.FromFile("cloud2.png");
            cloud3 = Image.FromFile("cloud3.png");
            lightning = Image.FromFile("lightning.png");
            drop = Image.FromFile("drop.png");
            list = new List<Moving>();
            for (int i = 0; i < 40; i++)
                AddCloud();
            for (int i = 0; i < 40; i++)
                AddDrop();
            for (int i = 0; i < 3; i++)
                AddLightning();
        }

        private void AddCloud()
        {
            var c1 = new Cloud1();
            var c2 = new Cloud2();
            var c3 = new Cloud3();

            c1.wd = cloud1.Width;
            c1.hg = cloud1.Height;
            c1.x = Random.Shared.Next(0, pictureBox1.Width - c1.wd);
            c1.y = Random.Shared.Next(0, (pictureBox1.Height - c1.hg) / 2);
            c1.dx = Random.Shared.Next(1, 5);
            c1.cloud1 = cloud1;

            c2.wd = cloud2.Width;
            c2.hg = cloud2.Height;
            c2.x = Random.Shared.Next(0, pictureBox1.Width - c2.wd);
            c2.y = Random.Shared.Next(0, (pictureBox1.Height - c2.hg) / 2);
            c2.dx = Random.Shared.Next(1, 5);
            c2.cloud2 = cloud2;

            c3.wd = cloud3.Width;
            c3.hg = cloud3.Height;
            c3.x = Random.Shared.Next(0, pictureBox1.Width - c3.wd);
            c3.y = Random.Shared.Next(0, (pictureBox1.Height - c3.hg) / 2);
            c3.dx = Random.Shared.Next(1, 5);
            c3.cloud3 = cloud3;

            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
        }

        private void AddLightning()
        {
            var l = new Lightning();
            l.x = Random.Shared.Next(0, pictureBox1.Width - l.wd);
            l.y = Random.Shared.Next((pictureBox1.Height - l.hg) / 2, pictureBox1.Height - l.hg);
            l.lightning = lightning;
            list.Add(l);
        }
        private void AddDrop()
        {
            var d = new Drop();
            d.wd = drop.Width;
            d.hg = drop.Height;
            d.x = Random.Shared.Next(0, pictureBox1.Width - d.wd);
            d.y = Random.Shared.Next((pictureBox1.Height - d.hg) / 2, pictureBox1.Height - d.hg);
            d.drop = drop;
            list.Add(d);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            back.FillRectangle(Brushes.Silver, 0, 0, pictureBox1.Width, pictureBox1.Height);
            foreach (Moving s in list)
            {
                s.Move(pictureBox1.Width, pictureBox1.Height);
                s.Draw(back);
            }

            using var g = pictureBox1.CreateGraphics();
            g.DrawImage(buffer, 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
                AddCloud();
            if (e.KeyCode == Keys.L)
                AddLightning();
            if (e.KeyCode == Keys.D)
                AddDrop();
        }
    }
}