using BK_LIS.Base;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_LIS
{
    public partial class LisMainFrm : UIForm
    {        
        public LisMainFrm()
        {
            InitializeComponent();
            uiTabControl1.TabPages.Clear();
            AddPage(new ReportMain());
            SelectPage(1000);
        }

        private void uiHeaderButton1_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new ReportMain());
            SelectPage(1000);
        }

        private void uiHeaderButton6_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new TestListBase());
            AddPage(new DicItemModel());
            AddPage(new DeptBase());
            AddPage(new DocBase());
            AddPage(new CommBase());           
            SelectPage(1000);
        }
    }
}
