using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Malinkin_K_P.Models;

namespace Malinkin_K_P.View
{
    public class MainViewModel
    {
        public PersonModel Person { get; set; }

        public MainViewModel()
        {
            Person = new PersonModel();
        }
    }
}
