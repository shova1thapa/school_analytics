﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Account_Assistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });
            search_result.ItemsSource = users;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tableName = textBox.GetLineText(0);
                string conString = @"server=localhost;userid=root;password=Sunita50655496;database=schoolmanagement";
                MySqlConnection connection = new MySqlConnection(conString);
                connection.Open();
                string command = "select * from "+tableName;
                MySqlCommand mysql_command = new MySqlCommand(command, connection);
                Console.WriteLine("Query Output");
                MySqlDataAdapter adaptor = new MySqlDataAdapter(mysql_command);
                DataTable table = new DataTable(tableName);
                adaptor.Fill(table);
                search_result.ItemsSource = table.DefaultView;

                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void search_result_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
