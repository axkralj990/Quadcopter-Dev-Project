# -*- coding: utf-8 -*-
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
import Queue
from globals import LiveDataFeed, get_all_from_queue
from comMonitor import ComMonitorThread

#Set up a class for drawing a user interface
class DataMonitor(QtGui.QMainWindow):
    #define contstucotr method
    def __init__(self):
        super(DataMonitor,self).__init__()
        #call initUI method
        self.initUI()
        self.livefeed = LiveDataFeed()
        
        self.ptimeV=0
        self.pvalue=0
        self.timeV=0
        self.value=0        
        
    #define initUI method
    def initUI(self):
        #SET GEOMETRY=========================================================
        self.resize(640,640)
        self.setWindowTitle("Arduino Serial Graph (single value)")
        self.createMainFrame()
        
        self.comPort = "COM4"
        self.baudRate = "9600"
        self.timer = QtCore.QTimer()
        
        self.start_btn.clicked.connect(self.onStart)
        self.stop_btn.clicked.connect(self.onStop)
        self.clr_btn.clicked.connect(self.onClear)
        
    def createMainFrame(self):
        #LAYOUT CONTROL=======================================================
        grid = QtGui.QGridLayout()
        self.setLayout(grid)
        
        #START/STOP BUTTON
        self.start_btn = QtGui.QPushButton("START")
        self.stop_btn = QtGui.QPushButton("STOP")
        self.clr_btn = QtGui.QPushButton("CLEAR PLOT")
        
        #GRAPH
        self.graph = pg.PlotWidget(title="Serial Data Monitor")
        
        #INSERT WIDGETS INTO THE WINDOW
        grid.addWidget(self.start_btn,0,0,1,3)
        grid.addWidget(self.stop_btn,1,0,1,3)
        grid.addWidget(self.clr_btn,2,0,1,3)
        grid.addWidget(self.graph,3,0,1,3) 
        self.mainFrame = QtGui.QWidget()
        self.mainFrame.setLayout(grid)
        self.setCentralWidget(self.mainFrame)
        
        #self.graph.plotItem.plot([1,2,3,4,5],[10,20,30,40,-10])
        
    def onStart(self):
        print("starting")
        self.start_btn.setEnabled(False)
        self.stop_btn.setEnabled(True)
        #self.graph.clear()
        
        self.data_q = Queue.Queue()
        
        self.com_monitor =  ComMonitorThread(self.data_q,self.comPort,self.baudRate)
        self.com_monitor.start()        
        
        self.timer.timeout.connect(self.onTimer)
        self.timer.start(10) 
        
    def onStop(self):
        print("stopping")
        self.start_btn.setEnabled(True)
        self.stop_btn.setEnabled(False)
        
        self.timer.stop()
        self.com_monitor.join(0.01)
                
        
    def onTimer(self):
        #print("timer")
        self.read_serial_data()
        self.update_monitor()
        
    def onClear(self):
        self.graph.clear()
        
    def read_serial_data(self):
        #print("Reading Serial Data")
        #print("SIZE_BEFORE: ")
        #print(self.data_q.qsize())
        qdata = list(get_all_from_queue(self.data_q))
        #print("SIZE_AFTER: ")
        #print(self.data_q.qsize())
        
        if len(qdata) > 0:
            #print("FINAL")
            #data = dict(timestamp=qdata[-1][1], 
            #            value=qdata[-1][0])
            self.data = qdata
            self.livefeed.add_data(self.data)
            #print(self.livefeed.has_new_data)
            #print(qdata)
            
            
    def update_monitor(self):
        #print("Monitor:")
        if self.livefeed.has_new_data:
            #print("livefeed has DATA")
            self.ptimeV = self.timeV
            self.pvalue = self.value
            self.data = self.livefeed.read_data()
            #print("DATA: ")
            #print(float(self.data[0][1]))
            #print(float(self.data[0][0]))
            try:
                self.timeV = float(self.data[0][1])
                self.value = float(self.data[0][0])
            except ValueError:
                print("============NOT A FLOAT=============")
                self.timeV = 0
                self.value = 0
            self.graph.setXRange(self.timeV-5,self.timeV+5)
            self.graph.plotItem.plot([self.ptimeV,self.timeV],[self.pvalue,self.value])
            
        
#Define main() function
def main():
    #start QT application
    app = QtGui.QApplication(sys.argv)
    #construct an object from interface class
    dataMonitor = DataMonitor()
    dataMonitor.show()
    #exit system
    sys.exit(app.exec_())
    
#Call main function in __name__ == __main__
if __name__ == '__main__':
    main()