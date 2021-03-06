﻿using N_N_Scrumboard.Model;
using N_N_Scrumboard.ModelView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class BoardView : Window
    {
        private readonly BoardViewModel _boardviewModel;
        public BoardView()
        {
            InitializeComponent();
            _boardviewModel = new BoardViewModel();
            DataContext = _boardviewModel;
        }

        private void OpenNewTask(object sender, RoutedEventArgs e)
        { 
            _boardviewModel.CreateNewTask();
        }

        private void ButtonDel(object sender, RoutedEventArgs e)
        {
            Task selectedTask = (sender as Button).DataContext as Task;
            _boardviewModel.DeleteTask(selectedTask);

        }

        private void OpenNewUser(object sender, RoutedEventArgs e)
        {
            _boardviewModel.CreateNewUser();
        }

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {
            Task selectedTask = (sender as Button).DataContext as Task;
            _boardviewModel.EditTask(selectedTask);
            UpdateListBox(Todo);
            UpdateListBox(InProgress);
            UpdateListBox(Review);
            UpdateListBox(Done);
        }

        private void UpdateListBox(ListBox listBox)
        {
            ObservableCollection<Task> itemSource = listBox.ItemsSource as ObservableCollection<Task>;
            listBox.ItemsSource = null;
            listBox.ItemsSource = itemSource;
        }
    }
}
