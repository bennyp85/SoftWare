def Fib(value):
    if value == 1:
        return 0
    elif value == 2:
        return 1
    else:
        return Fib(value-1) + Fib(value-2)

print(Fib(9))