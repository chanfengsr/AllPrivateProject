import time, re, os
from bs4 import BeautifulSoup
import requests
import smtplib
from email.mime.text import MIMEText
from email.header import Header

url = "http://www.ip138.com/ips138.asp"
url = "http://2019.ip138.com/ic.asp"

headersBasic = {
    "User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
    # "User-Agent": "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E) ",
    "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
    "Accept-Encoding": "gzip, deflate",
    "Accept-Language": "zh-CN,zh;q=0.8,en;q=0.6"
}
ipStr = ""

session = requests.session()
s = session.get(url, headers=headersBasic)
s.encoding = 'gb2312'
bs = BeautifulSoup(s.text, "html.parser")

''' 接口坏掉的时候用
tds = bs.find_all("td", {"align": "center"})
for td in tds:
    if td.text.find("您的IP") != -1:
        ipStr = td.text
        break
'''
ipStr = bs.body.center.text
# sendStr = ipStr + '\n' + s.text
print(ipStr)

realDir = os.path.dirname(os.path.realpath(__file__))
lastIpFilePath = realDir + '\\LastIP.txt'
if os.path.exists(lastIpFilePath):
    pFile = open(lastIpFilePath, 'r', encoding='UTF-8')
    lastStr = pFile.readline()
    pFile.close()

    if lastStr.strip() != ipStr.strip():
        print('Sending mail')
        # 发送邮件
        mail_host = "smtp.mxhichina.com"    # 设置服务器
        mail_user = "wangy@saglobal.com.cn" # 用户名
        mail_pass = "Chanfengsr026!"        # 口令

        sender = 'wangy@saglobal.com.cn'
        receivers = ['chanfengsr@163.com']
        message = MIMEText(ipStr, 'plain', 'UTF-8')
        subject = 'SKE Internet IP'
        message['Subject'] = Header(subject, 'UTF-8')
        message['From'] = 'wangy@saglobal.com.cn'
        message['To'] = 'chanfengsr@163.com'

        try:
            # smtpObj = smtplib.SMTP_SSL(mail_host, 465)
            smtpObj = smtplib.SMTP()
            smtpObj.connect(mail_host, 25)  # 25 为 SMTP 端口号
            smtpObj.login(mail_user, mail_pass)
            smtpObj.sendmail(sender, receivers, message.as_string())

            # 邮件发送成功后回写文件
            pFile = open(lastIpFilePath, 'w', encoding='UTF-8')
            pFile.write(ipStr)
            pFile.close()
        except: # smtplib.SMTPException
            print("邮件发送失败！")



print('Done.')
