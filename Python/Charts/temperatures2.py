import pandas as pd
import requests

df = pd.read_csv('https://raw.githubusercontent.com/andrzejmp/some_codes/main/python/temperatures/data.csv')

highs = df["TMAX"]
lows = df["TMIN"]

import matplotlib.pyplot as plt
plt.style.use('seaborn')
fig, ax = plt.subplots()
ax.plot(highs, c='red')
ax.plot(lows, c='blue')

ax.set_title("Maximum and minimum temperatures in Death Valley, 2018", fontsize=24) 
ax.set_xlabel('', fontsize=16) 
ax.set_ylabel("Temperature (C)", fontsize=16)
ax.tick_params(axis='both', which='major', labelsize=16)
#plt.savefig('tems.png', dpi=300, bbox_inches='tight')
plt.show()