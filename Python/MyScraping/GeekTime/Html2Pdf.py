'''
一个目录下的所有 HTML 文件全都转换成 PDF
'''
import pdfkit, time, re, os

htmlPath = r'r:\\'
targetPath = r'r:\PDF'

def createPdfFile(sourceHtml, pdfFileName):
    """
    :param sourceHtml: 源 html 可以是文件或 html 源码字符串
    :param pdfFileName:pdf 文件
    :return:
    """

    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }

    if not sourceHtml.startswith('<') and os.path.exists(sourceHtml):
        htmlFile = open(sourceHtml, 'rt', encoding='utf-8')
        html = htmlFile.read()
        htmlFile.close()
    else:
        html = sourceHtml
    html = html.replace(r'background:#000', r'background:#fff')  # 黑色背景色转成白色
    if pdfkit.from_string(html, pdfFileName, options=options):
        print("PDF 已生成。  --> %s.pdf" % (pdfFileName))


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
        pdfName = os.path.splitext(file)[0] + ".pdf"
        pdfFileName = os.path.join(targetPath, pdfName)

        createPdfFile(htmlFileName, pdfFileName)

    print("\nCreate %s PDF file(s)." % (len(fileList)))
