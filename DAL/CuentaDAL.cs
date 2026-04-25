using Entities;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace DAL
{
    public class CuentaDAL
    {
        private string connection = DBConfigurations.getDbConectionString();

        public void efectuarTransferencia(string dniATransferir, string dniPropio, double monto)
        {
            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    using (SqlCommand command = new SqlCommand("UPDATE Cuenta SET SALDO_CUENTA = SALDO_CUENTA + @SaldoCuenta WHERE DNI_CUENTA = @DniCuenta", con))
                    {
                        command.Transaction = transaction;
                        command.Parameters.AddWithValue("@DniCuenta", dniATransferir);
                        command.Parameters.AddWithValue("@SaldoCuenta", monto);
                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command = new SqlCommand("UPDATE Cuenta SET SALDO_CUENTA = SALDO_CUENTA - @SaldoCuenta WHERE DNI_CUENTA = @DniCuenta", con))
                    {
                        command.Transaction = transaction;
                        command.Parameters.AddWithValue("@DniCuenta", dniPropio);
                        command.Parameters.AddWithValue("@SaldoCuenta", monto);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public List<Cuenta> getCuentas()
        {
            List<Cuenta> listaCuentas = new List<Cuenta>();
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT DNI_CUENTA, NOMBRE_APELLIDO_TITULAR FROM Cuenta", con);
                    using (command)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cuenta cuent = new Cuenta();

                                cuent.DniPasaporte = (reader["DNI_CUENTA"].ToString());
                                cuent.NameSurname = reader["NOMBRE_APELLIDO_TITULAR"].ToString();

                                listaCuentas.Add(cuent);
                            }
                            return listaCuentas;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
