from PyQt4 import QtGui  # (the example applies equally well to PySide)
import pyqtgraph as pg
from pyqtgraph.Qt import QtCore

## Always start by initializing Qt (only once per application)
app = QtGui.QApplication([])

## Define a top-level widget to hold everything
w = QtGui.QWidget()

## Create some widgets to be placed inside
btn = QtGui.QPushButton('press me')
text = QtGui.QLineEdit('enter text')
listw = QtGui.QListWidget()
slider = QtGui.QSlider(QtCore.Qt.Horizontal)
plot = pg.PlotWidget()

## Create a grid layout to manage the widgets size and position
layout = QtGui.QGridLayout()
w.setLayout(layout)

## Add widgets to the layout in their proper positions
layout.addWidget(btn, 1, 2)   # button goes in upper-left
#layout.addWidget(text, 1, 0)   # text edit goes in middle-left
#layout.addWidget(slider, 0, 1)  # list widget goes in bottom-left
layout.addWidget(plot, 1, 2, 3, 1)  # plot goes on right side, spanning 3 rows

#slider.setGeometry(10, 10, 200, 30)
#slider.setFocusPolicy(QtCore.Qt.NoFocus)
slider.setRange(-50,50)

def getValue(value):
    print value
w.connect(slider, QtCore.SIGNAL('valueChanged(int)'), getValue)


## Display the widget as a new window
w.show()

## Start the Qt event loop
app.exec_()