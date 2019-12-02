import os
from bs4 import BeautifulSoup

clearComment = False
sourceRootFolder = r'R:\testF'

pathList = [i for i in os.listdir(sourceRootFolder) if
				os.path.isdir(os.path.join(sourceRootFolder, i))]

for p in pathList:
	artFolder = os.path.join(sourceRootFolder, p)

	for f in os.listdir(artFolder):
		if os.path.isfile(os.path.join(artFolder, f)) and os.path.splitext(f)[1].lower() == '.html':
			fullName = os.path.join(artFolder, f)

			# 开始清洗
			htmlFile = open(fullName, 'rt', encoding='UTF-8')
			origHtml = htmlFile.read()
			htmlFile.close()
			bs = BeautifulSoup(origHtml, "html.parser")

			# 去掉 script
			[s.extract() for s in bs.find_all("script")]

			# 去掉 noscript
			[s.extract() for s in bs.find_all("noscript")]

			# 去掉 DIV imgzoom_pack
			[s.extract() for s in bs.find_all("div", {"class": "imgzoom_pack"})]

			# 去掉 footer
			[s.extract() for s in bs.find_all("footer")]

			# 去掉 评论
			if clearComment:
				[s.extract() for s in bs.find_all("article", {"class": "src-components-CommentZone-CommentZoneNew-index__commentWrapper--1Y8Bw"})]

			htmlFile = open(fullName, 'w', encoding='UTF-8')
			htmlFile.write(repr(bs))
			htmlFile.close()

print('Done.')