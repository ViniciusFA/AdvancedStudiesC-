// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.IO;

Console.WriteLine("\n***************************************************");
Console.WriteLine("MENU DE ESTUDOS AVANÇADOS");
Console.WriteLine("***************************************************");

Console.WriteLine("\n1) Consumir XML");
Console.WriteLine("2) Consumir JSON");
Console.WriteLine("3) Consumir Excel");

Console.Write("\nSelecione uma das opções abaixo: ");
var teclaDigitada = Console.ReadLine();
switch (teclaDigitada)
{
    #region:: XML
    case "1":
        //C:\ViniProjects\MenuEstudoAvancado\Documents\XML\primeiroXMLTeste.xml
        Console.Write("Digite o caminho do XML: ");
        var pathXml = Console.ReadLine();
        if (!string.IsNullOrEmpty(pathXml))
        {
            Console.Write("\n");
            XmlTextReader? reader = null;
            string contentXML = string.Empty;

            try
            {
                //Load the reader with the data file and ignore all white space nodes.
                reader = new XmlTextReader(pathXml);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            contentXML += ("<"+ reader.Name + ">");
                            //Console.Write("<{0}>", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            contentXML += reader.Value;
                            //Console.Write("Text Type: ", reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            contentXML += "<![CDATA[{"+reader.Value+"}]]>";
                            //Console.Write("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            contentXML += "<?{"+reader.Name+ "} {"+ reader.Value + "}?>";
                            //Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            contentXML += "<!--{"+reader.Value+"}-->";
                            //Console.Write("<!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            contentXML += "<?xml version='1.0'?>";
                            //Console.Write("<?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            contentXML += "Document Type";
                            //Console.Write("Document Type");
                            break;
                        case XmlNodeType.DocumentType:
                            contentXML += "<!DOCTYPE {"+ reader.Name+"} [{"+reader.Value+ "}]";
                            //Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            contentXML += reader.Name;
                            //Console.Write(reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            contentXML += ("</"+reader.Name+ ">");
                            //Console.Write("</{0}>", reader.Name);
                            break;
                        default:
                            contentXML += "Unknown type,";
                            //Console.Write("Unknown type,");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Content from XML: \n" + contentXML);
                if(reader != null)
                    reader.Close();
            }
        }

        break;
    #endregion

    #region:: JSON
    case "2":
        Console.Write("Digite o caminho do JSON: ");
        var pathJson = Console.ReadLine();
        if (!string.IsNullOrEmpty(pathJson))
        {
            //Consumir JSON
        }
        break;
    #endregion

    #region:: EXCEL
    case "3":
        Console.Write("Digite o caminho do Excel: ");
        var pathExcel = Console.ReadLine();
        if (!string.IsNullOrEmpty(pathExcel))
        {
            //Consumir EXCEL
        }
        break;
    #endregion

    default:
        Console.Write("Nenhuma opções selecionadas. Saindo...\r");
        break;
}
  

Console.WriteLine("\n***************************************************");
Console.WriteLine("Obrigado por usar o nosso sistema.");
Console.WriteLine("Até breve!!!");
Console.WriteLine("***************************************************");
