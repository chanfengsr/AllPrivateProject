import re


def knights2 (saying):
    def inner2 ():
        return "We are the knights who say: '%s'" % saying

    return inner2


def document_it (func):
    def new_function (*args, **kwargs):
        print('Running function:', func.__name__)
        print('Positional arguments:', args)
        print('Keyword arguments:', kwargs)
        result = func(*args, **kwargs)
        print('document_it Result:', result)
        return result

    return new_function


a = document_it(knights2("ok"))

print("parm1 %s, parm2 %s." % ("123","456"))

'''
r"http://www.yinwang.org/blog-cn/2015/11/21/programming-philosophy"
^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$

'''

ds = r"http://www.yinwang.org/blog-cn/2015/11/21/programming-philosophy"  # .replace(r'/','-')

reg = r"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$"
pat = re.compile(reg)

# print(ds)
# print(re.search(reg, ds))
# print(pat.match(ds))

# print (re.search(r'\d{4}-\d{2}-\d{2}', ds).group(0))
print(re.search(r'\d{4}\/\d{2}\/\d{2}', ds).group(0))
print(re.search(r'\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}', 'xxxx2005-06-04T18:37:11xxxx').group(0))
print(re.search(r'\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}.\d{3}', 'xxxx2005-06-04T18:37:11.111xxxx').group(0))

pattern = re.compile(r'(\d{4}-\d{2}-\d{2})((T\d{2}:\d{2}:\d{2}|))((.\d{3})|)')
print(pattern.search('xxxx2005-06-04T18:37:11.111xxxx').group(0))
