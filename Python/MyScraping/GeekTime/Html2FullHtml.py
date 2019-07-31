import os
import GeekTime.webpage2html as web2html


htmlPath = r'r:\Html'
targetPath = r'r:\FullHtml'

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
        print(file)

        gen = web2html.generate(htmlFileName, comment=False, full_url=True, verbose=True)
        tarHtmlFile = open(tarFileName, 'w', encoding='utf-8')
        tarHtmlFile.write(gen)
        tarHtmlFile.close()

    print('%s Done.' % len(fileList))