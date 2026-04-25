using System.Runtime.CompilerServices;

namespace Entities
{
    public class Cuenta
    {
        private string nameSurname;
        private string dniPasaporte;
        private double saldoCuenta;

        public string NameSurname { get => nameSurname; set => nameSurname = value; }
        public string DniPasaporte { get => dniPasaporte; set => dniPasaporte = value; }
        public double SaldoCuenta { get => saldoCuenta; set => saldoCuenta = value; }

    }
}
