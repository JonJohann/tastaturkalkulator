using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tastaturkalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string regneOp = "";
        string tall1, tall2 = "0";

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0: { tast0.PerformClick(); break; }
                case Keys.NumPad0: { tast0.PerformClick(); break; }
                case Keys.D1: { tast1.PerformClick(); break; }
                case Keys.D2: { tast2.PerformClick(); break; }
                case Keys.D3: { tast3.PerformClick(); break; }
                case Keys.D4: { tast4.PerformClick(); break; }
                case Keys.D5: { tast5.PerformClick(); break; }
                case Keys.D6: { tast6.PerformClick(); break; }
                case Keys.D7: { tast7.PerformClick(); break; }
                case Keys.D8: { tast8.PerformClick(); break; }
                case Keys.D9: { tast9.PerformClick(); break; }
                case Keys.Oemcomma: { tastKomma.PerformClick(); break; }
            }
        }

        private void tast_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            //display.Text = b.Text;
            switch (b.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    {
                        if (display.Text == "0")
                            display.Text = b.Text;
                        else
                            display.Text += b.Text;
                        break;
                    }
                case ",":
                    {
                        if (!display.Text.Contains(','))
                            display.Text += ",";
                        break;
                    }
                case "←":
                    {
                        if (display.Text.Length > 1)
                            display.Text = display.Text.Remove(display.Text.Length - 1);
                        else
                            display.Text = "0";
                        break;
                    }
                case "C":
                    {
                        display.Text = "0";
                        regneOp = "";
                        tall1 = tall2 = "0";
                        break;
                    }
                case "=":
                    {
                        tall2 = display.Text;
                        display.Text = svar(tall1, tall2, regneOp);
                        break;
                    }
                case "+":
                case "-":
                case "*":
                case "/":
                    {
                        regneOp = b.Text;
                        tall1 = display.Text;
                        display.Text = "0";
                        break;
                    }
            }
        }

        private string svar(string t1, string t2, string op)
        {
            string s;
            decimal n1 = Convert.ToDecimal(t1);
            decimal n2 = Convert.ToDecimal(t2);

            if (op == "+")
                s = Convert.ToString(n1 + n2);
            else if (op == "-")
                s = Convert.ToString(n1 - n2);
            else if (op == "*")
                s = Convert.ToString(n1 * n2);
            else if (op == "/")
            {
                if (n2 == 0)
                    s = "Kan ikke dele på null!";
                else
                    s = Convert.ToString(n1 / n2);
            }
            else
                s = "en feil har oppstått";
            return s;
        }
    }
}
