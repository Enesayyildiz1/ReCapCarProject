using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using System.Windows.Forms;

namespace WfUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ICarService carService = new CarManager(new EfCarDal());
        IColorService colorService = new ColorManager(new EfColorDal());
        IBrandService brandService = new BrandManager(new EfBrandDal());
        Entities.Concrete.Color color = new Entities.Concrete.Color();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = carService.GetCarDetails();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            
                
           

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllColors();
            GetAllBrands();
        }

        private void GetAllBrands()
        {
            cbxMarka.DataSource = brandService.GetAll().Data.ToList();
            cbxMarka.DisplayMember = "Name";
            cbxMarka.ValueMember = "Id";
        }

        private void GetAllColors()
        {
            cbxRenk.DataSource = colorService.GetAll().Data.ToList();
            cbxRenk.DisplayMember = "Name";
            cbxRenk.ValueMember = "Id";
        }
    }
}
