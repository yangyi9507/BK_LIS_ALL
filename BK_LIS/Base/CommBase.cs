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

namespace BK_LIS.Base
{
    public partial class CommBase : UIPage
    {
        public int ID = 0;//数据库主键ID
        public string strDicCode = "";// 数据集合1的选中DicCode
        public string strDicName = "";// 数据集合2的选中DicName
        public string strDicItemCode = "";// 数据集合2的选中DicItemCode
        public CommBase()
        {
            InitializeComponent();

            GetData();//加载网格数据
        }

        #region 初始化加载数据
        public void GetData()
        {
            Maticsoft.BLL.classtype classtype = new Maticsoft.BLL.classtype();  //声明对象          
            uiDataGridView1.DataSource = classtype.GetDicCode().Tables[0];//赋值

            uiDataGridView1.Columns[0].HeaderText = "字典编码";
            uiDataGridView1.Columns[1].HeaderText = "字典名称";
        }
        #endregion


        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                strDicCode = uiDataGridView1.Rows[index].Cells[0].Value.ToString();//接收字典编码查询对应字典内容
                strDicName = uiDataGridView1.Rows[index].Cells[1].Value.ToString();//接收字典名称查询对应字典内容

                string str = "DicCode = '" + strDicCode + "'";
                Maticsoft.BLL.classtype classtype = new Maticsoft.BLL.classtype();  //声明对象
                                                                                    //
                uiDataGridView2.ClearAll();
                uiDataGridView2.DataSource = classtype.GetDataByDicCode(str).Tables[0];//赋值

                uiDataGridView2.Columns[0].HeaderText = "ID";
                uiDataGridView2.Columns[1].HeaderText = "项目编码";
                uiDataGridView2.Columns[2].HeaderText = "项目名称";
                uiDataGridView2.Columns[3].HeaderText = "项目简拼";

            };
        }
        #endregion


        #region 选中行展示数据
        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect)
            {
                int index = uiDataGridView2.CurrentRow.Index; //获取选中行的行号
                ID = int.Parse(uiDataGridView2.Rows[index].Cells[0].Value.ToString());//用于后续的更新删除
                strDicItemCode = uiDataGridView2.Rows[index].Cells[1].Value.ToString();//用于后续的更新删除

                uitextBox1.Text = uiDataGridView2.Rows[index].Cells[1].Value.ToString();
                uiTextBox2.Text = uiDataGridView2.Rows[index].Cells[2].Value.ToString();
                uiTextBox3.Text = uiDataGridView2.Rows[index].Cells[3].Value.ToString();
            };
        }
        #endregion

        #region 编码新增
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.classtype classtypeDal = new Maticsoft.DAL.classtype();  //声明对象

            #region 循环判断ID是否存在
            if (string.IsNullOrEmpty(uitextBox1.Text)) { UIMessageTip.Show(AppCode.EMPTIY_ERROR); return; }
            for (int i = 0; i < uiDataGridView2.Rows.Count; i++)
            {
                if (uitextBox1.Text == uiDataGridView2.Rows[i].Cells[1].Value.ToString())
                {
                    UIMessageTip.Show(AppCode.EXIT_ERROR);
                    return;
                }
            }
            #endregion

            Maticsoft.Model.classtype classtype = new Maticsoft.Model.classtype
            {
                DicCode = strDicCode,
                DicName = strDicName,
                DicItemCode = uitextBox1.Text,
                DicItemName = uiTextBox2.Text,
                DicItemNamePy = uiTextBox3.Text
            };

            bool flg = classtypeDal.Add(classtype);
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

        #region 数据刷新
        public void DataReSet()
        {
            string str = "DicCode = '" + strDicCode + "'";
            Maticsoft.BLL.classtype classtype = new Maticsoft.BLL.classtype();  //声明对象
                                                                                //
            uiDataGridView2.ClearAll();
            uiDataGridView2.DataSource = classtype.GetDataByDicCode(str).Tables[0];//赋值

            uiDataGridView2.Columns[0].HeaderText = "ID";
            uiDataGridView2.Columns[1].HeaderText = "项目编码";
            uiDataGridView2.Columns[2].HeaderText = "项目名称";
            uiDataGridView2.Columns[3].HeaderText = "项目简拼";
        }
        #endregion

        #region 对字典项目进行更新
        private void uiButton3_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.classtype classtypeDal = new Maticsoft.DAL.classtype();  //声明对象
            Maticsoft.Model.classtype classtype = new Maticsoft.Model.classtype
            {
                ID = ID,
                DicCode = strDicCode,
                DicName = strDicName,
                DicItemCode = uitextBox1.Text,
                DicItemName = uiTextBox2.Text,
                DicItemNamePy = uiTextBox3.Text
            };

            bool flg = classtypeDal.Update(classtype);//更新操作
            if (flg)
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                DataReSet();
            }
            else
            {
                UIMessageTip.Show(AppCode.UPDATE_ERROR);
            }
        }
        #endregion
        #region 对字典项目进行删除
        private void uiButton2_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.classtype classtypeDal = new Maticsoft.DAL.classtype();  //声明对象

            bool flg = classtypeDal.Delete(ID);
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
