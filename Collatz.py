def Collatz(n):
    if n % 2 == 0:
        print(n//2)
        return n // 2
    if n % 2 == 1:
        print((n*3)+1)
        return (n * 3) + 1

n = 12
while n != 1:
    n = Collatz(n)