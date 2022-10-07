using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_LIS.Base
{
    public partial class SampleClassBase : UIPage
    {
        public int ID = 0;// 初始化项目ID
        public SampleClassBase()
        {
            InitializeComponent();

            GetData();//加载网格数据
        }

        #region 初始化加载数据
        public void GetData() 
        {
            Maticsoft.BLL.sampleclass sampleclassDal = new Maticsoft.BLL.sampleclass();  //声明对象          
            dataGridView1.DataSource = sampleclassDal.GetAllList().Tables[0];//赋值

            //设置列的列标题
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "项目编码";            
            dataGridView1.Columns[2].HeaderText = "项目名称";                      
        }
        #endregion


        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                uitextBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                uiTextBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();                            
                
                ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//接收科室ID用于后续的更新
            };
        }
        #endregion


        #region 更新
        private void UIButton1_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.sampleclass sampleclassDal = new Maticsoft.DAL.sampleclass();  //声明对象
            Maticsoft.Model.sampleclass sampleclass = new Maticsoft.Model.sampleclass
            {
                ID = ID,
                ClassCode = uitextBox1.Text,
                Classname = uiTextBox2.Text                            
            };

            bool flg  = sampleclassDal.Update(sampleclass);//更新操作
            if (flg)
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                DataReSet();
            }
            else {
                UIMessageTip.Show(AppCode.UPDATE_ERROR);
            }

        }
        #endregion


        #region 数据刷新
        public void DataReSet() 
        {
            Maticsoft.DAL.sampleclass sampleclassDal = new Maticsoft.DAL.sampleclass();  //声明对象
            dataGridView1.ClearAll();
            dataGridView1.DataSource = sampleclassDal.GetList("").Tables[0];//赋值

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "项目编码";
            dataGridView1.Columns[2].HeaderText = "项目名称";            
        }
        #endregion

        #region 新增
        private void Button1_Click(object sender, EventArgs e)
        {


            Maticsoft.DAL.sampleclass sampleclassDal = new Maticsoft.DAL.sampleclass();  //声明对象

            #region 循环判断ID是否存在
            if (string.IsNullOrEmpty(uitextBox1.Text)) { UIMessageTip.Show(AppCode.EMPTIY_ERROR); return; }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (uitextBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString()) 
                {
                    UIMessageTip.Show(AppCode.EXIT_ERROR);
                    return;
                }
            }
            #endregion

            Maticsoft.Model.sampleclass sampleclass = new Maticsoft.Model.sampleclass
            {
                ClassCode = uitextBox1.Text,
                Classname = uiTextBox2.Text                             
            };

            bool flg = sampleclassDal.Add(sampleclass);
            if (flg)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
                DataReSet();
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }
        }
        #endregion

        #region 删除
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.sampleclass sampleclassDal = new Maticsoft.DAL.sampleclass();  //声明对象

            bool flg = sampleclassDal.Delete(ID);
            if (flg)
            {
                UIMessageTip.Show(AppCode.DELETE_SUCCESSS);
                DataReSet();
            }
            else
            {
                UIMessageTip.Show(AppCode.DELETE_ERROR);
            }
        }
        #endregion
    }
}
