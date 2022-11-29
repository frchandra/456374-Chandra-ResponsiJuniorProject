using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WinFormsApp2{
    internal class MyModel{
        protected static readonly NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=2022;Database=3R;User Id=postgres;Password=postgres");
        public virtual void create()
        {

        }

        public virtual void read()
        {
            
        }

        public virtual void update()
        {

        }

        public virtual void delete()
        {

        }

    }
}
