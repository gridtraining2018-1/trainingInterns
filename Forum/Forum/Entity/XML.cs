using System;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;
using System.Data.SqlTypes;


	/// <summary>
	/// Summary description for XML
	/// </summary>
	public static class XML
	{
		/// <summary>
		/// General function for checking xml element value
		/// </summary>
		/// <param name="doc">The Document which has to be build</param>
		/// <param name="parentNode">the parent node,to which rest child nodes will be attache</param>
		/// <param name="elementName">the element Name which has to be hang up with parent node</param>
		/// <param name="elementValue">the element Value to hang with given element name</param>
		/// <param name="createIfValueNull">the true,false value for checking element value</param>
		public static void BuildXml(XmlDocument doc, XmlNode parentNode, string elementName, string elementValue, bool createIfValueNull)
		{
			if (elementValue != null || createIfValueNull)
			{
				if (elementValue.Length > 0 && elementValue != "0")
				{
					BuildXml(doc, parentNode, elementName, elementValue);
				}
			}

		}
		/// <summary>
		/// General function to build the Xml according to requirement
		/// </summary>
		/// <param name="doc">The Document which has to be build</param>
		/// <param name="parentNode">the parent node,to which rest child nodes will be attache</param>
		/// <param name="elementName">the element Name which has to be hang up with parent node</param>
		/// <param name="elementValue">the element Value to hang with given element name</param>
		public static void BuildXml(XmlDocument doc, XmlNode parentNode, string elementName, string elementValue)
		{
			XmlElement element = doc.CreateElement(elementName);
			XmlText elementText = doc.CreateTextNode(elementValue);
			element.AppendChild(elementText);
			parentNode.AppendChild(element);
		}
		/// <summary>
		/// Genral Function to append the node having attributes with their id
		/// </summary>
		/// <param name="xmlDoc">The given XML document in which the attribute node will be inserted</param>
		/// <param name="parentNode">The Node to which the attribute node node will be hang</param>
		/// <param name="nodeName">The attribute Node name</param>
		/// <param name="attributeValue">The specified Id</param>
		/// <param name="innerText">The specified attribute text</param>
		public static void AddAttributeNode(XmlDocument xmlDoc, XmlElement parentNode, string nodeName, string attributeName, string attributeValue, string innerText)
		{
			// Create a new  element and add it to the  Parent Node
			XmlElement attributeNode = xmlDoc.CreateElement(nodeName);
			// Set attribute name and value!
			attributeNode.SetAttribute(attributeName, attributeValue.ToString());
			XmlText attributeText = xmlDoc.CreateTextNode(innerText);
			attributeNode.AppendChild(attributeText);
			parentNode.AppendChild(attributeNode);
		}

		/// <summary>
		/// Function to obtain the Value of given node in the Xml document
		/// </summary>
		/// <param name="nodeList">The nodelist containg the node </param>
		/// <param name="item">index of node</param>
		/// <returns></returns>
		public static string GetItemValue(XmlNodeList nodeList, int item)
		{
			if (nodeList.Count != 0)
			{
				if (nodeList.Count >= (item - 1))
				{
					return nodeList[item].InnerText;
				}
			}
			return "";
		}
		/// <summary>
		/// General Function To Get The Attribute Value
		/// </summary>
		/// <param name="doc">The Specified Document</param>
		/// <param name="xPath">The string path where specified attribute exist </param>
		/// <returns>The Value of Given Attribute</returns>
		public static string GetAttributeValue(XmlDocument doc, string xPath)
		{
			XmlNodeList xmlnodes = doc.SelectNodes(xPath);
			string attributeValue = "";
			if (xmlnodes.Count != 0)
			{
				attributeValue = xmlnodes[0].InnerText.ToString();

			}
			return attributeValue;
		}
		
	
		public static XmlDocument GetXmlDocument(string coloumName, SqlDataReader sqlReader)
		{
			int ordinal = sqlReader.GetOrdinal(coloumName);
			if (ordinal > 0)
			{

				SqlXml xmlMain = sqlReader.GetSqlXml(ordinal);
				if (!xmlMain.IsNull)
				{
					if (xmlMain.Value!=null)
					{
						XmlReader xmlUser = xmlMain.CreateReader();
						XmlDocument userDoc = new XmlDocument();
						if (xmlUser.Read())
						{
							userDoc.Load(xmlUser);
						} 
						return userDoc;
					}
				}
			}
			return null;
		}
	}

