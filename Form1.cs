using System.Data;
using System.Data.SqlClient;
namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=JONIE-HPZ230-2\SQLEXPRESS;Initial Catalog=crudApp;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("fill the required field", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into crudApp values(@title,@author,@price)", con);

                cmd.Parameters.AddWithValue("@title", textBox1.Text);
                cmd.Parameters.AddWithValue("@author", textBox2.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("save success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindData();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindData();


        }
        public void bindData()
        {


            SqlConnection con = new SqlConnection(@"Data Source=JONIE-HPZ230-2\SQLEXPRESS;Initial Catalog=crudApp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from crudApp", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validation())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update crudApp set title=@title,author=@author,price=@price where id=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@title", textBox1.Text);
                cmd.Parameters.AddWithValue("@author", textBox2.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("update success", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from crudApp where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("delete success", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bindData();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from crudApp where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            bindData();
        }
        public Boolean validation()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("fill the required field", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
