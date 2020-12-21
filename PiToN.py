from decimal import Decimal
def piToN(n):
    x = Decimal(355/113)

    # Then we round it to 2 places
    output = round(x,n)
    print(output)
 

piToN(12)