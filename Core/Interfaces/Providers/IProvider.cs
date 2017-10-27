using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Core.Interfaces.Providers
{
    interface IProvider : INotifyPropertyChanged
    {
        string Name { get; }
        string Description { get; }
    }
}
