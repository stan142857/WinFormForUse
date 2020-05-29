using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace mingrisoft_3_
{
    public partial class XMLOperate : Form
    {
        public XMLOperate()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {

        }

        public void createXML()
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (File.Exists("XMLOperate.xml"))
            {
                //加载文件
                xmlDocument.Load("XMLOperate.xml");
                //获得根节点，为它添加子节点
                XmlElement xmlElement = xmlDocument.DocumentElement;
            }
            else
            {

            }
        }
    }
}
