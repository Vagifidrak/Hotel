using HotelReg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReg
{
    public partial class WorkerPanel : Form
    {
        HotelSQL HTL;
        public WorkerPanel()
        {
            HTL = new HotelSQL();
            InitializeComponent();
        }

        private void WorkerPanel_Load(object sender, EventArgs e)
        {
            cmbType.Items.AddRange(HTL.Types.Select(Mb => Mb.Category).ToArray());
            cmbNumber.Items.AddRange(HTL.Rooms.Select(Rm => Rm.RoomNumber.ToString()).ToArray());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FrsName = txtFirstName.Text;
            string LstName = txtLastName.Text;
            string Phn = txtPhone.Text;

        }

        private void rdbFree_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFree.Checked)
            {
                IsCheckedType(false);
            }
           
        }
        private void IsCheckedType(bool tp)
        {
            int typeid=0;
            if (cmbType.Text != "")
            {
                typeid = HTL.Types.First(ht=>ht.Category==cmbType.Text).ID;
            }
            if (tp == true)
            {
                cmbNumber.Items.Clear();
                cmbNumber.Items.AddRange(HTL.Rooms.Where(ht => ht.Status == true && ht.TypeID==typeid).Select(ht => ht.RoomNumber.ToString()).ToArray());

            }
            else
            {
                cmbNumber.Items.Clear();
                cmbNumber.Items.AddRange(HTL.Rooms.Where(ht => ht.Status == false && ht.TypeID == typeid).Select(ht => ht.RoomNumber.ToString()).ToArray());


            }

        }
        private void rdbFull_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdbFull.Checked)
            {
                IsCheckedType(true);
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int typeid = 0;
            cmbNumber.Items.Clear();
            if (cmbType.Text != "")
            {
                typeid = HTL.Types.First(ht => ht.Category == cmbType.Text).ID;
            cmbNumber.Items.AddRange(HTL.Rooms.Where(pr=>pr.TypeID==typeid).Select(ht => ht.RoomNumber.ToString()).ToArray());

            }
        }
    }
}
