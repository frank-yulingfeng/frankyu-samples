using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmTips : Form
    {
        /// <summary>
        /// 耗时方法，该方法不可在主线程允许
        /// </summary>
        Action TimeConsumingAction;       

        /// <summary>
        /// 延迟描述
        /// </summary>
        public int DelayMilliseconds { get; set; } = 1000;

        public frmTips()
        {
            InitializeComponent();

            this.Shown += FrmTips_Shown;

            this.BackColor = Color.FromArgb(59, 183, 119);//Color.FromArgb(0, 47, 91);
            this.BackColor = Color.FromArgb(0, 47, 91);
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            this.lbMessage.Text = "Loading...";
            this.lbMessage.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitLocation();
        }        

        public void SetTimeConsumingAction(Action action)
        {
            TimeConsumingAction = action;
        }
         
        public void SetMessage(string message)
        {
            this.lbMessage.Text = message;

            lbMessage.AutoSize = true;

            if (lbMessage.Width > 170)
            {
                lbMessage.AutoSize = false;
                lbMessage.MaximumSize = new Size(170, 60);
                lbMessage.Size = new Size(170, 60);
            }

            InitLocation();
        }

        private void FrmTips_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(DelayMilliseconds);
                TimeConsumingAction?.Invoke();

                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() => 
                    {
                        this.Close();
                    }));
                }

            });
            thread.Start();
        }

        private void frmTips_Load(object sender, EventArgs e)
        {
        }

        private void InitLocation()
        {
            int width = picLoading.Width + lbMessage.Width + 8;

            var pic_x = (Width - width) / 2;
            picLoading.Location = new Point(pic_x, (Height - picLoading.Height) / 2);
            lbMessage.Location = new Point(pic_x + picLoading.Width + 8, (Height - lbMessage.Height) / 2);
        }
    }
}
