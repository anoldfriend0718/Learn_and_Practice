import functools

def count_calls(func):
    functools.wraps(func)
    def _count_calls():
        count_calls.num_calls+=1
        print(f"call {count_calls.num_calls} of {func.__name__!r}")
        return func()
    count_calls.num_calls=0
    return _count_calls

@count_calls
def say_hello():
    print(f"Hello world")

if __name__ == "__main__":
    say_hello()
    say_hello()
    say_hello()
