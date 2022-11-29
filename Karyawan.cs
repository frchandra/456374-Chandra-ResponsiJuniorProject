using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace WinFormsApp2{
    internal class Karyawan : MyModel{
        private int id_karyawan;
        private string nama;
        private int id_dep;

        public int idKaryawan { get => id_karyawan; }
        public string name { get => nama; }
        public int idDep { get => id_dep; }
   
        public Karyawan(int id_karyawan, string nama, int id_dep){
            this.id_karyawan = id_karyawan;
            this.nama = nama;
            this.id_dep = id_dep;
        }

        public override void create()
        {
            base.create();
        }

        public override void update()
        {
            base.create();
        }

        public override void delete()
        {
            base.create();
        }

    }
}
