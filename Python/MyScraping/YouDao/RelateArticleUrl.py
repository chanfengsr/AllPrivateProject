import os

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

    if os.path.exists(fillBlanksFile) and os.path.isfile(fillBlanksFile):
        toFileName = fillBlanksFile.lower().replace('.txt', '_result.txt')
        toFile = open(toFileName, 'wt', encoding='UTF-8')

        f = open(fillBlanksFile, encoding='UTF-8')
        for lineLsn in f:
            lesson = lineLsn.strip()
            toFile.write(lesson + '\n')
            if lesson.__len__() > 0 and not lesson.startswith('https'):
                for course in courseList:
                    title, url = course
                    if title == lesson:
                        toFile.write(url + '\n')

        toFile.close()

    print('Done.')

if __name__ == '__main__':
    main()