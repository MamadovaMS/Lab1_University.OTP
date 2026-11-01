using System;
using System.Collections.Generic;
using System.Drawing; // Для работы с цветами и координатами
using System.Windows.Forms;

namespace Lab1_University
{
    public partial class Form1 : Form
    {
        // 1. Наша коробка для хранения данных
        List<UniversityEntity> universityList = new List<UniversityEntity>();

        // 2. Переменные для всех элементов интерфейса
        TextBox txtName, txtContact, txtExperience, txtUnique1, txtUnique2;
        Button btnStudent, btnTeacher, btnAdd, btnDelete, btnShow;
        RichTextBox rtbOutput;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Label lblUnique1, lblUnique2;
        bool isStudentMode = true; // По умолчанию выбран студент

        public Form1()
        {
            // Настройка самой формы
            this.Text = "База Университета";
            this.Size = new Size(650, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- СОЗДАЕМ ЭЛЕМЕНТЫ В ПАМЯТИ ---
            txtName = new TextBox { Location = new Point(150, 20), Width = 200 };
            txtContact = new TextBox { Location = new Point(150, 60), Width = 200 };
            txtExperience = new TextBox { Location = new Point(150, 100), Width = 200 };
            txtUnique1 = new TextBox { Location = new Point(150, 140), Width = 200 };
            txtUnique2 = new TextBox { Location = new Point(150, 180), Width = 200 };

            btnStudent = new Button { Text = "Студент", Location = new Point(400, 20), Width = 150, BackColor = Color.LightBlue };
            btnTeacher = new Button { Text = "Преподаватель", Location = new Point(400, 60), Width = 150 };

            btnAdd = new Button { Text = "ДОБАВИТЬ", Location = new Point(20, 230), Width = 180, Height = 40 };
            btnDelete = new Button { Text = "УДАЛИТЬ", Location = new Point(220, 230), Width = 180, Height = 40 };
            btnShow = new Button { Text = "ПОКАЗАТЬ ВСЕХ", Location = new Point(420, 230), Width = 180, Height = 40 };

            rtbOutput = new RichTextBox { Location = new Point(20, 300), Size = new Size(580, 320) };

            // --- ДОБАВЛЯЕМ ИХ НА ФОРМУ (чтобы мы их видели) ---
            this.Controls.Add(new Label { Text = "ФИО:", Location = new Point(20, 23) });
            this.Controls.Add(new Label { Text = "Контакты:", Location = new Point(20, 63) });
            this.Controls.Add(new Label { Text = "Стаж:", Location = new Point(20, 103) });
            lblUnique1 = new Label { Text = "Группа:", Location = new Point(20, 143) };
            lblUnique2 = new Label { Text = "Направление:", Location = new Point(20, 183) };

            this.Controls.AddRange(new Control[] {
                txtName, txtContact, txtExperience, txtUnique1, txtUnique2,
                btnStudent, btnTeacher, btnAdd, btnDelete, btnShow, rtbOutput,
                lblUnique1, lblUnique2
            });

            // --- ПРИВЯЗЫВАЕМ КНОПКИ К ДЕЙСТВИЯМ (События) ---
            btnStudent.Click += BtnStudent_Click;
            btnTeacher.Click += BtnTeacher_Click;
            btnAdd.Click += BtnAdd_Click;
            btnShow.Click += BtnShow_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        // --- ЛОГИКА КНОПОК ---

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            isStudentMode = true;
            btnStudent.BackColor = Color.LightBlue;
            btnTeacher.BackColor = Color.WhiteSmoke;
            lblUnique1.Text = "Группа:";
            lblUnique2.Text = "Направление:";
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            isStudentMode = false;
            btnTeacher.BackColor = Color.LightBlue;
            btnStudent.BackColor = Color.WhiteSmoke;
            lblUnique1.Text = "Степень:";
            lblUnique2.Text = "Курсы:";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите хотя бы ФИО!");
                return;
            }

            int.TryParse(txtExperience.Text, out int experience);

            if (isStudentMode)
            {
                universityList.Add(new Student(txtName.Text, txtContact.Text, experience, txtUnique1.Text, txtUnique2.Text));
            }
            else
            {
                universityList.Add(new Teacher(txtName.Text, txtContact.Text, experience, txtUnique1.Text, txtUnique2.Text));
            }

            // Очищаем поля
            txtName.Clear(); txtContact.Clear(); txtExperience.Clear(); txtUnique1.Clear(); txtUnique2.Clear();
            MessageBox.Show("Добавлено!");
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            if (universityList.Count == 0) rtbOutput.Text = "Список пуст...";

            foreach (var person in universityList)
            {
                rtbOutput.AppendText(person.GetInfo() + "\n\n");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (universityList.Count > 0)
            {
                universityList.RemoveAt(universityList.Count - 1); // Удаляем последнего
                BtnShow_Click(sender, e); // Обновляем экран
            }
            else
            {
                MessageBox.Show("Список уже пуст!");
            }
        }
    }
}