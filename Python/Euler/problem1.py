def calculate_mul(n):
    multiplos = []

    for i in range(n):
        if i % 3 == 0:
            multiplos.append(i)
        
        elif i % 5 == 0:
            multiplos.append(i)

    return multiplos

def sum_list(list):
    sum = 0

    for i in range(len(list)):
        sum += list[i]

    return sum

def main():
    mult = calculate_mul(1000)
    suma = sum_list(mult)

    print("The sum of all the multiples of 3 or 5 below 1000 is: " + str(suma))

if __name__ == "__main__":
    main()