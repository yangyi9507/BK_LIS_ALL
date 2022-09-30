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
    public partial class DocBase : UIPage
    {

        public int ID = 0;// 初始化科室ID
        public DocBase()
        {
            InitializeComponent();

            GetData();//加载网格数据
        }

        #region 初始化加载数据
        public void GetData()
        {
            Maticsoft.BLL.doctor doctor = new Maticsoft.BLL.doctor();  //声明对象          
            dataGridView1.DataSource = doctor.GetAllList().Tables[0];//赋值

            //设置列的列标题
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "工号";
            dataGridView1.Columns[2].HeaderText = "姓名";
            dataGridView1.Columns[3].HeaderText = "所属科室ID";
            dataGridView1.Columns[4].HeaderText = "所属科室";
            dataGridView1.Columns[5].HeaderText = "姓名简称";

            Maticsoft.BLL.Dept Dept = new Maticsoft.BLL.Dept();  //声明对象          
            uiComboBox1.DataSource = Dept.GetAllList().Tables[0];//赋值

            uiComboBox1.DisplayMember = "DeptName";
            uiComboBox1.ValueMember = "DeptID";

            uiComboBox1.SelectedValue = dataGridView1.Rows[0].Cells[3].Value.ToString();

        }
        #endregion

        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect)
            {
                if (dataGridView1.CurrentRow == null) 
                {
                    int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                    uitextBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    uiTextBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    uiTextBox4.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();

                    uiComboBox1.SelectedValue = dataGridView1.Rows[index].Cells[3].Value.ToString();//给下拉框赋值

                    ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//接收科室ID用于后续的更新
                }
            };
        }
        #endregion

        #region 更新医生
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.doctor doctorDal = new Maticsoft.DAL.doctor();  //声明对象
            Maticsoft.Model.doctor doctor = new Maticsoft.Model.doctor
            {
                ID = ID,
                DocID = uitextBox1.Text,
                DocName = uiTextBox2.Text,
                DeptID = uiComboBox1.SelectedValue.ToString(),
                DeptName = uiComboBox1.SelectedText.ToString(),
                DocNamePy = uiTextBox4.Text
            };

            bool flg = doctorDal.Update(doctor);//更新操作
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

        #region 新增医生
        private void button1_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.doctor doctorDal = new Maticsoft.DAL.doctor();  //声明对象

            #region 循环判断ID是否存在
            if (string.IsNullOrEmpty(uitextBox1.Text) || string.IsNullOrEmpty(uiTextBox2.Text)) { UIMessageTip.Show(AppCode.EMPTIY_ERROR); return; }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (uitextBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    UIMessageTip.Show(AppCode.EXIT_ERROR);
                    return;
                }
            }
            #endregion

            Maticsoft.Model.doctor doctor = new Maticsoft.Model.doctor
            {
                DocID = uitextBox1.Text,
                DocName = uiTextBox2.Text,
                DeptID = uiComboBox1.SelectedValue.ToString(),
                DeptName = uiComboBox1.SelectedText.ToString(),
                DocNamePy = uiTextBox4.Text
            };

            bool flg = doctorDal.Add(doctor);
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
            Maticsoft.DAL.doctor doctorDal = new Maticsoft.DAL.doctor();  //声明对象
            dataGridView1.ClearAll();
            dataGridView1.DataSource = doctorDal.GetList("").Tables[0];//赋值
                                                                       //设置列的列标题
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "工号";
            dataGridView1.Columns[2].HeaderText = "姓名";
            dataGridView1.Columns[3].HeaderText = "所属科室ID";
            dataGridView1.Columns[4].HeaderText = "所属科室";
            dataGridView1.Columns[5].HeaderText = "姓名简称";
        }
        #endregion
        #region 数据删除
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.doctor doctorDal = new Maticsoft.DAL.doctor();  //声明对象

            bool flg = doctorDal.Delete(ID);
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
