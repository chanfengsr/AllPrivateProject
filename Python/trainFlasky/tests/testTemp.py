# -*- coding:gbk -*-
'''第八步：让装饰器带 类 参数'''
 
class locker:
    def __init__(self):
        print("locker.__init__() should be not called.")
         
    @staticmethod
    def acquire():
        print("locker.acquire() called.（这是静态方法）")
         
    @staticmethod
    def release():
        print("  locker.release() called.（不需要对象实例）")
 
def deco(cls):
    '''cls 必须实现acquire和release静态方法'''
    def _deco(func):
        def __deco():
            print("before %s called [%s]." % (func.__name__, cls))
            cls.acquire()
            try:
                return func()
            finally:
                cls.release()
        return __deco
    return _deco
 
@deco(locker)
def myfunc():
    print(" myfunc() called.")
 
myfunc()
myfunc()


'''
before myfunc called [<class '__main__.locker'>].
locker.acquire() called.（这是静态方法）
 myfunc() called.
  locker.release() called.（不需要对象实例）
before myfunc called [<class '__main__.locker'>].
locker.acquire() called.（这是静态方法）
 myfunc() called.
  locker.release() called.（不需要对象实例）
'''