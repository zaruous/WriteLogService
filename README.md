# WriteLogService

VBS 코드로 MSMQ에 메세지를 보내고, 
C#에서 MSMQ에 접근하여 메세지를 읽은 후 Log4net에 Log 메세지를 남기기 위한 코드.


VB로 작성된 코드에서 로그를 남기는 별도의 라이브러리가 없는 문제를 해결하고자하는게 목적이며, 
메세지 큐를 이용하여 로그 데이터를 남기고 Window Service에서 실행된 프로그램이 주기적으로 큐를 로드하여 로그를 남긴다.



설치
닷넷프레임워크 설치 주소에 있는 installutil을 이용하여 설치. (관리자모드)
ex) "C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "WriteLogService.exe"

이후 서비스에서 실행버튼 클릭
![image](https://user-images.githubusercontent.com/115706921/209467682-ca430ed4-f6e3-4114-92b0-538b887b2475.png)

