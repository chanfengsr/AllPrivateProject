import os
import re

fillBlanksFile = 'R:\\杨亮讲英文·全民英语背诵营.txt'
courseListFile = 'R:\\有道课程（单课）网址.txt'

# 读取文件 -> (title, url)
def file2List(fileName):
    ret = []
    title, url = '', ''

    if os.path.exists(fileName) and os.path.isfile(fileName):
        f = open(fileName, encoding = 'UTF-8')
        for line in f:
            line = line.strip()
            if line.__len__() > 0:
                if line.startswith('https') and title.__len__() > 0:
                    url = line
                    ret.append((title, url))
                else:
                    title = line

    return ret

def main():
    courseList = file2List(courseListFile)
    seekStrList = ['文本精讲', '亮解单词', '带读训练', '课后练习']

    if os.path.exists(fillBlanksFile) and os.path.isfile(fillBlanksFile):
        toFileName = fillBlanksFile.lower().replace('.txt', '_result.txt')
        toFile = open(toFileName, 'wt', encoding='UTF-8')

        f = open(fillBlanksFile, encoding='UTF-8')
        for lineLsn in f:
            lesson = lineLsn.strip()
            toFile.write(lesson + '\n')
            if lesson.__len__() > 0 and not lesson.startswith('https'):
                match = re.match('Day\\d+', lesson.replace(' ', ''))
                if match is not None:
                    dayStr = match.group()
                    courseStr = ''
                    for s in seekStrList:
                        if lesson.find(s) > -1:
                            courseStr = s
                            break

                    if courseStr.__len__() > 0:
                        for course in courseList:
                            title, url = course
                            title = title.replace(' ', '')
                            match2 = re.match('Day\\d+', title)

                            if match2 is not None:
                                dayStr2 = match2.group()
                                if dayStr == dayStr2 and title.find(courseStr) > 0:
                                    toFile.write(url + '\n')

        toFile.close()

    print('Done.')

if __name__ == '__main__':
    main()
