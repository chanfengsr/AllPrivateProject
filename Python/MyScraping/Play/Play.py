import time, os
import requests
import threading
import queue
from urllib.parse import urlencode
from pyquery import PyQuery as pq

host = 'm.weibo.cn'
base_url = 'https://%s/api/container/getIndex?' % host
user_agent = 'User-Agent: Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1 wechatdevtools/0.7.0 MicroMessenger/6.3.9 Language/zh_CN webview/0'

headers = {
    'Host': host,
    'Referer': 'https://m.weibo.cn/u/5828706619',
    'User-Agent': user_agent
}

params = {
    'type': 'uid',
    'value': 5828706619,
    'containerid': 1076035828706619,
    'page': 1
}
url = base_url + urlencode(params)

response = requests.get('https://m.weibo.cn/statuses/extend?id=4362353074395391', headers=headers)
if response.status_code == 200:
    json = response.json()
    item = json.get('data')
    longText = pq(item.get('longTextContent')).text().replace('\n\n','\n')
    print(longText)
