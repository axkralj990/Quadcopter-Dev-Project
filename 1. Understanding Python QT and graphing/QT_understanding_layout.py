# -*- coding: utf-8 -*-
#Understanding Layout
import sys
from PyQt4 import QtGui, QtCore
import pyqtgraph as pg
import numpy as np

class LayoutTest(QtGui.QWidget):
    
    def __init__(self):
        super(LayoutTest,self).__init__()
        
        self.initUI()
        
    def initUI(self):
        
        #SET GEOMETRY=========================================================
        self.setGeometry(300,300,640,640)
        self.setWindowTitle("Understanding Layout")
        
        #LAYOUT CONTROL=======================================================
        layout = QtGui.QGridLayout()
        self.setLayout(layout)
        
        #BUTTONS SETUP========================================================
        btn1 = QtGui.QPushButton("Plot")
        btn2 = QtGui.QPushButton("Clear Plot")
        
        #LINE EDIT SETUP======================================================
        self.qle1 = QtGui.QLineEdit(self)
        self.qle2 = QtGui.QLineEdit(self)
        self.qle3 = QtGui.QLineEdit(self)
        self.qle4 = QtGui.QLineEdit(self)
        self.qle5 = QtGui.QLineEdit(self)
        
        #LABEL SETUP==========================================================
        Y_lbl1 = QtGui.QLabel("                Y1:")
        Y_lbl2 = QtGui.QLabel("Y2:")
        K_lbl1 = QtGui.QLabel("                K1:")
        K_lbl2 = QtGui.QLabel("K2:")
        eqn_lbl = QtGui.QLabel("y(t)=K1*exp(Y1*t)+K2*exp(Y2*t)")
        time_lbl = QtGui.QLabel("Final time [s]:")
        
        #PLOT SETUP===========================================================
        self.plot = pg.PlotWidget(title="Time Response")
        
        #ADD WIDGEST TO LOCATIONS=============================================
        layout.addWidget(btn1,0,0,1,4)
        layout.addWidget(btn2,1,0,1,4)
        layout.addWidget(eqn_lbl,2,0,1,4)
        layout.addWidget(time_lbl,3,0,1,1)
        layout.addWidget(self.qle5,3,1,1,1)
        layout.addWidget(K_lbl1,4,0,1,1)
        layout.addWidget(self.qle1,4,1,1,1)
        layout.addWidget(K_lbl2,4,2)
        layout.addWidget(self.qle2,4,3)
        layout.addWidget(Y_lbl1,5,0)
        layout.addWidget(self.qle3,5,1)
        layout.addWidget(Y_lbl2,5,2)
        layout.addWidget(self.qle4,5,3)
        layout.addWidget(self.plot,6,0,1,4)
        
        #ASSIGN ACTIONS=======================================================
        btn1.clicked.connect(self.plotResponse)
        btn2.clicked.connect(self.clearGraph)        
        
        #READ LINE EDITS===========
        #qle5.setText('200')
        
        self.show()
        
    def calculateResponse(self):
        try:
            self.final_t = self.qle5.text()
            self.final_t = float(self.final_t)
            self.K1 = self.qle1.text()
            self.K1 = float(self.K1)
            self.K2 = self.qle2.text()
            self.K2 = float(self.K2)
            self.Y1 = self.qle3.text()
            self.Y1 = float(self.Y1)
            self.Y2 = self.qle4.text()
            self.Y2 = float(self.Y2)
        except:
            self.final_t = 100
            self.K1 = 0
            self.K2 = 0
            self.Y1 = 0
            self.Y2 = 0
            
        self.timeData = np.linspace(0,self.final_t,self.final_t*10)
        self.YofT = self.K1*np.exp(self.Y1*self.timeData)+self.K2*np.exp(self.Y2*self.timeData)
        
    def plotResponse(self):
        self.calculateResponse()
        self.plot.clear()
        self.plot.plotItem.plot(self.timeData,self.YofT)
        
    def clearGraph(self):
        self.plot.clear()
        
def main():
    app = QtGui.QApplication(sys.argv)
    ul = LayoutTest()
    sys.exit(app.exec_())

if __name__ == '__main__':
    main()