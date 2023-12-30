using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace projektIOv2.wykres
{
    public class NDatePoint : INotifyPropertyChanged
    {
        private NDate _dateTime;

        private double _value;


        public NDate NDate
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
                OnPropertyChanged("NDate");
            }
        }


        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public NDatePoint()
        {
        }


        public NDatePoint(NDate dateTime, double value)
        {
            _dateTime = dateTime;
            _value = value;
        }



        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
