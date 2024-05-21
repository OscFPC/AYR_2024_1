import serial as con
import keyboard

bt = con.Serial("COM6", timeout=1, baudrate=9600)

# CODIGO  PARA CONTROLAR CON TECLADO

while True:
    if keyboard.is_pressed("w"):
        bt.write("W".encode())
    elif keyboard.is_pressed("a"):
        bt.write("A".encode())
    elif keyboard.is_pressed("s"):
        bt.write("S".encode())
    elif keyboard.is_pressed("d"):
        bt.write("D".encode())
    elif keyboard.is_pressed("x"):
        bt.write("X".encode())


# CODIGO PARA EL PROYECTO CON TCRT5000
