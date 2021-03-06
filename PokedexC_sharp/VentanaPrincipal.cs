﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexC_sharp
{
    public partial class VentanaPrincipal : Form
    {
        Conexion miConexion = new Conexion();
        DataTable misPokemons = new DataTable();
        int idActual = 1; //pokemon que vemos
        public VentanaPrincipal()
        {
            InitializeComponent();
           dataGridView1.DataSource = miConexion.getTodosPokemon();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private Image convierteBlobAImagen (byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }

        private void izq_Click(object sender, EventArgs e)
        {
            //para que no se nos vaya a un numero negativo
            idActual--;
            if (idActual <= 0) { idActual = 1; }
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
        }

        private void der_Click(object sender, EventArgs e)
        {
            //para que no se nos vaya a un numero negativo
            idActual++;
            if (idActual >= 151) { idActual = 151; }
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Ventana2 v = new Ventana2();
            v.cambiaNombrePokemon( "Bulbasaur");
            v.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombrePokemon.Text = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])dataGridView1.Rows[e.RowIndex].Cells["imagen"].Value);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            String nombre = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            String id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            MessageBox.Show(miConexion.actualizaPokemon(id, nombre));
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VSeleccionPokemon eligePokemon = new VSeleccionPokemon();
            eligePokemon.ShowDialog();

            // MessageBox.Show(eligePokemon.idSeleccionado.ToString());
            idActual = eligePokemon.idSeleccionado;
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
        }
    }
}
