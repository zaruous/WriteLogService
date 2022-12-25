using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;

namespace WriteLogService
{

    internal class WriteLogImpl
    {
        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string queueName;
        string encoding;
        Boolean requestStop = false;

        public WriteLogImpl() {
            requestStop = false;
            queueName = app.Default.queueName;
            encoding = app.Default.msgEncoding;
            if (String.IsNullOrEmpty(encoding))
            {
                encoding = "UTF-16LE";
            }

            if (String.IsNullOrEmpty(queueName))
                throw new Exception("queue is empty.");

            LOGGER.DebugFormat("queue name : {0} , encoding : {1} ", queueName, encoding);
        }

        /// <summary>
        /// 
        /// </summary>
        public void run()
        {
            LOGGER.Debug("Program Start");
            using (MessageQueue queue = new MessageQueue(@".\private$\" + queueName))
            {
                LOGGER.DebugFormat("queue created {0} ", queueName);
                Message msg = null;
                while ((msg = queue.Receive())!=null)
                {
                    LOGGER.DebugFormat("message received ");
                    if (requestStop)
                    {
                        LOGGER.DebugFormat("request stop");
                        break;
                    }

                    var stream = msg.BodyStream;
                    String txt = StreamToString(stream);
                    LOGGER.Debug(txt);
                }
            }
            LOGGER.Debug("program exit");
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
    }
}
