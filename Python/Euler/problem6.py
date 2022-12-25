def sum_square(n):
    sum = 0
    square_total = 0

    for i in range(n):
        sum += (i + 1)
    
    square_total = sum ** 2

    return square_total

def square_sum(n):
    square = 0
    sum_total = 0

    for i in range(n):
        square = (i + 1) ** 2
        sum_total += square
    
    return sum_total

def main():
    last = 100
    difference = 0

    right = square_sum(last)
    left = sum_square(last)

    difference = left - right

    print("The difference between the sum of the squares of the first one hundred " 
            "natural numbers and the square of the sum is: " + str(difference))

if __name__ == "__main__":
    main()