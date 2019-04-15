import threading
def input_func( context ):
    context[ 'data' ] = input( 'input:' )

context = { 'data' : 'default' }
t = threading.Thread( target = input_func ,args = ( context , ) )
t.start( )
t.join( 10 ) #等待10秒
print( context )