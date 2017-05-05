using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectRespiratory
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtFramePerSecond.Value = Properties.Settings.Default.FPS;
            txtDuration.Value = Properties.Settings.Default.RecDur;
            cyclesTxt.Value = Properties.Settings.Default.Cycles;
            nupErrorTime.Value = Convert.ToDecimal(Properties.Settings.Default.ErrorTime);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FPS = txtFramePerSecond.Value;
            Properties.Settings.Default.RecDur = txtDuration.Value;
            Properties.Settings.Default.Cycles = cyclesTxt.Value;
            Properties.Settings.Default.ErrorTime = Convert.ToDouble(nupErrorTime.Value);
            Properties.Settings.Default.Save();
            Form.ActiveForm.Hide();
        }
        public decimal getFPS {
            get{
                return Properties.Settings.Default.FPS;
            }
        }
        public decimal getRecordingDuration
        {
            get
            {
                return Properties.Settings.Default.RecDur;
            }
        }
        public decimal getMinimumCycles
        {
            get
            {
                return Properties.Settings.Default.Cycles;
            }
        }
        public double getErrorTime
        {
            get
            {
                return Properties.Settings.Default.ErrorTime;
            }
        }
    }
}
