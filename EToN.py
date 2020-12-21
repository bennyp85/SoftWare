import math
from decimal import Decimal
def EtoN(value, n):
    x = Decimal(1+(1/value))**value

    # Then we round it to 2 places
    output = round(x,n)
    print(output)

EtoN(100, 5)