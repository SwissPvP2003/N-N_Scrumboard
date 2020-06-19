﻿using N_N_Scrumboard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = N_N_Scrumboard.Model.Task;

namespace N_N_Scrumboard.ModelView
{
    class CreateTaskViewModel : INotifyPropertyChanged
    {
        private Board _board;
        private Task _task;

        public CreateTaskViewModel() 
        {
            _board = Board.getInstance();
            _task = new Task();
            _task.AssinedTo = new User();
            _task.AssinedTo.Name = "Noah Ziltener";
        }

        public String Title
        {
            get { return _task.Title; }
            set
            {
                if (_task.Title != value)
                {
                    _task.Title = value;
                    OnPropertyChange("Title");
                }
            }
        }

        public String Description
        {
            get { return _task.Description; }
            set
            {
                if (_task.Description != value)
                {
                    _task.Description = value;
                    OnPropertyChange("Description");
                }
            }
        }

        public void CreateTask()
        {
            _board.ToDo.Add(_task);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}