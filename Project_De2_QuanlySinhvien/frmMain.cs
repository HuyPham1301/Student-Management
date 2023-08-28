using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_De2_QuanlySinhvien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolSV_Click(object sender, EventArgs e)
        {
            frmStudent f = new frmStudent();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolMajor_Click(object sender, EventArgs e)
        {
            frmMajor f =  new frmMajor();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolSubject_Click(object sender, EventArgs e)
        {
            frmSubject f = new frmSubject();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolInputGrade_Click(object sender, EventArgs e)
        {
            frmInputGrade f = new frmInputGrade();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolViewGrade_Click(object sender, EventArgs e)
        {
            frmViewGrade f = new frmViewGrade();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmSearchMajor f = new frmSearchMajor();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
