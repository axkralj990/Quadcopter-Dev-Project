# -*- coding: utf-8 -*-
'''
Arduino serial plotting program - USER INTERFACE
By: Aleksij Kraljic
19/1/2016
This program is written to plot a multiple values sent from Arduino Uno to a PC
via serial protocol. The main purpose is to plot values from an MPU6050 IMU.
It is used to analyze motion sensing data in order to gain deeper understanding:
-raw values from the accelerometer and gyroscope
-data from DMP digital motion processor of the MPU6050
-filtered spacial orientation data
'''

#Import required libraries
import sys
from PyQt4 import QtGui, QtCore
import pyqtgraph as pg
import Queue
from globals import LiveDataFeed, get_all_from_queue
from comMonitor import ComMonitorThread

#Set up a class for drawing the user interface
class DataMonitor(QtGui.QMainWindow):
    #define the contstucotr method
    def __init__(self):
        super(DataMonitor,self).__init__()
        
        #call initUI method
        self.initUI()
        
        self.livefeed = LiveDataFeed()
        
        #declare data variables for plotting
        self.timeV=0
        self.value1=0
        self.value2=0
        self.value3=0
        self.samples = []  
        self.maxSamples = 550 #here was a ;
        
    #define initUI method
    def initUI(self):
        #initUI initializes the user interface
        
        self.createMainFrame()
        
        #declare variables for serial communication
        self.comPort = "COM4"
        self.baudRate = "9600"
        
        #initialize QTimer
        self.timer = QtCore.QTimer()
        
        #signals and slots for pushbuttons
        #self.start_btn.clicked.connect(self.onStart)
        #self.stop_btn.clicked.connect(self.onStop)
        #self.stop_btn.setEnabled(False)
        
    def createMainFrame(self):
        #createMainFrame creates the user interface layout
        #LAYOUT CONTROL=======================================================
        self.resize(840,840)
        self.setWindowTitle("Serial Monitor")        
        grid = QtGui.QGridLayout()
        self.setLayout(grid)
        
        #START/STOP BUTTON
        #self.start_btn = QtGui.QPushButton("Start")
        #self.stop_btn = QtGui.QPushButton("Stop")
        
        #GRAPH
        self.graph = pg.PlotWidget(title="Serial Data Plot")
        self.graph.setBackground('k')
        self.graph.plotItem.showGrid(1,1,1)
        self.curve1 = self.graph.plotItem.plot()
        self.curve1.setPen(color='g',width=2)
        self.curve2 = self.graph.plotItem.plot()
        self.curve2.setPen(color='c',width=2)
        self.curve3 = self.graph.plotItem.plot()
        self.curve3.setPen(color='y',width=2)
        
        #STATUS BAR
        self.status_text = QtGui.QLabel("Monitor Idle")
        self.statusBar().addWidget(self.status_text,1)
        self.status_text.setStyleSheet("QLabel {color: rgb(200,200,200); font-weight: bold;}")
        
        #INSERT WIDGETS INTO THE MAIN FRAME
        #grid.addWidget(self.start_btn,0,0,1,3)
        #grid.addWidget(self.stop_btn,1,0,1,3)
        grid.addWidget(self.graph,2,0,1,3) 
        self.mainFrame = QtGui.QWidget()
        self.mainFrame.setLayout(grid)
        self.setCentralWidget(self.mainFrame)
        
        #ADD MENU
        self.createToolbar()
        
        #STYLESHEET
        '''
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
        '''
        self.setStyleSheet("QMainWindow {background-color: rgb(60,60,70)}")
        self.setWindowIcon(QtGui.QIcon('SP_logo.png'))
            
    def createToolbar(self):
        #Create the toolbar first!
        toolbar = self.addToolBar('Config')
        
        self.startFeed = QtGui.QAction(QtGui.QIcon('START.png'), 'Start', self)
        self.startFeed.triggered.connect(self.onStart)
        
        self.stopFeed = QtGui.QAction(QtGui.QIcon('STOP.png'), 'Stop', self)
        self.stopFeed.triggered.connect(self.onStop)
        
        self.changeComPort = QtGui.QAction(QtGui.QIcon('COMPORT.png'), 'Set Com Port', self)
        self.changeComPort.triggered.connect(self.showPortDialog)
        
        self.changeBaud = QtGui.QAction(QtGui.QIcon('BAUDRATE.png'), 'Set Baud Rate', self)
        self.changeBaud.triggered.connect(self.showBaudDialog)
        
        toolbar.addAction(self.startFeed)
        toolbar.addAction(self.stopFeed)
        toolbar.addSeparator()
        toolbar.addAction(self.changeComPort)
        toolbar.addAction(self.changeBaud)
        toolbar.addSeparator()
        
        toolbar.setIconSize(QtCore.QSize(70,70))
        toolbar.setStyleSheet("QToolBar {background-color: rgb(60,60,70);}")
        toolbar.setMovable(False)
        
        self.stopFeed.setEnabled(False)
        
    def showPortDialog(self):
        text, ok = QtGui.QInputDialog.getText(self, 'Set COM Port', 'Enter COM port:')
        if ok:
            self.comPort = str(text) 
            
    def showBaudDialog(self):
        text, ok = QtGui.QInputDialog.getText(self, 'Set Baud Rate', 'Enter baud rate:')
        if ok:
            self.baudRate = str(text)
    
    def onStart(self):
        self.startFeed.setEnabled(False)
        self.stopFeed.setEnabled(True)
        
        #self.start_btn.setEnabled(False)
        #self.stop_btn.setEnabled(True)
        
        self.isReceiving = True        
        
        self.data_q = Queue.Queue()
        
        self.com_monitor =  ComMonitorThread(self.data_q,self.comPort,self.baudRate)
        self.com_monitor.start()
        
        self.timer.timeout.connect(self.onTimer)
        self.timer.start(10)
        
    def onStop(self):
        self.startFeed.setEnabled(True)
        self.stopFeed.setEnabled(False)
        
        self.status_text.setText("Monitor idle")
        #self.start_btn.setEnabled(True)
        #self.stop_btn.setEnabled(False)
        
        self.isReceiving = False
        
        self.timer.stop()
        self.com_monitor.join(0.01)
                
        
    def onTimer(self):
        self.read_serial_data()
        self.update_monitor()
        
    def read_serial_data(self):
        qdata = list(get_all_from_queue(self.data_q))
        
        if len(qdata) > 0:
            self.data = qdata
            self.livefeed.add_data(self.data)
            
            
    def update_monitor(self):
        if self.livefeed.has_new_data:
            self.data = self.livefeed.read_data()
            
            readings = self.data[0][0]
            readings = readings.split()
            readings_size = len(readings)
            
            try:
                self.timeV = float(self.data[0][1])
                if (readings_size==1):
                    self.value1=float(readings[0])
                elif (readings_size==2):
                    self.value1=float(readings[0])
                    self.value2=float(readings[1])
                elif (readings_size==3):
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
            
            if len(self.samples) > self.maxSamples:
                self.samples.pop(0)
                self.status_text.setText("Receiving data")
            
            tdata = [s[0] for s in self.samples]
            self.graph.setXRange(self.timeV-5,self.timeV)
            if (readings_size==1):
                sensorData1 = [s[1] for s in self.samples]
                self.curve1.setData(tdata,sensorData1)
            elif (readings_size==2):
                sensorData1 = [s[1] for s in self.samples]
                self.curve1.setData(tdata,sensorData1)
                sensorData2 = [s[2] for s in self.samples]    
                self.curve2.setData(tdata,sensorData2)
            elif (readings_size==3):
                sensorData1 = [s[1] for s in self.samples]
                self.curve1.setData(tdata,sensorData1)
                sensorData2 = [s[2] for s in self.samples]    
                self.curve2.setData(tdata,sensorData2)
                sensorData3 = [s[3] for s in self.samples]
                self.curve3.setData(tdata,sensorData3)
    '''
    def showDialog(self):
        CPR = QtGui.QDialog(self)
        CPR.setWindowTitle('Com Port Setting')
        
        CPR.resize(150,80)
        
        gridCP = QtGui.QGridLayout(CPR)
        okBtn = QtGui.QPushButton('OK')
        CP_label = QtGui.QLabel(CPR)
        CP_label.setText('Enter COM port:')
        CP_le = QtGui.QLineEdit(CPR)
        
        gridCP.addWidget(okBtn,2,0,1,2)
        gridCP.addWidget(CP_label,0,0,1,1)
        gridCP.addWidget(CP_le,1,0,1,2)
        
        #STYLESHEETS =========================================================
        CPR.setStyleSheet("QDialog {background-color: rgb(60,60,70)}")
        CP_label.setStyleSheet("QLabel {color: rgb(200,200,200);"
                                    "font-size: 20px;}")
        okBtn.setStyleSheet("QPushButton {background-color: rgb(170,170,180);"
                                    "border-radius: 4px;"
                                    "border-style: solid;"
                                    "border-color: black;"
                                    "border-width: 1px;"
                                    "font-size:20px;}")
        # ====================================================================
        CPR.exec_()
    '''

#define main() function
def main():
    #start the QT application
    app = QtGui.QApplication(sys.argv)
    #construct an object from interface class
    dataMonitor = DataMonitor()
    dataMonitor.show()
    #exit system
    sys.exit(app.exec_())

#call the main function
if __name__ == '__main__':
    main()