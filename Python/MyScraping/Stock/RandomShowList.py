'''
使用方法

cd C:\\Users\\Administrator\\PycharmProjects\\MyScraping\Stock
python RandomShowList.py

'''
import random

showCount = 10 # 需要显示的数量
nameList = []

with open("StockList.txt", 'r', encoding = "UTF-8") as f:
    for line in f:
        if len(line) > 8:
            nameList.append(line.replace('\n',''))

if len(nameList) > 0:
    i = 0
    while i < showCount:
        print(nameList[random.randint(0, len(nameList))])
        i += 1


