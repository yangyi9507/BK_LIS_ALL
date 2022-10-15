using BK_LIS.Base;
using BK_LIS.Pages;
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
            AddPage(new SFLReportMain());
            SelectPage(1000);
        }

        private void uiHeaderButton1_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();            
            AddPage(new SFLReportMain());            
            SelectPage(1000);
        }

        private void uiHeaderButton6_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new ItemBase());
            AddPage(new SampleClassBase());
            AddPage(new DicItemModel());
            AddPage(new TestListBase());
            AddPage(new DeptBase());
            AddPage(new DocBase());
            AddPage(new CommBase());           
            SelectPage(1000);
        }

        private void uiHeaderButton3_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new DataHandle());
            SelectPage(1000);
            
        }
    }
}
