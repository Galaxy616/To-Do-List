using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;
        private void ToDoList_Load(object sender, EventArgs e)
        { 

            todoList.Columns.Add("title");
            todoList.Columns.Add("Description");

            ToDoListview.DataSource = todoList;

        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            TitletextBox.Text = "";
            DescriptiontextBox.Text = "";

        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            TitletextBox.Text = todoList.Rows[ToDoListview.CurrentCell.RowIndex].ItemArray[0].ToString();
            DescriptiontextBox.Text = todoList.Rows[ToDoListview.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[ToDoListview.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                todoList.Rows[ToDoListview.CurrentCell.RowIndex]["Title"] = TitletextBox.Text;
                todoList.Rows[ToDoListview.CurrentCell.RowIndex]["Description"] = DescriptiontextBox.Text;
            }
            else
            {
                todoList.Rows.Add(TitletextBox.Text, DescriptiontextBox.Text);
            }
            TitletextBox.Text = "";
            DescriptiontextBox.Text = "";
            isEditing = false;
    }
}
}
