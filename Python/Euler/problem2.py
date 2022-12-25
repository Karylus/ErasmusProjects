def fibonacci(limit):
    secuence = [1]

    temp1 = 0
    temp2 = 1
    number = 0 #Current fibonacci number

    while True:
        number = temp1 + temp2
        
        if (number < limit):
            secuence.append(number)
            
            temp1 = temp2
            temp2 = number
    
        else:
            break
            
    print(secuence)
    
    return secuence

def sum_list_even(list):
    sum = 0

    for i in range(len(list)):
        if (list[i] % 2 == 0):
            sum += list[i]

    return sum

def main():
    fibo = fibonacci(4000000)
    
    suma = sum_list_even(fibo)

    print("The sum of the even-valued terms is: " + str(suma))

if __name__ == "__main__":
    main()