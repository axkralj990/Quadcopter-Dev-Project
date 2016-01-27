# -*- coding: utf-8 -*-
'''
Arduino serial plotting program - USER INTERFACE
By: Aleksij Kraljic
19/1/2016
This program is written to plot a singe value sent from Arduino Uno to a PC
via serial protocol. The main purpose is to help develop a simmilar program
to plot values from a MPU6050 IMU, which would send several valus
via serial. It would be used to analyze motion sensing data:
-raw values from acceleromete and gyroscope
-data from DMP digital motion processor mounted on the MPU6050
-filtered spacial orientation data
'''

#Import required libraries
import sys
from PyQt4 import QtGui, QtCore
import pyqtgraph as pg
import numpy as np

#Set up a class for drawing a user interface
class Interface(QtGui.QWidget):
    #define contstucotr method
    def __init__(self):
        super(Interface,self).__init__()
        #call initUI method
        self.initUI()
        
    #define initUI method
    def initUI(self):
        #SET GEOMETRY=========================================================
        self.setGeometry(300,300,640,640)
        self.setWindowTitle("Arduino Serial Graph (single value)")
        
        #LAYOUT CONTROL=======================================================
        grid = QtGui.QGridLayout()
        self.setLayout(grid)
        
        #COM PORT LABEL
        comPortLabel = QtGui.QLabel("COM Port:")
        
        #COM PORT LINE EDIT
        comPortLE = QtGui.QLineEdit(self)
        comPortLE.textChanged.connect(self.comPortChanged)
        
        #FREEZE BUTTON
        freeze = QtGui.QPushButton("Freeze Graph")
        
        #GRAPH
        graph = pg.PlotWidget(title="Arduino Serial Data")
        
        #INSERT WIDGETS INTO THE WINDOW
        grid.addWidget(comPortLabel,0,1,1,1)
        grid.addWidget(comPortLE,0,2,1,1)
        grid.addWidget(freeze,0,0,1,1)
        grid.addWidget(graph,2,0,1,3)
        
        self.show()
        
    def comPortChanged(self,text):
        if (len(text) == 4):
            comPort=text
            print(comPort)
        
#Define main() function
def main():
    #start QT application
    app = QtGui.QApplication(sys.argv)
    #construct an object from interface class
    arduino_data = Interface()
    #exit system
    sys.exit(app.exec_())
    
#Call main function in __name__ == __main__
if __name__ == '__main__':
    main()