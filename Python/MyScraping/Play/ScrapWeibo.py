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


# 按页数抓取数据
def get_single_page(page):
    params = {
        'type': 'uid',
        'value': 5828706619,
        'containerid': 1076035828706619,
        'page': page
    }
    url = base_url + urlencode(params)
    # print(url)

    try:
        response = requests.get(url, headers=headers)
        if response.status_code == 200:
            # print(response.json())
            return response.json()
    except requests.ConnectionError as e:
        print('抓取错误', e.args)


# 解析页面返回的json数据
def parse_page(json):
    items = json.get('data').get('cards')
    for item in items:
        item = item.get('mblog')
        if item:
            data = {
                'id': item.get('id'),
                'text': pq(item.get("text")).text().replace('\n\n', '\n'),  # 仅提取内容中的文本
                'attitudes': item.get('attitudes_count'),
                'comments': item.get('comments_count'),
                'reposts': item.get('reposts_count'),
                'created': item.get('created_at')
            }

            # 点开 “全文”
            if data['text'].endswith('...全文'):
                data['text'] = getLongTextContent(data['id'])

            yield data


def getLongTextContent(id):
    url = 'https://m.weibo.cn/statuses/extend?id=%s' % id
    response = requests.get(url, headers=headers)
    longText = ''
    if response.status_code == 200:
        json = response.json()
        item = json.get('data')
        longText = pq(item.get('longTextContent')).text().replace('\n\n', '\n')
    return longText


def input_func(context):
    context['data'] = input()


context = {'data': 'default'}
if __name__ == '__main__':

    lastCrt = ''
    lastMsg = ''
    stack = queue.LifoQueue()

    t = threading.Thread(target=input_func, args=(context,))

    while True:
        json = get_single_page(1)
        results = parse_page(json)

        # 每次只取前三条消息，消息不一致才压栈
        i = 1
        for result in results:
            if i > 5:
                break

            if i == 1:
                if result['text'] == lastMsg and result['created'] == lastCrt:
                    break
                else:
                    lastCrt = result['created']
                    lastMsg = result['text']

            stack.put((result['created'], result['text']))

            i += 1

        # 从堆栈中拿出来显示，最新的消息放在最后
        if not stack.empty():
            os.system('cls')
            print()

            while not stack.empty():
                crtdTime, msg = stack.get()
                print('(%s)\n%s' % (crtdTime, msg))
                print()

        # lastCrt = ''

        # 键盘有别的输入则退出
        if not t.is_alive():
            t.start()
        t.join(60)
        if context['data'] != 'default':
            # print(context['data'])
            break
