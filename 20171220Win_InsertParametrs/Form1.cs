using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _20171220Win_InsertParametrs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string cString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\student\Desktop\GulMagaza.accdb;Persist Security Info=False;";
        OleDbConnection conn;
        string sorgu;

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OleDbConnection(cString);
            sorgu = "Insert into gul (Adi,Rengi,Qiymeti) values(@ad,@soyad,@qiymet)";        

            OleDbCommand cmd = new OleDbCommand(sorgu,conn);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@qiymet", double.Parse(textBox3.Text));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            sorgu = "Select * from Gul";
            cmd.CommandText = sorgu;
            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());        
            conn.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
