using System.Data;
using MySqlConnector;
namespace crud_c_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectString = "Server=localhost;User ID=root;Password='';Database=c-charp-crud;AllowZeroDatetime=True;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO etudiants (id, nom, age) VALUES (@id, @nom, @age)", connect);
                    command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@nom", textBox2.Text);
                    command.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Insertion réussie!" : "Aucune insertion effectuée.");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string connectString = "Server=localhost;User ID=root;Password='';Database=c-charp-crud;AllowZeroDatetime=True;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    MySqlCommand command = new MySqlCommand("DELETE FROM etudiants WHERE id = @id", connect);
                    command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text)); // Remplacez txtId par votre TextBox pour l'ID

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Suppression réussie!" : "Aucun enregistrement trouvé avec cet ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            string connectString = "Server=localhost;User ID=root;Password='';Database=c-charp-crud;AllowZeroDatetime=True;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    MySqlCommand command = new MySqlCommand("UPDATE etudiants SET nom = @nom, age = @age WHERE id = @id", connect);
                    command.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@nom", textBox2.Text);
                    command.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Mise à jour réussie!" : "Aucun enregistrement trouvé avec cet ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string connectString = "Server=localhost;User ID=root;Password='';Database=c-charp-crud;AllowZeroDatetime=True;";
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connectString))
                {
                    connect.Open();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM etudiants", connect);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;   
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

    }
}


