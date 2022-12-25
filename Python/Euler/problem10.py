import math

def main():
    last =  2000000
    suma = 0

    for num in range(2, last):
        if all(num % i != 0 for i in range(2, int(math.sqrt(num)) + 1)):
            suma += num

    print(suma)

if __name__ == "__main__":
    main()