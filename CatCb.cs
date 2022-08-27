using System.Data;

namespace ShopMgt
{
    internal class CatCb
    {
        internal static object selectedValue;

        public static string ValueMember { get; internal set; }
        public static DataTable DatSource { get; internal set; }
        public static DataTable DataSource { get; internal set; }
    }
}