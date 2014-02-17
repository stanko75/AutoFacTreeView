using System;

namespace AutofacTreeView.ViewModel
{
  using System.Windows;
  using System.Windows.Input;

  using Autofac;

  using AutofacTreeView.Model;

  class RelayCommand: ICommand
  {
    private Action<object> _action;

    public RelayCommand(Action<object> action)
    {
      _action = action;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      _action("Hello world");
    }

    public event EventHandler CanExecuteChanged;
  }

  public class LoadXMLClick
  {
    private ICommand _LoadXmlClickCommand;

    public ICommand LoadXmlClickCommand
    {
      get
      {
        return _LoadXmlClickCommand;
      }
      set
      {
        _LoadXmlClickCommand = value;
      }
    }

    public LoadXMLClick()
    {
      LoadXmlClickCommand = new RelayCommand(new Action<object>(LoadXML));
    }


    public static void ReadXML(object obj)
    {
      using (var scope = MainWindow.Container.BeginLifetimeScope())
      {
        var writer = scope.Resolve<IReadAndCreateTree>();
        writer.ReadXML();
      }
    }

    public void LoadXML(object obj)
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<XmlReader>().As<IRead>();
      builder.Update(MainWindow.Container);
      ReadXML(obj);
    }
  }
}