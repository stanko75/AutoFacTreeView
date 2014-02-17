namespace AutofacTreeView.ViewModel
{
  using System.Collections.Generic;

  using AutofacTreeView.Model;

  public class XmlTreeReader : IReadAndCreateTree
  {
    private IRead _reader;

    public XmlTreeReader(IRead reader)
    {
      _reader = reader;
    }

    public List<string> ReadXML()
    {
      return this._reader.Read();
    }
  }
}