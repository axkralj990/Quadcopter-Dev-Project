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
        
        self.timeV=0
        self.value1=0
        self.value2=0
        self.value3=0
        self.samples = []        
        
    #define initUI method
    def initUI(self):
        #SET GEOMETRY=========================================================
        self.resize(840,840)
        self.setWindowTitle("Arduino Serial Monitor")
        self.createMainFrame()
        
        self.comPort = "COM4"
        self.baudRate = "115200"
        self.timer = QtCore.QTimer()
        
        self.start_btn.clicked.connect(self.onStart)
        self.stop_btn.clicked.connect(self.onStop)
        self.stop_btn.setEnabled(False)
        
    def createMainFrame(self):
        #LAYOUT CONTROL=======================================================
        grid = QtGui.QGridLayout()
        self.setLayout(grid)
        
        #START/STOP BUTTON
        self.start_btn = QtGui.QPushButton("Start")
        self.stop_btn = QtGui.QPushButton("Stop")
        
        #GRAPH
        self.graph = pg.PlotWidget(title="Serial Data Plot")
        self.graph.setBackground('k')
        #pg.setConfigOptions(antialias=True)
        self.curve1 = self.graph.plotItem.plot()
        self.curve1.setPen(color='g',width=2)
        self.curve2 = self.graph.plotItem.plot()
        self.curve2.setPen(color='c',width=2)
        self.curve3 = self.graph.plotItem.plot()
        self.curve3.setPen(color='y',width=2)
        
        #STATUS BAR
        self.status_text = QtGui.QLabel("Monitor Idle")
        self.statusBar().addWidget(self.status_text,1)
        self.status_text.setStyleSheet("QLabel {color: rgb(0,255,0); font-weight: bold;}")
        
        #INSERT WIDGETS INTO THE WINDOW
        grid.addWidget(self.start_btn,0,0,1,3)
        grid.addWidget(self.stop_btn,1,0,1,3)
        grid.addWidget(self.graph,2,0,1,3) 
        self.mainFrame = QtGui.QWidget()
        self.mainFrame.setLayout(grid)
        self.setCentralWidget(self.mainFrame)
        
        #STYLESHEET
        self.start_btn.setStyleSheet("QPushButton {background-color: rgb(170,170,180);"
                                    "border-radius: 4px;"
                                    "border-style: solid;"
                                    "border-color: black;"
                                    "border-width: 1px;"
                                    "font-size:20px;}")
        self.stop_btn.setStyleSheet("QPushButton {background-color: rgb(170,170,180);"
                                    "border-radius: 4px;"
                                    "border-style: solid;"
                                    "border-color: black;"
                                    "border-width: 1px;"
                                    "font-size:20px;}")
        self.setStyleSheet("QMainWindow {background-color: rgb(60,60,70)}")
        self.setWindowIcon(QtGui.QIcon('SP_logo.png'))
        
    def onStart(self):
        print("starting")
        self.start_btn.setEnabled(False)
        self.stop_btn.setEnabled(True)
        
        self.data_q = Queue.Queue()
        
        self.com_monitor =  ComMonitorThread(self.data_q,self.comPort,self.baudRate)
        self.com_monitor.start()        
        
        self.timer.timeout.connect(self.onTimer)
        self.timer.start(10) 
        
    def onStop(self):
        self.status_text.setText("Monitor idle")
        self.start_btn.setEnabled(True)
        self.stop_btn.setEnabled(False)
        
        self.timer.stop()
        self.com_monitor.join(0.01)
                
        
    def onTimer(self):
        #print("timer")
        self.read_serial_data()
        self.update_monitor()
        
    def read_serial_data(self):
        qdata = list(get_all_from_queue(self.data_q))
        
        if len(qdata) > 0:
            self.data = qdata
            self.livefeed.add_data(self.data)
            
            
    def update_monitor(self):
        #print("Monitor:")
        if self.livefeed.has_new_data:
            self.data = self.livefeed.read_data()
            
            readings = self.data[0][0]
            readings = readings.split()
            readings_count = len(readings)
            
            try:
                self.timeV = float(self.data[0][1])
                if (readings_count==1):
                    self.value1=float(readings[0])
                elif (readings_count==2):
                    self.value1=float(readings[0])
                    self.value2=float(readings[1])
                elif (readings_count==3):
                    self.value1=float(readings[0])
                    self.value2=float(readings[1])
                    self.value3=float(readings[2])
                self.status_text.setText("Receiving data")
            except ValueError:
                self.status_text.setText("Waiting for the data")
                self.timeV = 0
                self.value1 = 0
                self.value2 = 0
                self.value3 = 0
            self.samples.append((self.timeV,self.value1,self.value2,self.value3))
            
            if len(self.samples) > 550:
                self.samples.pop(0)
                self.status_text.setText("Receiving data")
            
            tdata = [s[0] for s in self.samples]
            self.graph.setXRange(self.timeV-5,self.timeV)
            if (readings_count==1):
                sensorData1 = [s[1] for s in self.samples]
                self.curve1.setData(tdata,sensorData1)
            elif (readings_count==2):
                sensorData1 = [s[1] for s in self.samples]
                self.curve1.setData(tdata,sensorData1)
                sensorData2 = [s[2] for s in self.samples]    
                self.curve2.setData(tdata,sensorData2)
            elif (readings_count==3):
                sensorData1 = [s[1] for s in self.samples]
                self.curve1.setData(tdata,sensorData1)
                sensorData2 = [s[2] for s in self.samples]    
                self.curve2.setData(tdata,sensorData2)
                sensorData3 = [s[3] for s in self.samples]
                self.curve3.setData(tdata,sensorData3)
                    
                    
                
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