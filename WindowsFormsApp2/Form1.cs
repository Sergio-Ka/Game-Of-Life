using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int k;
        ModelField ModelField = new ModelField();

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        public Form1()
        {
            InitializeComponent();
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void button1_Click(object sender, EventArgs e) // кнопка создать
        {
            ModelField.X = (int)numericUpDown1.Value;
            ModelField.Y = (int)numericUpDown2.Value;

            ModelField.CreateRandomField();

            View View = new View();
            View.UpdateView(ModelField, this);

            k = 1;
            textBox1.Text = (k).ToString();
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void button2_Click(object sender, EventArgs e) // кнопка стереть
        {
            ModelField.X = (int)numericUpDown1.Value;
            ModelField.Y = (int)numericUpDown2.Value;

            ModelField.ClearField();

            View View = new View();
            View.UpdateView(ModelField, this);

            k = 1;
            textBox1.Text = k.ToString();
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void button3_Click(object sender, EventArgs e) // кнопка старт
        {
            // делаем таймер доступным
            timer1.Enabled = true;
            // запускаем таймер
            timer1.Start();
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void button4_Click(object sender, EventArgs e) // кнопка стоп
        {
            // останавливаем таймер
            timer1.Stop();
            // делаем таймер недоступным
            timer1.Enabled = false;
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void button5_Click(object sender, EventArgs e) // кнопка about
        {
            AboutBox1 CloseButton = new AboutBox1();
            CloseButton.Show();
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // клик по ячейке
        {
            ModelField.ChangeSquareValueByCoordinate(e.RowIndex, e.ColumnIndex);

            View View = new View();
            View.UpdateView(ModelField, this);
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void timer1_Tick(object sender, EventArgs e) // контрол таймера, запускающий код раз в период
        {
            ModelChangeField ModelChangeField = new ModelChangeField();
            ModelChangeField.FieldManipulatorByAlgorithm(ModelField);

            View View = new View();
            View.UpdateView(ModelField, this);

            ModelStopGame ModelStopGame = new ModelStopGame();
            ModelStopGame.StopGame(ModelField, this);

            k++;
            textBox1.Text = k.ToString();
        }

        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

    }
}