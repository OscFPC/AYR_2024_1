import pygame
import speech_recognition as sr
import serial as s
import playsound

Palabra=""
op=1
r = sr.Recognizer()
arduino=s.Serial("COM3",baudrate=9600,timeout=1)

while Palabra!="detener":
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

        palabras_a_mantener = ["prende","apaga","cocina","sala","comedor","cuarto"]
        palabras = Palabra.split()
        palabras_filtradas = [palabra for palabra in palabras if palabra in palabras_a_mantener]
        cadena_modificada = ','.join(palabras_filtradas)
        print(palabras_filtradas[1])
        print(palabras_filtradas[0])

        if palabras_filtradas[1] == "cocina":
            if palabras_filtradas[0] == "prende":
                pygame.mixer.init()
                pygame.mixer.music.load("PrenderCocina.mp3")
                pygame.mixer.music.play(0)
            else:
                pygame.mixer.init()
                pygame.mixer.music.load("ApagarCocina.mp3")
                pygame.mixer.music.play(0)

        elif palabras_filtradas[1] == "sala":
            if palabras_filtradas[0] == "prende":
                pygame.mixer.init()
                pygame.mixer.music.load("PrenderSala.mp3")
                pygame.mixer.music.play(0)
            else:
                pygame.mixer.init()
                pygame.mixer.music.load("ApagarSala.mp3")
                pygame.mixer.music.play(0)

        elif palabras_filtradas[1] == "comedor":
            if palabras_filtradas[0] == "prende":
                pygame.mixer.init()
                pygame.mixer.music.load("PrenderComedor.mp3")
                pygame.mixer.music.play(0)
            else:
                pygame.mixer.init()
                pygame.mixer.music.load("ApagarComedor.mp3")
                pygame.mixer.music.play(0)

        elif palabras_filtradas[1]=="cuarto":
            if palabras_filtradas[0]=="prende":
                pygame.mixer.init()
                pygame.mixer.music.load("PrenderCuarto.mp3")
                pygame.mixer.music.play(0)
            else:
                pygame.mixer.init()
                pygame.mixer.music.load("ApagarCuarto.mp3")
                pygame.mixer.music.play(0)

        arduino.write(cadena_modificada.encode())
        Cadena = arduino.readline().decode().replace("\n", "").replace("\r", "")
        print(Cadena)
    except sr.UnknownValueError:
        print("Unknown Value Error")
    except sr.RequestError as e:
        print("Request Error: ".format(e))
    except Exception as ex:
        print("Error: ".format(ex))