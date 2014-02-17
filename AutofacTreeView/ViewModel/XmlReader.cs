namespace AutofacTreeView.ViewModel
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Windows;
  using System.Xml.Linq;

  using AutofacTreeView.Model;

  public class XmlReader: IRead
  {
    public List<string> Read()
    {
      List<string> TreeViewModels = new List<string>();
      //TreeViewModels.Add("test");
      XElement linqMyElement = XElement.Load(@"..\..\MyXML.xml");
      var elements =
        from name in linqMyElement.Elements("items").Elements("item").Elements("urn")
        select name;
      foreach (var element in elements)
      {
        TreeViewModels.Add(element.Value);
      }
      //TreeViewModel tvm = new TreeViewModel();
      TreeViewModel.TreeViewModels = TreeViewModels;
      return TreeViewModels;
    }
  }
}