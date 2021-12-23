using System.Collections.Generic;

namespace Repository.Data
{
    public static class AppDbContext<T>
    {
        public static List<T> datas { get; }
        static AppDbContext()
        {
            datas = new List<T>();
        }
    }
}
