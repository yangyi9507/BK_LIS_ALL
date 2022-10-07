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
    public partial class TestListBase : UIPage
    {

        public int ID = 0;//数据库主键ID
        public string strDicCode = "";// 数据集合1的选中DicCode
        public string strDicName = "";// 数据集合2的选中DicName
        public string strDicItemCode = "";// 数据集合2的选中DicItemCode

        public TestListBase()
        {
            InitializeComponent();

            GetData();//加载网格数据

            GetRightData();
        }

        #region 初始化加载数据
        public void GetRightData()
        {
            string strWhere = "";
            Maticsoft.BLL.item item = new Maticsoft.BLL.item();  //声明对象          

            if (uiDataGridView2.Rows.Count > 0) 
            {
                for (int i = 0; i < uiDataGridView2.Rows.Count; i++)
                {
                    strWhere += "'" + uiDataGridView2.Rows[i].Cells[1].Value.ToString() + "',";
                }
                strWhere = " ItemNo Not IN (" + strWhere.Trim(',') + ")";
            }
            
            uiDataGridView3.DataSource = item.GetList(strWhere).Tables[0];//赋值


            uiDataGridView3.Columns[0].HeaderText = "ID";
            uiDataGridView3.Columns[1].HeaderText = "项目编码";
            uiDataGridView3.Columns[2].HeaderText = "项目名称";
            uiDataGridView3.Columns[3].HeaderText = "顺序编号";
        }
        #endregion

        #region 初始化加载数据
        public void GetData()
        {
            Maticsoft.BLL.sampleclass sampleclass = new Maticsoft.BLL.sampleclass();  //声明对象          
            uiDataGridView1.DataSource = sampleclass.GetAllList().Tables[0];//赋值

            uiDataGridView1.Columns[0].HeaderText = "ID";
            uiDataGridView1.Columns[1].HeaderText = "大类编码";
            uiDataGridView1.Columns[2].HeaderText = "大类名称";
        }
        #endregion

        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                strDicCode = uiDataGridView1.Rows[index].Cells[1].Value.ToString();//接收字典编码查询对应字典内容
                strDicName = uiDataGridView1.Rows[index].Cells[2].Value.ToString();//接收字典名称查询对应字典内容

                string str = "ItemClassCode = '" + strDicCode + "'";
                Maticsoft.BLL.testlist testlist = new Maticsoft.BLL.testlist();  //声明对象
                                                                                    //
                uiDataGridView2.ClearAll();
                uiDataGridView2.DataSource = testlist.GetDataByDicCode(str).Tables[0];//赋值

                uiDataGridView2.Columns[0].HeaderText = "ID";
                uiDataGridView2.Columns[1].HeaderText = "项目编码";
                uiDataGridView2.Columns[2].HeaderText = "项目名称";



                string strWhere = "";
                Maticsoft.BLL.item item = new Maticsoft.BLL.item();  //声明对象          

                if (uiDataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < uiDataGridView2.Rows.Count; i++)
                    {
                        strWhere += "'" + uiDataGridView2.Rows[i].Cells[1].Value.ToString() + "',";
                    }
                    strWhere = " ItemNo Not IN (" + strWhere.Trim(',') + ")";
                }
                uiDataGridView3.ClearAll();
                uiDataGridView3.DataSource = item.GetList(strWhere).Tables[0];//赋值


                uiDataGridView3.Columns[0].HeaderText = "ID";
                uiDataGridView3.Columns[1].HeaderText = "项目编码";
                uiDataGridView3.Columns[2].HeaderText = "项目名称";
                uiDataGridView3.Columns[3].HeaderText = "顺序编号";

            };
        }
        #endregion

        #region 选中行展示数据
        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView2.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView2.CurrentRow != null)
            {
                int index = uiDataGridView2.CurrentRow.Index; //获取选中行的行号
                ID = int.Parse(uiDataGridView2.Rows[index].Cells[0].Value.ToString());//用于后续的更新删除
                strDicItemCode = uiDataGridView2.Rows[index].Cells[1].Value.ToString();//用于后续的更新删除

                uitextBox1.Text = uiDataGridView2.Rows[index].Cells[1].Value.ToString();
                uiTextBox2.Text = uiDataGridView2.Rows[index].Cells[2].Value.ToString();
            };
        }


        #endregion

        #region 选中行展示数据
        private void DataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView3.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView3.CurrentRow != null)
            {
                int index = uiDataGridView3.CurrentRow.Index; //获取选中行的行号
                ID = int.Parse(uiDataGridView3.Rows[index].Cells[0].Value.ToString());//用于后续的更新删除
                strDicItemCode = uiDataGridView3.Rows[index].Cells[1].Value.ToString();//用于后续的更新删除

                uitextBox1.Text = uiDataGridView3.Rows[index].Cells[1].Value.ToString();
                uiTextBox2.Text = uiDataGridView3.Rows[index].Cells[2].Value.ToString();
            };
        }


        #endregion

        #region 编码新增
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.testlist testlistDal = new Maticsoft.DAL.testlist();  //声明对象

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

            Maticsoft.Model.testlist testlist = new Maticsoft.Model.testlist
            {
                ItemClassCode = strDicCode,
                ItemClassName = strDicName,
                ItemCode = uitextBox1.Text,
                ItemName = uiTextBox2.Text                
            };

            bool flg = testlistDal.Add(testlist);
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
            string str = "ItemClassCode = '" + strDicCode + "'";
            Maticsoft.BLL.testlist testlist = new Maticsoft.BLL.testlist();  //声明对象
                                                                             //
            uiDataGridView2.ClearAll();
            uiDataGridView2.DataSource = testlist.GetDataByDicCode(str).Tables[0];//赋值

            uiDataGridView2.Columns[0].HeaderText = "ID";
            uiDataGridView2.Columns[1].HeaderText = "项目编码";
            uiDataGridView2.Columns[2].HeaderText = "项目名称";

            string strWhere = "";
            Maticsoft.BLL.item item = new Maticsoft.BLL.item();  //声明对象          

            if (uiDataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < uiDataGridView2.Rows.Count; i++)
                {
                    strWhere += "'" + uiDataGridView2.Rows[i].Cells[1].Value.ToString() + "',";
                }
                strWhere = " ItemNo Not IN (" + strWhere.Trim(',') + ")";
            }
            uiDataGridView3.ClearAll();
            uiDataGridView3.DataSource = item.GetList(strWhere).Tables[0];//赋值


            uiDataGridView3.Columns[0].HeaderText = "ID";
            uiDataGridView3.Columns[1].HeaderText = "项目编码";
            uiDataGridView3.Columns[2].HeaderText = "项目名称";
            uiDataGridView3.Columns[3].HeaderText = "顺序编号";
        }
        #endregion

        #region 对字典项目进行更新
        private void uiButton3_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.testlist testlistDal = new Maticsoft.DAL.testlist();  //声明对象
            Maticsoft.Model.testlist testlist = new Maticsoft.Model.testlist
            {
                ID = ID,
                ItemClassCode = strDicCode,
                ItemClassName = strDicName,
                ItemCode = uitextBox1.Text,
                ItemName = uiTextBox2.Text                
            };

            bool flg = testlistDal.Update(testlist);//更新操作
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
            Maticsoft.DAL.testlist testlistDal = new Maticsoft.DAL.testlist();  //声明对象

            bool flg = testlistDal.Delete(ID);
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

        #region 未添加项目列表查询
        private void uiButton4_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            Maticsoft.BLL.item item = new Maticsoft.BLL.item();  //声明对象          

            if (uiDataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < uiDataGridView2.Rows.Count; i++)
                {
                    strWhere += "'" + uiDataGridView2.Rows[i].Cells[1].Value.ToString() + "',";
                }
                strWhere = " ItemNo Not IN (" + strWhere.Trim(',') + ") AND ";
            }
            strWhere += " (ItemNo Like '%" + uiTextBox3.Text + "%' OR ItemName Like '%" + uiTextBox3.Text + "%')";

            uiDataGridView3.ClearAll();
            uiDataGridView3.DataSource = item.GetList(strWhere).Tables[0];//赋值

            //设置列的列标题
            uiDataGridView3.Columns[0].HeaderText = "ID";
            uiDataGridView3.Columns[1].HeaderText = "项目编码";
            uiDataGridView3.Columns[2].HeaderText = "项目名称";
            uiDataGridView3.Columns[2].HeaderText = "序号";
        }
        #endregion
    }
}
