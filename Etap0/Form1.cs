using System.Data;

namespace Etap0
{
    public partial class Form1 : Form
    {

        private string calculation = "80085";
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = calculation;
        }
        private void handle_symbol_click(object sender, EventArgs e)
        {
            calculation += (sender as Button).Text;
            textBox1.Text = calculation;
        }
        private void handle_equals_click(object sender, EventArgs e)
        {
            string formattedCalculation = calculation.ToString().Replace(",", ".");

            try
            {
                Double calculated_value = Convert.ToDouble(new DataTable().Compute(formattedCalculation, null));
                textBox1.Text = (calculated_value).ToString();
                calculation = textBox1.Text;
            }
            catch (Exception ex)
            {
                textBox1.Text = "ERROR:" + ex;
                calculation = "";
            }
        }

        private void handle_clear_click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calculation = "";
        }

        private void handle_lucky_click(object sender, EventArgs e)
        {
            int rnum = rnd.Next(101);
            calculation += rnum;
            textBox1.Text = calculation;
        }
    }
}