using System.Windows.Forms;
namespace _2024_09_30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Database.OpenConnection();
            //Database.NewCar(new Car
            //{
            //    Make = "Test",
            //    Model = "test",
            //    Year = 2000
            //});
            //Database.DeleteCar(1);
            UpdateCarsListBox();
        }
        void UpdateCarsListBox()
        {
            carsListBox.Items.Clear();
            foreach (Car car in Database.GetAllCars()) carsListBox.Items.Add(car);
        }
    }
}
