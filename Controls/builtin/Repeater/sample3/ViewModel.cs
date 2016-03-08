using System;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<MyTask> Tasks { get; set; } = new List<MyTask>();

        public string NewTaskTitle { get; set; }

        public ViewModel()
        {
            Tasks.Add(new MyTask("Install the DotVVM VS Extension"));
            Tasks.Add(new MyTask("Create the first project"));
            Tasks.Add(new MyTask("Build your first app"));
            Tasks.Add(new MyTask("Buy Professional Edition of DotVVM VS Extension"));
        }

        public void AddTask()
        {
            Tasks.Add(new MyTask(NewTaskTitle));
            NewTaskTitle = null;
        }

    }

    public class MyTask
    {
        public string Title { get; set; }

        public bool Completed { get; set; } = false;

        public string CompletionDate { get; set; }

        public MyTask(string title)
        {
            Title = title;
        }

        public MyTask()
        {

        }

        public void CompleteTask()
        {
            Completed = true;
            CompletionDate = DateTime.Now.ToString();
        }
    }
}