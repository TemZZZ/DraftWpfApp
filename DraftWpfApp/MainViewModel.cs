using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftWpfApp
{
    public class MainViewModel : Notifier
    {
        public ObservableCollection<Person> People { get; }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person("Artem", 1),
                new Person("Yuliya", 2),
                new Person("Nastya", 3)
            };
        }
    }
}
