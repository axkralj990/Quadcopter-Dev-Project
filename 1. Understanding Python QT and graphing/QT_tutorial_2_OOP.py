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
from PyQt4 import QtGui, QtCore
import pyqtgraph as pg
import numpy as np
from math import pi

class Example(QtGui.QWidget):
    
    Xdata = np.linspace(0,2*pi,100)    
    
    def __init__(self):
        super(Example, self).__init__()
        #super(Example, self) ==> the parent object, then we call .__init__()
        
        self.initUI() #calls a initUI() function when constructed
        
    def initUI(self):
        
        #self.statusBar().showMessage('Ready')        
        
        self.setGeometry(300, 300, 640, 640)
        self.setWindowTitle('Plot within a GUI')
        #==============LAYOUT CONTROL==============        
        hbox = QtGui.QHBoxLayout()
        vbox = QtGui.QVBoxLayout()
        vbox.addLayout(hbox)
        self.setLayout(vbox)
        #==========================================
        
        '''
        self.layout = QtGui.QGridLayout()
        self.setLayout(self.layout)
        
        self.menu_bar = QtGui.QMenuBar()
        self.layout.addWidget(self.menu_bar)
        self.comm_menu = self.menu_bar.addMenu("COM")
        '''
        
        self.plot = pg.PlotWidget(title="Trig Function:")
        vbox.addWidget(self.plot)
        
        qle = QtGui.QLineEdit(self)
        vbox.addWidget(qle)
        #qle.textChanged[float].connect()
        
        button = QtGui.QPushButton("Plot SIN(X)",self)
        button.clicked.connect(self.plotSin)
        hbox.addWidget(button)
        
        button1 = QtGui.QPushButton("Plot COS(x)",self)
        button1.clicked.connect(self.plotCos)
        hbox.addWidget(button1)   
        
        button2 = QtGui.QPushButton("Brisi",self)
        button2.clicked.connect(self.clearGraph)
        hbox.addWidget(button2)
        
        self.setWindowIcon(QtGui.QIcon('web.png'))        
        
        self.show()
    '''
    def calcAmp(self,text):
        self.amp = 
    '''
    
    def plotSin(self):
        self.plot.clear()
        Ydata = np.sin(self.Xdata)
        self.plot.plotItem.plot([-10,20],[-15,16])
        
    def plotCos(self):
        #self.plot.clear()
        Ydata = np.cos(self.Xdata)
        self.plot.plotItem.plot(self.Xdata,Ydata)
        
    def clearGraph(self):
        self.plot.clear()
        
def main():
    
    app = QtGui.QApplication(sys.argv)
    ex = Example()
    ex.Xdata = np.linspace(0,10*pi,100)  
    sys.exit(app.exec_())


if __name__ == '__main__':
    main()    