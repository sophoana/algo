using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SortedWord;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace SortWord.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Members

        private ISortedFour<string> _matrix;
        private static Regex _acceptedRgx = new Regex(@"^[a-zA-Z0-9]+$", RegexOptions.Compiled);
        private ObservableCollection<string> _rowItems;
        private string _addedText;

        private RelayCommand<string> _removeCommand;
        private RelayCommand _addCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Instanstiates MainWindowViewModel
        /// </summary>
        /// <param name="sortedFour"></param>
        public MainWindowViewModel(ISortedFour<string> sortedFour)
        {
            _matrix = sortedFour;
            _rowItems = new ObservableCollection<string>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Binding property for matrix 
        /// Items sorted from Top to Bottom and then 
        /// from Left to Right.
        /// </summary>
        public ObservableCollection<string> RowItems
        {
            get { return _rowItems; }
            set
            {
                if (value == _rowItems)
                    return;
                _rowItems = value;
                RaisePropertyChanged("RowItems");
            }
        }

        /// <summary>
        /// Binding Property text for displaying textbox
        /// </summary>
        public string AddedText
        {
            get { return _addedText; }
            set
            {
                if (value == _addedText)
                    return;
                _addedText = value;
                RaisePropertyChanged("AddedText");
            }
        }

        #endregion

        #region Commands
        /// <summary>
        /// RelayCommand for Removing
        /// </summary>
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                    _removeCommand = new RelayCommand<string>(x => OnRemove(x));
                return _removeCommand;
            }
        }
        private void OnRemove(string param)
        {
            _matrix.Remove(param);
            _refresh();
        }

        /// <summary>
        /// RelayCommand for Adding.
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(() => OnAdd());
                return _addCommand;
            }
        }
        private void OnAdd()
        {
            if (string.IsNullOrEmpty(_addedText))
                return;

            var words = _addedText.Trim().Split(' ').ToList()
                .Where(x => _acceptedRgx.IsMatch(x))
                .Select(x => x);

            if (words == null || words.Count() == 0) return;
            words.ToList().ForEach(x => _matrix.Add(x));

            // Refresh
            _refresh();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Refreshing the matrix, that impacts output display.
        /// </summary>
        private void _refresh()
        {
            _addedText = string.Empty;
            _rowItems = new ObservableCollection<string>();
            for (int i = 0; i < _matrix.RowCount; i++)
                _matrix[i].ToList().ForEach(x => _rowItems.Add(x));

            RaisePropertyChanged(nameof(RowItems));
            RaisePropertyChanged(nameof(AddedText));
        }
        #endregion
    }
}
