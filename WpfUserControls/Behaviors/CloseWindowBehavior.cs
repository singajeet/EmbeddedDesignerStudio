using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using MahApps.Metro.SimpleChildWindow;

namespace WpfUserControls.Behaviors
{
    class CloseWindowBehavior : Behavior<ChildWindow>
    {
        public static readonly DependencyProperty CloseTriggerProperty =
            DependencyProperty.Register("CloseTrigger", typeof(bool), typeof(CloseWindowBehavior), new PropertyMetadata(false, OnCloseTriggerChanged));
        
        public bool CloseTrigger {
            get { return (bool)GetValue(CloseTriggerProperty); }
            set { SetValue(CloseTriggerProperty, value); }
        }

        private static void OnCloseTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var behavior = d as CloseWindowBehavior;

            if (behavior != null) {
                behavior.OnCloseTriggerChanged();
            }
        }

        private void OnCloseTriggerChanged() {
            if (this.CloseTrigger) {
                this.AssociatedObject.Close();
            }
        }
    }
}
