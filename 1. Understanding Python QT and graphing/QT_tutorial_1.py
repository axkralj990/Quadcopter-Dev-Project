# -*- coding: utf-8 -*-
#!/usr/bin/python
# -*- coding: utf-8 -*-

"""
ZetCode PyQt4 tutorial 

In this example, we create a simple
window in PyQt4.

author: Jan Bodnar
website: zetcode.com 
last edited: October 2011
"""

import sys
from PyQt4 import QtGui


def main():
    
    app = QtGui.QApplication(sys.argv) #create an application object

    w = QtGui.QWidget() #create a widget object with a default contructor.
    #Default constructor means it is a window
    w.resize(250, 150)
    w.move(300, 300)
    w.setWindowTitle('My first window: Aleksij Kraljic')
    w.show() #show a saved widget
    
    sys.exit(app.exec_()) #ensures a clean exit


if __name__ == '__main__':
    main() #call the main function