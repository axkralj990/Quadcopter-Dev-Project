# Quadcopter Project
Hello!

I started this project in order to familiarize myself with all the programming skills required to build an Arduino-controlled
quadcopter. I am starting with the very basics, so I can understand everything I make during the project.

<b>1. Serial Graphing Monitor</b> is used to visualize the data sent via serial communication. I use it to analize the data sent from the MPU6050 IMU connected to Arduino. Current code is written for Python 2.7. If you want to run it on Python 3 you need to change a couple of things (For example: -Py 2: from Queue import Queue -Py 3: from queue import queue).

<div align="center">
<img src="Monitor.jpg" height="500">
</div>

In order to run the code you need to install the following libraries:
<ul>
  <li>PyQtGraph</li>
  <li>PyQt 4.8+ or PySide</li>
  <li>NumPy</li>
  <li>PySerial</li>
</ul>

Place the following files in a folder:

<ul>
  <li>DataMonitor.py</li>
  <li>globals.py</li>
  <li>ComMonitor.py</li>
  <li>SP_logo.png</li>
  <li>COMPORT.png</li>
  <li>BAUDRATE.png</li>
</ul>

To start the program run DataMonitor.py.

The program is written to receive maximum three separate values at a time from serial. For now it is programed so all three values need to be packed in a single line, for example, if you want to plot readings from all X, Y, and Z accelerometer axis you should write them to serial like this "AccX AccY AccZ\n". If only one or two values are written to serial, then only one or two data sets will be plotted.

There is still a lot to fix, add, and improve, so any suggestions and corrections are welcome!

Author: alex.kraljic@gmail.com

Code was inspired by <a href="https://github.com/mba7/SerialPort-RealTime-Data-Plotter"> MBA7's SerialPort-RealTime-Data-Plotter </a> and
<a href="http://eli.thegreenplace.net/2009/08/07/a-live-data-monitor-with-python-pyqt-and-pyserial/"> Eli Bendersky work</a>.
