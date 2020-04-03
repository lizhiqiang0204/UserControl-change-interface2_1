using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace UserControl_change_interface4
{
    public class SampleVm : INotifyPropertyChanged
    {
        private SolidColorBrush _BackColor;
        public SampleVm(string title, Type content, int id)
        {
            Title = title;
            Content = content;
            Id = id;
        }
        public int Id { get; private set; }
        public string Title { get; set; }
        public Type Content { get; set; }

        public SolidColorBrush BackColor 
        {
            get { return _BackColor; }
            set { _BackColor = value; OnPropertyChanged("BackColor"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
