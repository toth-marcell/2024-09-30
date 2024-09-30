using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_09_30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Database.OpenConnection();
            UpdateCarsListBox();
        }
        void UpdateCarsListBox()
        {
            carsListBox.Items.Clear();
            foreach (Car car in Database.GetAllCars()) carsListBox.Items.Add(car);
        }
    }
}
