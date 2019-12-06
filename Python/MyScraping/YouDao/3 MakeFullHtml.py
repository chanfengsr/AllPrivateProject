import os
import GeekTime.webpage2html as web2html

sourceRootFolder = r'C:\Users\SAG_WangYu\Documents\ToFullHtml'

pathList = [i for i in os.listdir(sourceRootFolder) if
				os.path.isdir(os.path.join(sourceRootFolder, i))]

for p in pathList:
	artFolder = os.path.join(sourceRootFolder, p)

	for f in os.listdir(artFolder):
		if os.path.isfile(os.path.join(artFolder, f)) and os.path.splitext(f)[1].lower() == '.html':
			fullName = os.path.join(artFolder, f)

			gen = web2html.generate(fullName, comment=False, full_url=True, verbose=True)

			htmlFile = open(fullName, 'w', encoding='UTF-8')
			htmlFile.write(gen)
			htmlFile.close()

print('Done.')