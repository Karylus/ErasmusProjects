import csv
import matplotlib.pyplot as plt

#from Fahrenheit to Celcius
def from_F2C(ftem):
    return (ftem - 32)*(5/9)

filename = 'dataTemp.csv'

with open(filename) as file:
    reader = csv.reader(file) 
    header_row = next(reader) 
    
    highs = [] 
    lows = []
    for row in reader: 
        high = from_F2C(int(row[4]))
        low = from_F2C(int(row[5]))
        highs.append(high)
        lows.append(low)
        
    plt.style.use('seaborn')
    fig, ax = plt.subplots()
    ax.plot(highs, c='red')
    ax.plot(lows, c='blue')

    ax.set_title("Maximum and minimum temperatures ", fontsize=24) 
    ax.set_xlabel('', fontsize=16) 
    ax.set_ylabel("Temperature (C)", fontsize=16)
    ax.tick_params(axis='both', which='major', labelsize=16)
    #plt.savefig('tems.png', dpi=300, bbox_inches='tight')
    plt.show()