using DAL;
using Entities;
using System.Transactions;

namespace BLL
{
    public class CuentaBLL
    {
        CuentaDAL cuentaDal = new CuentaDAL();

        public void efectuarTransferencia(string dniATransferir, string dniPropio, string monto)
        {
            try
            {
                if (dniATransferir == "" || dniPropio == "" || monto == "") { throw new Exception("No se pueden tener datos nulos/vacios."); }

                if (dniATransferir == dniPropio) { throw new Exception("No se puede transferir a si mismo."); }
                if (Convert.ToDouble(monto) < 100) { throw new Exception("El monto a transferir tiene que ser mayor a $100."); }

                cuentaDal.efectuarTransferencia(dniATransferir, dniPropio, Convert.ToDouble(monto));
            }
            catch (Exception ex) { throw; }
        }
        public List<Cuenta> getCuentas()
        {
            try
            {
                return cuentaDal.getCuentas();
            }
            catch (Exception ex) { throw; }
        }
    }
}
