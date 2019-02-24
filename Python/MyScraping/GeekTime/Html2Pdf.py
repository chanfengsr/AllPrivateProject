'''
一个目录下的所有 HTML 文件全都转换成 PDF
'''
import pdfkit, time, re, os

htmlPath = r'r:\HTML'
targetPath = r'r:\PDF'


def createPdfFile(htmlFileName, pdfFileName):
    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }

    htmlFile=open(htmlFileName,'rt',encoding='utf-8')
    html=htmlFile.read()
    htmlFile.close()
    html=html.replace(r'background:#000',r'background:#fff') # 黑色背景色转成白色
    pdfkit.from_string(html,pdfFileName,options=options)
    print(pdfFileName + " --> Done.")


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
        pdfName=os.path.splitext(file)[0]+".pdf"
        pdfFileName = os.path.join(targetPath, pdfName)

        createPdfFile(htmlFileName, pdfFileName)

    print("\nCreate %s PDF file(s)." % (len(fileList)))
