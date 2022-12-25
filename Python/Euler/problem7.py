from problem3 import is_prime

def main():
    position = 10001
    i = 1
    count = 0
    prime_list = []

    while True:
        
        i += 1

        if(is_prime(i)):
            prime_list.append(i)
            count += 1
        
        if(len(prime_list) == position):
            break
    
    print("The 10 001st prime number is: " + str(prime_list[position-1]))
    

if __name__ == "__main__":
    main()