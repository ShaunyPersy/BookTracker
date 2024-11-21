using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Components
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Title { get; set; }
        public string Author { get; set; }
        public int? Rating { get; set; }
        public int? Page { get; set; }

        private string _status;

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                    OnStatusChanged();
                }
            }
        }

        private bool _showRating;
        public bool ShowRating
        {
            get => _showRating;
            set
            {
                if (_showRating != value)
                {
                    _showRating = value;
                    OnPropertyChanged(nameof(ShowRating));
                }
            }
        }

        private bool _showPage;
        public bool ShowPage
        {
            get => _showPage;
            set
            {
                if (_showPage != value)
                {
                    _showPage = value;
                    OnPropertyChanged(nameof(ShowPage));
                }
            }
        }

        private void OnStatusChanged()
        {
            ShowRating = Status == "Completed";
            ShowPage = Status == "Reading";
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
