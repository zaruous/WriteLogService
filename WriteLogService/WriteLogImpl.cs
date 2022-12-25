using log4net.Repository.Hierarchy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;

namespace WriteLogService
{

    internal class WriteLogImpl : IDisposable
    {
        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string queueName;
        string encoding;
        MessageQueue queue;
        public WriteLogImpl() {
            queueName = app.Default.queueName;
            encoding = app.Default.msgEncoding;
            if (String.IsNullOrEmpty(encoding))
            {
                encoding = "UTF-16LE";
            }

            if (String.IsNullOrEmpty(queueName))
                throw new Exception("queue is empty.");

            LOGGER.DebugFormat("Queue name : {0} , encoding : {1} ", queueName, encoding);
            queue = new MessageQueue(@".\private$\" + queueName);
            queue.MessageReadPropertyFilter.SentTime = true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void Receive()
        {
            Message msg = null;
            try
            {
                if ((msg = queue.Receive()) != null)
                {
                    var stream = msg.BodyStream;
                    String txt = StreamToString(stream);
                    LOGGER.DebugFormat("{0} - {1}", msg.SentTime, txt);
                }

            }
            catch(Exception ex)
            {
                LOGGER.Error(ex.Message);
                LOGGER.Error(ex.StackTrace);
            }
        
         
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(encoding)))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (queue != null)
            {
                queue.Dispose();
                queue.Close();
            }
        }
    }
}
