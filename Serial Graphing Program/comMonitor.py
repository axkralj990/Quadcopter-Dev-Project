# -*- coding: utf-8 -*-
import threading, serial, Queue, time
from globals import LiveDataFeed, get_all_from_queue 
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
        
    def getData(self):
        print("getting data")
        
    def run(self):
        print("THREAD STARTED")
        startTime = time.time()
        
        qdata = 99999
        
        while self.alive.isSet():
            timeStamp = time.clock()
            self.data_q.put((qdata,timeStamp))
            time.sleep(0.05)
            
    def join(self,timeout=None):
        self.alive.clear()
        threading.Thread.join(self,timeout)
        