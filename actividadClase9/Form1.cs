using BLL;
using Entities;
using System.Collections.Generic;
using System.Drawing.Text;
using static Azure.Core.HttpHeader;

namespace actividadClase9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CuentaBLL cuentaBLL = new CuentaBLL();

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarCMBSandCleartxt();
        }

        //EFECTUAR TRANSFERENCIA
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                cuentaBLL.efectuarTransferencia(Convert.ToString(comboBox2.SelectedValue), Convert.ToString(comboBox1.SelectedValue), textBox2.Text);
                MessageBox.Show("Transferencia efectuada con exito.");
                actualizarCMBSandCleartxt();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void actualizarCMBSandCleartxt()
        {
            try
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = cuentaBLL.getCuentas();
                comboBox1.DisplayMember = "nameSurname";
                comboBox1.ValueMember = "dniPasaporte";

                comboBox2.DataSource = null;
                comboBox2.DataSource = cuentaBLL.getCuentas();
                comboBox2.DisplayMember = "nameSurname";
                comboBox2.ValueMember = "dniPasaporte";

                textBox2.Text = string.Empty;


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

