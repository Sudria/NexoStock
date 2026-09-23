using NexoStock.Class;
using NexoStock.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NexoStock.Forms.Admin
{
    public partial class AdminUserPanel : UserControl
    {
        UserRepository userRepository = new UserRepository();
        List<Class.UserClass> users;


        public AdminUserPanel()
        {
            InitializeComponent();
            initilizeDatagridView();
            comboBoxRol.SelectedIndex = 0;
            comboBoxState.SelectedIndex = 0;
            initializeCountsPanels();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard.LoadNewUserControler();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            users = userRepository.GetAllUsers();
            UserClass userSelected = users.FirstOrDefault(u => u.Id == Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells[0].Value));
            dashboard.LoadUpdateUserControler(userSelected);
        }

        private void initilizeDatagridView()
        {
            dataGridViewUsers.Rows.Clear();
            dataGridViewUsers.Columns.Clear();
            dataGridViewUsers.Columns.Add("Id", "Id");
            dataGridViewUsers.Columns["Id"].Visible = false; // Ocultar la columna Id
            dataGridViewUsers.Columns.Add("Dni", "Dni");
            dataGridViewUsers.Columns.Add("Username", "Usuario");
            dataGridViewUsers.Columns.Add("Name", "Nombre");
            dataGridViewUsers.Columns.Add("Surname", "Apellido");
            dataGridViewUsers.Columns.Add("Email", "Correo");
            dataGridViewUsers.Columns.Add("Rol", "Rol");
            dataGridViewUsers.Columns.Add("State", "Estado");
            dataGridViewUsers.Columns.Add("Password", "Contraseña");
            dataGridViewUsers.Columns.Add("CreatedDate", "Fecha de Creación");


            users = userRepository.GetAllUsers();
            foreach (var user in users)
            {
                dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
            }
        }


        private void initializeCountsPanels()
        {
            int totalUsers = users.Count;
            int activeUsers = users.Count(u => u.State);
            int inactiveUsers = users.Count(u => !u.State);


            labelCountUsers.Text = users.Count.ToString();
            labelActiveUsers.Text = activeUsers.ToString();
            labelInactiveUsers.Text = inactiveUsers.ToString();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRol.SelectedIndex)
            {
                case 0: // Todos
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users)
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
                case 1: // Administrador
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users.Where(u => u.Rol == "Administrador"))
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
                case 2: // Vendedor
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users.Where(u => u.Rol == "Vendedor"))
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
                case 3: // Repositor
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users.Where(u => u.Rol == "Repositor"))
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
                case 4: // Encargado
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users.Where(u => u.Rol == "Encargado"))
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
            }
        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxState.SelectedIndex)
            {
                case 0: // Todos
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users)
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
                case 1: // Activos
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users.Where(u => u.State))
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, "Activo", user.Password, user.CreatedDate);
                    }
                    break;
                case 2: // Inactivos
                    dataGridViewUsers.Rows.Clear();
                    foreach (var user in users.Where(u => !u.State))
                    {
                        dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, "Inactivo", user.Password, user.CreatedDate);
                    }
                    break;
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridViewUsers.Rows.Clear();
            foreach (var user in users.Where(u => u.Username.ToLower().Contains(txtUser.Text.ToLower()) ||
            u.Name.ToLower().Contains(txtUser.Text.ToLower()) ||
            u.Surname.ToLower().Contains(txtUser.Text.ToLower()) ||
            u.Email.ToLower().Contains(txtUser.Text.ToLower()) ||
            u.Dni.Contains(txtUser.Text)
            ))

            {
                dataGridViewUsers.Rows.Add(user.Id, user.Dni, user.Username, user.Name, user.Surname, user.Email, user.Rol, user.State ? "Activo" : "Inactivo", user.Password, user.CreatedDate);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userId = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
            var userName = dataGridViewUsers.SelectedRows[0].Cells[2].Value.ToString();
            var userState = dataGridViewUsers.SelectedRows[0].Cells[7].Value.ToString();

            if (userState == "Inactivo")
            {
                userRepository.RestoreUser(Convert.ToInt32(userId));
                initilizeDatagridView();
                MessageBox.Show($"Usuario {userName} restaurado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                userRepository.DeleteUser(Convert.ToInt32(userId));
                initilizeDatagridView();
                MessageBox.Show($"Usuario {userName} eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            initializeCountsPanels();
        }
        



        private void buttonStyles()
        {

            var userState = dataGridViewUsers.SelectedRows[0].Cells[7].Value.ToString();

            if (userState == "Activo")
            {
                buttonDelete.TextButton = "Eliminar";
                buttonDelete.ColorBackground_1 = Color.Crimson;
            }
            else
            {
                buttonDelete.TextButton = "Restaurar";
                buttonDelete.ColorBackground_1 = Color.LimeGreen;
            }
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonStyles();
        }


    }
}
