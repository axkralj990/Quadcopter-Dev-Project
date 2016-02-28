# -*- coding: utf-8 -*-
import threading, serial, time 
class ComMonitorThread(threading.Thread):
    def __init__(   self, 
                    data_q, 
                    port_num,
                    port_baud,
                    port_stopbits = serial.STOPBITS_ONE,
                    port_parity   = serial.PARITY_NONE,
                    port_timeout  = 0.01):
                        
        threading.Thread.__init__(self)
        
        self.serial_port = None
        self.serial_arg  = dict( port      = port_num,
                                 baudrate  = port_baud,
                                 stopbits  = port_stopbits,
                                 parity    = port_parity,
                                 timeout   = port_timeout)

        self.data_q = data_q
        
        self.alive = threading.Event()
        self.alive.set()
        
    def run(self):
        try:
            if self.serial_port:
                self.serial_port.close()
            self.serial_port = serial.Serial(**self.serial_arg)
        except serial.SerialException, e:
            print(e.message)
            return
        
        startTime = time.time()
        
        while self.alive.isSet():
            Line = self.serial_port.readline()
            timeStamp = time.time()-startTime
            self.data_q.put((Line,timeStamp))
            
        if self.serial_port:
            self.serial_port.close()
            
    def join(self,timeout=None):
        self.alive.clear()
        self.serial_port.close()
        threading.Thread.join(self,timeout)
        