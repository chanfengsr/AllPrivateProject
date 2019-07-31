import random
import pdfkit
# from urllib.parse import urlparse, urlunsplit, urljoin, quote
import urllib.parse

options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }


pdfkit.from_string('html', 'pdfFileName', options=options)

