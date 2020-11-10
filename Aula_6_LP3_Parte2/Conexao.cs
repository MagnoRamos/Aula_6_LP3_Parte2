using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Aula_6_LP3_Parte2
{
    public class Conexao
    {
        public static bool achou;
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\magno.LAPTOP-TBIVHDCB\source\repos\Aula_6_LP3_Parte2\Aula_6_LP3_Parte2\App_Data\Banco.mdf;Integrated Security=True");
        public static SqlCommand comando;
        public static SqlDataReader leitor;
        public static bool Conecta()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static void Fechaconexao()
        {
            if (!leitor.IsClosed)
            {
                leitor.Close();
            }

            con.Close();
        }
        public static bool Executacomando(string st)
        {
            try
            {
                comando = new SqlCommand(st, con);
                string[] vet = st.Split(' ');
                if (vet[0].ToUpper() == "SELECT")
                    leitor = comando.ExecuteReader();
                else
                    comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
    }
}