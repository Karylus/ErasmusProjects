def is_prime(n):
    for i in range(2, n-1):
        if(n % i == 0):
            return False

    return True

def first_prime_factor(n):
    factor = 1
    
    for i in range(2, n+1):
        if(n % i == 0 and is_prime(i)):
            factor = i

            break

    return factor
    
def prime_factors(n):
    factors = []
    number = n
    new_factor = 0

    for i in range(2, number):
        new_factor = first_prime_factor(int(number))

        if(new_factor == 1):
            break

        factors.append(new_factor)

        number /= new_factor

    return factors

def main():
    factors = prime_factors(600851475143)

    maximo = max(factors)

    print("The largest prime factor of the number 600851475143 is: " + str(maximo))

if __name__ == "__main__":
    main()