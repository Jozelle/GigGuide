using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "CommunityToolkit.Mvvm.SourceGenerators.ObservableObjectGenerator",
    "MVVMTK0033:Inherit from ObservableObject instead of using [ObservableObject]",
    Justification = "Can use .NET attribute instead of inheritance",
    Scope = "namespaceanddescendants",
    Target = "Todo.MAUI")]

