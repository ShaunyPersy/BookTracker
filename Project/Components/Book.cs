using System.ComponentModel;

namespace Project.Components
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int? rating { get; set; }
        public int? page { get; set; }

        private string _status;

        public string status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(status));
                    OnStatusChanged();
                }
            }
        }

        private bool _showRating;
        public bool showRating
        {
            get => _showRating;
            set
            {
                if (_showRating != value)
                {
                    _showRating = value;
                    OnPropertyChanged(nameof(showRating));
                }
            }
        }

        private bool _showPage;
        public bool showPage
        {
            get => _showPage;
            set
            {
                if (_showPage != value)
                {
                    _showPage = value;
                    OnPropertyChanged(nameof(showPage));
                }
            }
        }

        private void OnStatusChanged()
        {
            showRating = status == "Completed";
            showPage = status == "Reading";
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
