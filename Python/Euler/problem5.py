def is_int(n):
    try:
        float(n)

    except ValueError:
        return False

    else:
        return float(n).is_integer()

def main():
    num = 0 
    limit = 20 ### MAX NUMBER TO CALCULATE EVENLY DIVISIBLE NUMBER ###

    while True:
        num += 1
        count = 0

        for i in range(limit+1):
            divided = num/(i+1)
            
            breaking = False

            if (is_int(divided)):
                count += 1
            
            elif(not is_int(divided)):
                break
            
            if(count == limit):
                breaking = True
                break
        
        if(breaking):
            break
    
    
    print("The smallest positive number that is evenly divisible by all of the numbers from 1 " 
            "to 20 is: " + str(num))

if __name__ == "__main__":
    main()