using Npgsql;
using System.Data;
using System.Xml.Linq;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection con;
        public NpgsqlCommand cmd;
        string constr = "Server=localhost;Port=2022;Database=3R;User Id=postgres;Password=postgres";
        private string sql = "";

        public DataTable dt;        
        private DataGridViewRow row;
        

        public Form1(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            try
            {
                con.Open();
                dataGridView1.DataSource = null;
                sql = "select karyawan.id_karyawan, karyawan.nama, departemen.nama_dep, karyawan.id_dep from \"karyawan\" inner join \"departemen\" on karyawan.id_dep=departemen.id_dep ORDER BY id_karyawan ASC";
                cmd = new NpgsqlCommand(sql, con);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new NpgsqlConnection(constr);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
            row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["nama"].Value.ToString();
            textBox2.Text = row.Cells["nama_dep"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               con.Open();
                sql = "INSERt INTO \"karyawan\" (\"id_karyawan\",\"nama\", \"id_dep\") values ('"+3+"','"+textBox1.Text+"','"+textBox2.Text+"')";
                cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data user berhasil diinputkan", "well done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    button1.PerformClick();
                    textBox1.Text = textBox2.Text = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e){
            try
            {
               con.Open();
                sql = "update \"karyawan\" set \"nama\"='"+textBox1.Text+"', \"id_dep\"='"+3+"' where \"id_karyawan\"='"+ row.Cells["_id"].Value.ToString() + "'";
                cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("data users berhasil diupdate", "well done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    button1.PerformClick();
                    textBox1.Text = textBox2.Text  = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "update fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}