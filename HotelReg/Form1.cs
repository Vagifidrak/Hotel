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

    public partial class FrmHotel : Form
    {

        HotelSQL HTL;
        public FrmHotel()
        {
            HTL = new HotelSQL();
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;

            if (Email!="" && Password!="")
            {
                Admin HtlAdmin = HTL.Admins.FirstOrDefault(adm => adm.Email == Email && adm.Password == Password);
                if (HtlAdmin != null)
                {
                    AdminPanel admPan=new AdminPanel();
                    admPan.ShowDialog();
                }
                Worker HtlWorker = HTL.Workers.FirstOrDefault(wrk => wrk.Email == Email && wrk.Password == Password);
                if (HtlWorker!=null)
                {
                    WorkerPanel wrkPan = new WorkerPanel();
                    wrkPan.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Butun xanalari doldurun");
            }
        }


    }
}
