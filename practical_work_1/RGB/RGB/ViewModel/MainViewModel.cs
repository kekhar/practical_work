using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace RGB.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private byte _r;
        private byte _g;
        private byte _b;
        private SolidColorBrush _color;

        public byte R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
                OnPropertyChanged();
                UpdateColor();
            }
        }

        public byte G
        {
            get
            {
                return _g;
            }
            set
            {
                _g = value;
                OnPropertyChanged();
                UpdateColor();
            }
        }

        public byte B
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value;
                OnPropertyChanged();
                UpdateColor();
            }
        }

        public SolidColorBrush Colors
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                    UpdateColor();
                }
            }
        }

        public void UpdateColor()
        {
            SolidColorBrush newBrush = new SolidColorBrush(Color.FromRgb(R, G, B));

            if (!newBrush.Color.Equals(_color?.Color))
            {
                Colors = newBrush;
            }
        }
    }
}