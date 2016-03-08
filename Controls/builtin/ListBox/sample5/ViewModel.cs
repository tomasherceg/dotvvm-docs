using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Inventor> Inventors { get; set; } = new List<Inventor>()
        {
            new Inventor(0, "Thomas Edison", "Lightbulb"),
            new Inventor(1, "Alexander Graham Bell", "Telephone"),
            new Inventor(2, "Benjamin Franklin", "Electricity"),
            new Inventor(3, "Tim Berners Lee", "HTTP Protocol"),
            new Inventor(4, "Sir John Harrington", "Toilet"),
            new Inventor(5, "Emile Berliner", "Gramophone Record")
        };

        public int? SelectedInventor { get; set; } = null;

        public List<string> Inventions { get; set; }

        public string SelectedInvention { get; set; }

        public int Points { get; set; } = 0;

        public override Task Init()
        {
            // generate random order when the page is loaded the first time
            if (!Context.IsPostBack)
            {
                Inventions = Inventors
                    .OrderBy(i => Guid.NewGuid())
                    .Select(i => i.Invention)
                    .ToList();
            }

            return base.Init();
        }

        public void CheckAnswer()
        {
            var selectedInventor = Inventors.First(i => i.Id == SelectedInventor);
            if (selectedInventor.Invention == SelectedInvention)
            {
                Inventors.Remove(selectedInventor);
                Inventions.Remove(selectedInventor.Invention);

                SelectedInventor = null;
                SelectedInvention = null;

                Points++;
            }
            else
            {
                Points = Points - 2;
            }
        }
    }

    public class Inventor
    {
        public string Name { get; set; }

        public string Invention { get; set; }

        public int Id { get; set; }

        public Inventor()
        {

        }
        public Inventor(int id, string name, string invention)
        {
            Id = id;
            Name = name;
            Invention = invention;
        }
    }
}