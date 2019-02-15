import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
import LeetCode.GetProblemList as lcGetList

realDir = os.path.dirname(os.path.realpath(__file__))
fileMod = "'''\n%s\n\n%s\n'''\n\n%s\n\nif __name__ == '__main__':\n    s = Solution()\n    # ret = s.\n    print(s)\n"


def createPyFile():
    # 定义 chromedriver 路径
    driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # 获取chrome浏览器驱动
    driver = webdriver.Chrome(executable_path=driver_path)

    pList = lcGetList.getProblemList()
    errList = []
    i = 1
    for pNo, pZh, pEn, pHref in pList:
        fileName = "r:\\%s %s(%s).py" % (pNo.zfill(4), pZh, pEn)
        url = "https://leetcode-cn.com" + pHref
        fileContent = ""
        codeContent = ""

        # print((fileName, url))
        # ('r:\\0001 两数之和(Two Sum).py', 'https://leetcode-cn.com/problems/two-sum')

        try:
            driver.get(url)
            if i == 1:  # 第一遍，手工选择下语言
                driver.implicitly_wait(10)
                time.sleep(10)
            else:
                driver.implicitly_wait(5)
                time.sleep(5)

            bs = BeautifulSoup(driver.page_source, "html.parser")
            # 题目描述
            despDiv = bs.find("div", {"class": "description__PY_Q"}).find("div", {"class": "content__eAC7"})

            # All <div> line, 还包括前面的行号
            codeMirror = bs.find("div", {"class": "CodeMirror-code"})
            for codeLineDiv in codeMirror.find_all("div"):
                codeLine = codeLineDiv.find("pre")
                if codeLine is not None:
                    codeContent += "%s\n" % (codeLine.text.replace(chr(160), chr(32)))  # 去掉非法空格

            fileContent = fileMod % (url, despDiv.text.replace(chr(8203),''), codeContent)

            # print(fileContent)
            file = open(fileName, 'w', encoding='utf-8')
            file.write(fileContent)
            file.close()

            print("%s --> Done." % (fileName))
        except:
            errList.append(fileName)

        i += 1
        # 调试用
        if i > 5: break

    if len(errList) > 0:
        print('失败的抓取：')
        for name in errList:
            print(name)


if __name__ == '__main__':
    createPyFile()
