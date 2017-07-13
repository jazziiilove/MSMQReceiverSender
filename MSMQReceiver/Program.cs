/* 
 * Programmer: Baran Topal                       *
 * Solution name: MSMQReceiverSender             * 
 * Project name: MSMQReceiver                    *
 * File name: Program.cs                         *
 *                                               *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

using System;
using System.Messaging;
using System.Xml;

namespace MSMQReceiver
{
    class Program
    {
        static void Main(string[] args)
        {

            if (MessageQueue.Exists(@"pc900\private$\queue"))
            {
                var msgQ = new MessageQueue(@"pc900\private$\queue");
                var m = new Message();

                //Use receive() function to receive the message: 
                m = msgQ.Receive();

                var text = string.Empty;
                if (m != null)
                {
                    //Use XMLMessageFormatter to receive the message without the string wrapper.
                    m.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                    text = m.Body.ToString();
                }

                var xml = new XmlDocument();
                xml.LoadXml(text);
                var selectSingleNode = xml.SelectSingleNode("/root/someNode");
                if (selectSingleNode != null)
                {
                    selectSingleNode.InnerText = "baran";
                }
                xml.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\received.xml");
            }
            else
            {
                Console.WriteLine("fail");
            }
        }
    }
}
