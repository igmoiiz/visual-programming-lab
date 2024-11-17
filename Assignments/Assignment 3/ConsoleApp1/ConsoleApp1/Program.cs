using System;
using System.Xml;

class Program
{
    static void Main()
    {
        // Part 1: Create XML file
        CreateXML();

        // Part 2: Read and display XML file
        ReadXML();
    }

    static void CreateXML()
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t"
        };

        using (XmlWriter writer = XmlWriter.Create("GPS.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("GPS_Log");

            // Position element
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("DateTime", DateTime.Now.ToString());
            writer.WriteElementString("x", "65.8973342");
            writer.WriteElementString("y", "72.3452346");

            // SatteliteInfo element
            writer.WriteStartElement("SatteliteInfo");
            writer.WriteElementString("Speed", "40");
            writer.WriteElementString("NoSatt", "7");
            writer.WriteEndElement(); // End of SatteliteInfo

            writer.WriteEndElement(); // End of Position

            // Image element
            writer.WriteStartElement("Image");
            writer.WriteAttributeString("Resolution", "1024x800");
            writer.WriteElementString("Path", @"\images\1.jpg");
            writer.WriteEndElement(); // End of Image

            writer.WriteEndElement(); // End of GPS_Log
            writer.WriteEndDocument();
        }

        Console.WriteLine("XML file 'GPS.xml' created successfully.");
    }

    static void ReadXML()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("GPS.xml");

        Console.WriteLine("\nDisplaying GPS.xml Content:\n");

        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            if (node.Name == "Position")
            {
                Console.WriteLine($"Position DateTime: {node.Attributes["DateTime"].Value}");
                foreach (XmlNode child in node.ChildNodes)
                {
                    Console.WriteLine($"{child.Name}: {child.InnerText}");
                }
            }
            else if (node.Name == "Image")
            {
                Console.WriteLine($"Image Resolution: {node.Attributes["Resolution"].Value}");
                Console.WriteLine($"Path: {node["Path"].InnerText}");
            }
        }
    }
}