﻿using N_N_Scrumboard.ModelView;
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
using System.Windows.Shapes;

namespace N_N_Scrumboard.View
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateTaskView : Window
    {
        private readonly CreateTaskViewModel _CreateTaskviewModel;
        public CreateTaskView()
        {
            InitializeComponent();
            _CreateTaskviewModel = new CreateTaskViewModel();
            DataContext = _CreateTaskviewModel;
        }

        public CreateTaskView(Model.Task task)
        {
            InitializeComponent();
            PageTitle.Content = "Edit User";
            _CreateTaskviewModel = new CreateTaskViewModel();
            DataContext = _CreateTaskviewModel;
            _CreateTaskviewModel.Task = task;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(Title.Text) || String.IsNullOrEmpty(Description.Text))
            {
                MessageBox.Show("Please write a Title and a Description.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _CreateTaskviewModel.CreateTask();
                Close();
            }
        }
    }
}
