
import functools

def repeat(num):
    def decorator_repeat(func):
        functools.wraps(func)
        def wrapper_repeat(*args,**kwargs):
            for _ in range(num):
                value=func(*args,**kwargs)
            return value
        return wrapper_repeat   
    return decorator_repeat #return a function object that can act as decorator

@repeat(4)
def say_hello():
    print(f"Hello World")

if __name__ == "__main__":
    print(f"name of say_hello:{say_hello.__name__!r}")
    say_hello()