def square(a):
    """return the square of a"""
    return a*a

L=[1,2,3]
for i in L:
    print("the square of {0} is {1}".format(i,square(i)))