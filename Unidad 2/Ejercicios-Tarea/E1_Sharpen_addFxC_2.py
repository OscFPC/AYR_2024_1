import csv

from keras.utils import load_img, img_to_array, array_to_img, save_img
import matplotlib.pyplot as plt

largo, alto = 500,500
F=largo+2
C=alto+2
file = '../Archivos/moon.png'
img_original = load_img(file, target_size = (largo, alto),color_mode = "grayscale")
img_a_convolucinar = img_to_array(img_original)  #filas, columnas, canales de colores

#SHARPEN
kernel = [
    [0, -1, 0],
    [-1, 5, -1],
    [0, -1, 0]
]

Nuevo = [[0 for j in range(alto+2)] for i in range(largo+2)]

for i in range(1,alto+1):
    Nuevo[0][i-1]=0
    Nuevo[i-1][0]=0
    Nuevo[largo+1][i-1]=0
    Nuevo[i-1][alto+1]=0
    for j in range(1,largo+1):
        Nuevo[i][j]=img_a_convolucinar[i-1][j-1]

print(len(Nuevo),",",len(Nuevo[0]))

img_convolucionada = [] #nueva imagen

for filas in range(1,F-1): #ignora los pixeles de la primera y ultima fila
    new_fila = []
    for columnas in range(1,C-1): #ignora los pixeles de la primera y ultima columna

        pixelConvulucionado = 0
        for f_kernel in range(len(kernel)): # 0 1 2
            for c_kernel in range(len(kernel)): # 0 1 2
                pixelConvulucionado += (kernel[f_kernel][c_kernel]
                                        * Nuevo[filas + (f_kernel-1)][columnas+(c_kernel-1)])

        pixelConvulucionado = pixelConvulucionado * (1/9)
        new_fila.append(pixelConvulucionado)

    img_convolucionada.append(new_fila)

img = array_to_img(img_convolucionada)
print(img.size)


#img.show()

##plot - 2 imagenes
plt.figure(figsize=(15,5))

plt.subplot(1,2,1)
plt.xticks([])
plt.yticks([])
plt.imshow(img_original, cmap='gray')

plt.subplot(1,2,2)
plt.xticks([])
plt.yticks([])
plt.imshow(img, cmap='gray')

plt.show()