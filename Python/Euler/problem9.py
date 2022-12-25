def is_pythagorean_triplet(a, b, c):
    it_is = False

    if (a < b and b < c):
        pow_a = a ** 2
        pow_b = b ** 2
        pow_c = c ** 2

        if (pow_a + pow_b == pow_c):
            it_is = True   
    
    return it_is

def main():
    for c in range(413, 500):
        for a in range(max(1, 1000 - c - (c - 1)), min(332, (1000 - c) // 2) + 1):
            b = 1000 - c - a
            if is_pythagorean_triplet(a, b, c):
                product = a * b * c
                
                print("The product abc is:", product)
                
if __name__ == "__main__":
    main()