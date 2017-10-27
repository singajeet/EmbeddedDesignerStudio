using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahApps.Metro.Controls;
using System.Windows;

namespace WpfUserControls.Customizations
{
    public class CustomHamburgerMenuIconItem : HamburgerMenuIconItem
    {
        public static readonly DependencyProperty ToolTipProperty
            = DependencyProperty.Register("ToolTip",
                typeof(object),
                typeof(CustomHamburgerMenuIconItem),
                new PropertyMetadata(null));

        public object ToolTip
        {
            get { return (object)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }
    }
}
