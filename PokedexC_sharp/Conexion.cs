﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PokedexC_sharp
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = listapokemons; Uid = root; Pwd =; Port = 3306");
        }
        // un obj DataTable es un array de dos dimensiones donde te devuelve la consulta
        public DataTable getPokemonPorId(int id)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    //abrimos conexion, realizamos consulta, devuelve resulado que guarda en DataTable pokemons
                    new MySqlCommand("SELECT * FROM pokemon WHERE id = '" + id + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable pokemons = new DataTable();
                pokemons.Load(resultado);
                //cierra la conexion
                conexion.Close();
                return pokemons;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public DataTable getTodosPokemon()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    //abrimos conexion, realizamos consulta, devuelve resulado que guarda en DataTable pokemons
                    new MySqlCommand("SELECT * FROM pokemon", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable pokemons = new DataTable();
                pokemons.Load(resultado);
                //cierra la conexion
                conexion.Close();
                return pokemons;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public String actualizaPokemon(String id, String dato)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand
                    ("UPDATE pokemon set nombre ='"+ dato + "' WHERE id = '" +id+ "'",conexion);
                   
                MySqlDataReader resultado = consulta.ExecuteReader();
                String mensaje;
                if (resultado.RecordsAffected == 1)
                {
                    mensaje = "Actualizado correctamente";
                }
                else
                {
                    mensaje = "Error al actualizar";
                }

               
                //cierra la conexion
                conexion.Close();
                return mensaje;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}
