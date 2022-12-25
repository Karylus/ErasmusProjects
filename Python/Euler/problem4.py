def is_palindromic(n):
    n_string = str(n)
    str_lenght = len(n_string)

    for i in range(int(str_lenght/2)):
        if(n_string[i] != n_string[str_lenght-i-1]):
            return False
            
    return True

def main():
    max_palindromic = 0

    for i in range(100, 1000):
        for j in range(100, 1000):
            number = i * j

            if(is_palindromic(number) and number > max_palindromic):
                max_palindromic = number
    
    print("The largest palindrome made from the product of two 3-digit numbers is : " + str(max_palindromic))

if __name__ == "__main__":
    main()