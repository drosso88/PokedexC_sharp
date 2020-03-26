using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexC_sharp
{
    public partial class Ventana2 : Form
    {
        public String nombrePokemon;
        public Ventana2()
        {
            InitializeComponent();
           
        }

        private void Ventana2_Load(object sender, EventArgs e)
        {

        }
        public void cambiaNombrePokemon (String nombrePokemon)
        {
             label1.Text = nombrePokemon;
        }
    }
}
