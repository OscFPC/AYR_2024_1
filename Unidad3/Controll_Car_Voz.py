import pygame
import speech_recognition as sr
import serial as s

Palabra=""
op=1
r = sr.Recognizer()
arduino=s.Serial("COM5",baudrate=9600,timeout=1)

while Palabra!="stop":
    print("Inicia:")
    try:
        while op==1:
            if Palabra!="robot":
                with sr.Microphone(device_index=0) as source:
                    #r.adjust_for_ambient_noise(source)
                    audio = r.listen(source)
                Palabra = r.recognize_google(audio, language="es-MX")
            elif Palabra=="robot":
                print("Hola\n\nInicia:")
                pygame.mixer.init()
                pygame.mixer.music.load("Voz.mp3")
                pygame.mixer.music.play(0)
                op=2

        with sr.Microphone(device_index=0) as source:
            #r.adjust_for_ambient_noise(source)
            audio = r.listen(source)
        Palabra = r.recognize_google(audio, language="es-MX")

        palabras_a_mantener = ["avanzar","retroceder","detener","izquierda","derecha"]
        palabras = Palabra.split()
        palabras_filtradas = [palabra for palabra in palabras if palabra in palabras_a_mantener]
        print(palabras_filtradas[0])

        if palabras_filtradas[0] == "avanzar":
            Letra="W"
        elif palabras_filtradas[0] == "retroceder":
            Letra="S"
        elif palabras_filtradas[0] == "izquierda":
            Letra="A"
        elif palabras_filtradas[0] == "derecha":
            Letra="D"
        elif palabras_filtradas[0] == "detener":
            Letra = "X"

        arduino.write(Letra.encode())
        print(Letra)
        Cadena = arduino.readline().decode().replace("\n", "").replace("\r", "")
        print(Cadena)
    except sr.UnknownValueError:
        print("Unknown Value Error")
    except sr.RequestError as e:
        print("Request Error: ".format(e))
    except Exception as ex:
        print("Error: ".format(ex))