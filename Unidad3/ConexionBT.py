import serial as con
import time

bt = con.Serial("COM6", timeout=1, baudrate=9600)

while True:
    time.sleep(1)
    bt.write("A".encode())



