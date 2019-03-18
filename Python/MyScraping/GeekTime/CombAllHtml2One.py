'''
合并所有 Html 文件至一个文件（合并所有的 Body 内容）
'''

import time, re, os
from bs4 import BeautifulSoup

htmlPath = r'r:\HTML'
targetPath = r'r:\\'

if __name__ == '__main__':
    if not os.path.exists(htmlPath):
        print('%s not exists.' % (htmlPath))
        exit()

    if not os.path.exists(targetPath):
        os.makedirs(targetPath)

    # 生成干净的 html 的模板
    modHtml = "<html>%s<body>%s</body></html>"

    targetFileName = ''
    headHtml = ''
    bodyHtml = ''

    fileList = [os.path.join(htmlPath, i) for i in os.listdir(htmlPath) if
                os.path.isfile(os.path.join(htmlPath, i)) and os.path.splitext(i)[1].lower() == '.html']
    for file in sorted(fileList):
        htmlFile = open(file, 'rt', encoding='utf-8')
        origHtml = htmlFile.read()
        htmlFile.close()

        bs = BeautifulSoup(origHtml, "html.parser")

        # 第一个文件
        if targetFileName == '':
            title = re.sub('[\/:：*?"<>|]', '', bs.find('title').get_text()).replace('极客时间','').strip()
            targetFileName = os.path.join(targetPath, title + '.html')
            headHtml = bs.find('head')

        for bodyCont in bs.body.children:
            bodyHtml += '<div>%s</div>' % bodyCont


    targetHtml = modHtml % (headHtml, bodyHtml)
    targetFile = open(targetFileName, 'w', encoding='utf-8')
    targetFile.write(targetHtml)
    targetFile.close()
    print('Done.')