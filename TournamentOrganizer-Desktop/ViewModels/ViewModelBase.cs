using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TournamentOrganizer_Desktop.ViewModels
{
    /// <summary>
    /// A base class for view models in the project.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Events

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Property setter method that automatically raises the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}