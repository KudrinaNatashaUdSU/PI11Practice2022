namespace CALC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Calculator calc = new Calculator();
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = calc.Screen;
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            calc.DoCommand("0");
            textBox1_TextChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calc.DoCommand("1");
            textBox1_TextChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calc.DoCommand("2");
            textBox1_TextChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calc.DoCommand("3");
            textBox1_TextChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calc.DoCommand("4");
            textBox1_TextChanged(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calc.DoCommand("5");
            textBox1_TextChanged(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calc.DoCommand("6");
            textBox1_TextChanged(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calc.DoCommand("7");
            textBox1_TextChanged(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calc.DoCommand("8");
            textBox1_TextChanged(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calc.DoCommand("9");
            textBox1_TextChanged(sender, e);
        }

        private void buttonSignChange_Click(object sender, EventArgs e)
        {
            calc.DoCommand("-/+");
            textBox1_TextChanged(sender, e);
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            calc.DoCommand(".");
            textBox1_TextChanged(sender, e);
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            calc.DoCommand("=");
            textBox1_TextChanged(sender, e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            calc.DoCommand("+");
            textBox1_TextChanged(sender, e);
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            calc.DoCommand("-");
            textBox1_TextChanged(sender, e);
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            calc.DoCommand("*");
            textBox1_TextChanged(sender, e);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            calc.DoCommand("/");
            textBox1_TextChanged(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            calc.DoCommand("C");
            textBox1_TextChanged(sender, e);
        }
    }
}