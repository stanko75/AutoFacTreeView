using System.Windows;

namespace AutofacTreeView
{
  using Autofac;

  using AutofacTreeView.Model;
  using AutofacTreeView.ViewModel;

  public partial class MainWindow : Window
  {
    public static IContainer Container { get; set; }

    public MainWindow()
    {
      InitializeComponent();
    }
  }
}