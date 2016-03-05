# Quadcopter Project
Hello!

I am working on this project in order to familiarize myself with all the programming skills required to build an Arduino-controlled
quadcopter. I am starting with the very basics, so I can understand everything I make during the project.

<b>Serial Graphing Monitor</b> is used to visualize the data sent via serial communication. I use it to analize the data sent from the MPU6050 IMU connected to Arduino. Current code is written for Python 2.7. If you want to run it on Python 3 you need to change a couple of things (For example: -Py 2: from Queue import Queue -Py 3: from queue import queue).

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
Currentlly I am working on the branch Refining-the-code-1, where I added a toolbar from which the COM port and baudrate can be changed. Since I added the toolbar I'm experiencing some trouble while running the program with Spyder 2.3 where the kernel crashes from time to time. I will merge the branch with the master once I fix that problem. If you decide to use the program from the master branch, you need to set the COM port and baudrate manually inside DataMonitor.py code.

To run the program place the following files in the same folder:

<ul>
  <li>DataMonitor.py</li>
  <li>globals.py</li>
  <li>ComMonitor.py</li>
  <li>SP_logo.png</li>
  <li>COMPORT.png (refining-the-code-1 branch)</li>
  <li>BAUDRATE.png (refining-the-code-1 branch)</li>
</ul>

To start the program run DataMonitor.py.

There is still a lot to fix, add, and improve, so any suggestions and corrections are welcome!

Author: alex.kraljic@gmail.com

Code was inspired by <a href="https://github.com/mba7/SerialPort-RealTime-Data-Plotter"> MBA7's SerialPort-RealTime-Data-Plotter </a> and
<a href="http://eli.thegreenplace.net/2009/08/07/a-live-data-monitor-with-python-pyqt-and-pyserial/"> Eli Bendersky work</a>.
