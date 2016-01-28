# -*- coding: utf-8 -*-
"""
Created on Wed Jan 27 17:10:43 2016

@author: Aleksij
"""

import serial

ser = serial.Serial("COM4",9600)

while True:
    r_data = ser.readline()
    data = r_data.split(" ",2)
    data[0]=float(data[0])+100
    data[1]=float(data[1])+10
    print("data: " + str(data[0]) + " time: " + str(data[1]))
    