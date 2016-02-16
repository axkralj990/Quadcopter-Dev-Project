# -*- coding: utf-8 -*-
import Queue

class LiveDataFeed(object):
    """ A simple "live data feed" abstraction that allows a reader 
        to read the most recent data and find out whether it was 
        updated since the last read. 
        
        Interface to data writer:
        
        add_data(data):
            Add new data to the feed.
        
        Interface to reader:
        
        read_data():
            Returns the most recent data.
            
        has_new_data:
            A boolean attribute telling the reader whether the
            data was updated since the last read.    
    """
    def __init__(self):
        self.cur_data = None
        self.has_new_data = False
        #print("LIVE DATA FEED CONSTRUCTED")
    
    def add_data(self, data):
        self.cur_data = data
        self.has_new_data = True
        #print("DATA ADDED")
    
    def read_data(self):
        self.has_new_data = False
        return self.cur_data
        #print("DATA READ")
        
def get_all_from_queue(Q):
    """ Generator to yield one after the others all items 
        currently in the queue Q, without any waiting.
    """
    try:
        while True:
            yield Q.get_nowait()
    except Queue.Empty:
        raise StopIteration
    
