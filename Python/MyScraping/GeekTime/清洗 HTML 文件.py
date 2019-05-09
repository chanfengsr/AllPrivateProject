'''
清洗一个目录下的所有 HTML 文件中的 JS
'''
import os
from bs4 import BeautifulSoup

htmlPath = r'r:\\'
targetPath = r'r:\Clearn'

if __name__ == '__main__':
    if not os.path.exists(htmlPath):
        print('%s not exists.' % (htmlPath))
        exit()

    if not os.path.exists(targetPath):
        os.makedirs(targetPath)

    fileList = [i for i in os.listdir(htmlPath) if
                os.path.isfile(os.path.join(htmlPath, i)) and os.path.splitext(i)[1].lower() == '.html']
    for file in fileList:
        htmlFileName = os.path.join(htmlPath, file)
        tarFileName = os.path.join(targetPath, file)
        print(htmlFileName)

        htmlFile = open(htmlFileName, 'rt', encoding='UTF-8')
        origHtml = htmlFile.read()
        bs = BeautifulSoup(origHtml, "html.parser")

        # 获取干净的 html 并保存
        [s.extract() for s in bs.find_all("script")]

        tarHtmlFile = open(tarFileName, 'w', encoding='utf-8')
        tarHtmlFile.write(repr(bs))
        tarHtmlFile.close()


    print('Done.')