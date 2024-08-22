using CommunityToolkit.Mvvm.ComponentModel;

namespace TournamentOrganizer_Desktop.ViewModels;

/// <summary>
/// A base class for view models in the project.
/// </summary>
public abstract partial class ViewModelBase : ObservableObject
{
    #region Fields

    [ObservableProperty]
    private string? _title;

    [ObservableProperty]
    private bool _isBusy;

    #endregion
}