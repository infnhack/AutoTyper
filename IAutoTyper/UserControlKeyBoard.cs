using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControlKeyBoard : UserControl
    {
        FastInputManager mgr;
        Form1 parent;

        public UserControlKeyBoard(Form1 f1)
        {
            parent = f1;
            InitializeComponent();
            mgr = new FastInputManager();
            mgr.Initialize("config.xml");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(1));
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(2));
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(3));
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(4));
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(5));
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(6));
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(7));
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(8));
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SendKeys.Send(mgr.GetString(9));
        }

        private void UserControlKeyBoard_MouseEnter(object sender, EventArgs e)
        {
            parent.RebeginCounter();
        }
    }
}
