using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        UserControlKeyBoard keyboard;
        int countDownCounter = 0;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams ret = base.CreateParams;
                ret.ExStyle |= (int)Flags.WindowStyles.WS_EX_NOACTIVATE;
                return ret;
            }
        }

        public Form1()
        {
            InitializeComponent();

            keyboard = new UserControlKeyBoard(this);

            ShowHomeButton();

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowKeyBoard();
        }

        private void ShowSingleCtrl(Control ctrl)
        {
            Controls.Clear();
            Controls.Add(ctrl);
            this.Height = ctrl.Height;
            this.Width = ctrl.Width;
            ctrl.Left = 0;
            ctrl.Top = 0;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom / 2 - this.Height / 2);
        }

        private void ShowHomeButton()
        {
            ShowSingleCtrl(this.btnHome);
        }

        private void ShowKeyBoard()
        {
            ShowSingleCtrl(this.keyboard);

            RebeginCounter();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (; countDownCounter > 0; countDownCounter--)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowHomeButton();
        }

        public void RebeginCounter()
        {
            countDownCounter = 5;
        }
    }
}
