/* 
 * Programmer: Baran Topal                       *
 * Solution name: MSMQReceiverSender             * 
 * Project name: MSMQSender                      *
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

namespace MSMQSender
{
    class MyMessageQueue
    {
        private MessageQueue _myNewQueue;

        public void Send()
        {

            _myNewQueue = new MessageQueue(@"pc900\private$\queue");
            var mm = new Message();

            var xmlDoc = new XmlDocument { XmlResolver = null };
            xmlDoc.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\foo.xml");
            var sXml = xmlDoc.InnerXml;

            mm.Body = sXml;

            _myNewQueue.Send(mm);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myMessageQueue = new MyMessageQueue();
            myMessageQueue.Send();
        }
    }
}
