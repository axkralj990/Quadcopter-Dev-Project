#!/usr/bin/python
# -*- coding: utf-8 -*-

"""
ZetCode PyQt4 tutorial 

This example shows an icon
in the titlebar of the window.

author: Jan Bodnar
website: zetcode.com 
last edited: October 2011
"""

import sys
from PyQt4 import QtGui
import pyqtgraph as pg
import numpy as np
from math import pi

class Example(QtGui.QWidget):
    
    Xdata = np.linspace(0,2*pi,10)
    Ydata = np.sin(Xdata)
    
    def __init__(self):
        super(Example, self).__init__()
        #super(Example, self) ==> the parent object, then we call .__init__()
        
        self.initUI() #calls a initUI() function when constructed
    
    def initUI(self):
        
        self.setGeometry(300, 300, 640, 640)
        self.setWindowTitle('Plot within a GUI')
        
        self.layout = QtGui.QGridLayout()
        self.setLayout(self.layout)
        
        self.plot = pg.PlotWidget(title="Moj graf")
        self.layout.addWidget(self.plot)
        
        self.button = QtGui.QPushButton("Narisi",self)
        self.button.clicked.connect(self.plotGraph)
        self.layout.addWidget(self.button,2,0)        
        
        self.button2 = QtGui.QPushButton("Brisi",self)
        self.button2.clicked.connect(self.clearGraph)
        self.layout.addWidget(self.button2,3,0)
        
        self.setWindowIcon(QtGui.QIcon('web.png'))        
        
        self.show()
    
    def plotGraph(self):
        self.plot.clear()
        #self.Xdata = [10,15,20,30]
        #self.Ydata = [100,1000,500,600]
        self.plot.plotItem.plot(self.Xdata,self.Ydata)
        
    def clearGraph(self):
        self.plot.clear()
        
def main():
    
    app = QtGui.QApplication(sys.argv)
    ex = Example()
    ex.Xdata = np.linspace(0,2*pi,100)
    ex.Ydata = np.sin(ex.Xdata)
    sys.exit(app.exec_())


if __name__ == '__main__':
    main()    