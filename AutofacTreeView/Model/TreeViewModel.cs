namespace AutofacTreeView.Model
{
  using System.Collections.Generic;

  using Autofac;

  using AutofacTreeView.ViewModel;

  public class TreeViewModel
  {
    public static List<string> TreeViewModels { get; set; }

    public static List<string> ReadXML()
    {
      using (var scope = MainWindow.Container.BeginLifetimeScope())
      {
        var writer = scope.Resolve<IReadAndCreateTree>();
        return writer.ReadXML();
      }
    }

    
    public TreeViewModel()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<XmlTreeReader>().As<IReadAndCreateTree>();
      builder.RegisterType<XmlReader>().As<IRead>();
      MainWindow.Container = builder.Build();

      TreeViewModels = ReadXML();
    }
  }
}