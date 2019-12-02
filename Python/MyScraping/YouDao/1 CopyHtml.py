import time
import random
import shutil
import tempfile
import os
import re
import hashlib
import requests
import html
from urllib.request import urlretrieve, pathname2url
from bs4 import BeautifulSoup
from shutil import copyfile


sourceRootFolder = r'D:\OneDrive\OneDrive - SAGlobal\同步资料\杨亮讲英文·全民英语背诵营（第四季）\0 正课'
targetFolder = r'R:\testF'


pathList = [i for i in os.listdir(sourceRootFolder) if
				os.path.isdir(os.path.join(sourceRootFolder, i))]

for p in pathList:
	aFolder = os.path.join(sourceRootFolder, p)
	bFolder = os.path.join(targetFolder, p)

	if not os.path.exists(bFolder):
		os.makedirs(bFolder)

	for f in os.listdir(aFolder):
		if os.path.isfile(os.path.join(aFolder, f)) and os.path.splitext(f)[1].lower() == '.html':
			copyfile(os.path.join(aFolder, f), os.path.join(bFolder, f))


print('Done.')