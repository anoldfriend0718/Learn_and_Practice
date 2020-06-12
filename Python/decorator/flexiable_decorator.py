# define decorators that can be used both with and without arguments. Most likely, you don’t need this, but it is nice to have the flexibility.

import functools
import time 

def slow_down(_func=None,*,rate=1):
    def decorator_slow_down(func):
        @functools.wraps(func)
        def wrapper_slow_down(*args,**kwargs):
            time.sleep(rate)
            return func(*args,**kwargs)
        return wrapper_slow_down

    if _func==None:
        return decorator_slow_down
    else:
        return decorator_slow_down(_func)

@slow_down(rate=2)
def countdown(from_number):
    if from_number < 1:
        print("Liftoff!")
    else:
        print(from_number)
        countdown(from_number - 1)

countdown(3)