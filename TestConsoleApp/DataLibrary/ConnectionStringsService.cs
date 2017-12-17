using System;

namespace DataLibrary
{
    public static class ConnectionStringsService
    {
        public static string Resolve()
            => Environment.UserName == "VLEV"
                ? "Data Source=LAPTOP-VLEV;Initial Catalog=Wpf;User ID=sa;Password=Passw0rd"
                : "Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=1488";
    }
}
