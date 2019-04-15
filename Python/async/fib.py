def fib(n):
    index=0
    a=0
    b=1
    while index<n:
        yield b
        print(">>>after yield: {0}".format(b))
        a,b=b,a+b
        index+=1

print('-'*10 + 'test yield fib' + '-'*10)
for fib_res in fib(20):
	print(">>>yield: {0}".format(fib_res))