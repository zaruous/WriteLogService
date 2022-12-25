Option Explicit
const MQ_SEND_ACCESS = 2
const MQ_DENY_NONE = 0
const MQ_RECEIVE_ACCESS = 1

const MQ_NO_TRANSACTION = 0
const MQ_MTS_TRANSACTION = 1
const MQ_SINGLE_MESSAGE = 3

Dim objArgs
Set objArgs = WScript.Arguments

Dim machineName, queueName


machineName = "localhost"
queueName = "Test Queue"


dim sendQueue, receiveQueue, queueInfo
set queueInfo = CreateObject("MSMQ.MSMQQueueInfo")
queueInfo.PathName = ".\private$\" & queueName

' SEND MESSAGE
set sendQueue = queueInfo.Open (MQ_SEND_ACCESS, MQ_DENY_NONE)
Dim mqmsg
Set mqmsg = CreateObject("MSMQ.MSMQMessage")  

'Set the body and label properties
mqmsg.Body = "Sample Body" 
mqmsg.Label = "LabelXX"  
mqmsg.Send sendQueue


'set receiveQueue = queueInfo.Open (MQ_RECEIVE_ACCESS, MQ_DENY_NONE)

'Dim msg
'do while true
'  set msg = receiveQueue.Receive(MQ_NO_TRANSACTION, False, True, 20000, False)
'  if msg is nothing then
'    WScript.Quit
'  else
'  WScript.echo(msg.Body)
'    WScript.echo(msg.Label)
'  end if
'loop