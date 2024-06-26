import os

#from tensorflow.keras .... o .... from tensorflow.python.keras ...

from keras.src.legacy.preprocessing.image import ImageDataGenerator
  # preprocesamiento de imagenes
from keras import optimizers # algoritmos para entrenar
from keras.models import Sequential # para crear redes neuronales secuenciales
from keras.layers import Dropout, Flatten, Dense, Activation #
from keras.layers import Convolution2D, MaxPooling2D # capaz de la red neuronal
from keras import backend as K

K.clear_session()

data_entrenamiento = '../Unidad3/F1-Entrenamiento'
data_validacion = '../Unidad3/F2-Validacion'

#Parametros
epocas = 50
alto, largo = 224, 224 #dimensiones de las imagenes. Para redimenzionar
batch_size = 3 #numero de imagenes que se mandara a procesar por cada paso
pasos = 30
pasos_validacion = 10

kernel1 = (3, 3)
kernel2 = (2, 2)
kernel3 = (3, 3)

tot_kernels1 = 32
tot_kernels2 = 64
tot_kernels3 = 128

stride = (2, 2) #para MaxPooling

clases = 5 #total de clases a clasificar

lr = 0.00001 #learning rate

#To make sure that you have "at least steps_per_epoch * epochs batches", set the steps_per_epoch to
#steps_per_epoch = len(X_train)//batch_size
#validation_steps = len(X_test)//batch_size # if you have validation data
############

#preprocesamiento de imagenes  --> aumento de datos...

entrenamiento_datagen = ImageDataGenerator(
    rescale=1./224.0,# cada px va de 0 a 255, con esto se pasara al rango de 0 a 1, para procesar mas facil
    rotation_range=90,
    width_shift_range=0.7,
    height_shift_range=0.7,
    shear_range=0.3, #inclinacion
    zoom_range=0.5,
    vertical_flip=True,
    horizontal_flip=True, #inversion horizontal
    fill_mode='nearest'
)

prueba_datagen = ImageDataGenerator(
    rescale=1./224.0
)

imagen_entrenamiento = entrenamiento_datagen.flow_from_directory(
    data_entrenamiento,
    target_size=(alto, largo),
    batch_size=batch_size,
    class_mode='categorical'
)

imagen_prueba = prueba_datagen.flow_from_directory(
    data_validacion,
    target_size=(alto, largo),
    batch_size=batch_size,
    class_mode='categorical'
)

#red convolucional

cnn = Sequential()

##capa 1
cnn.add(Convolution2D(tot_kernels1, kernel1, padding='same', input_shape=(alto, largo, 3), activation='relu'))
cnn.add(MaxPooling2D(pool_size=stride))
##capa 2
cnn.add(Convolution2D(tot_kernels2, kernel2, padding='same', activation='relu'))
cnn.add(MaxPooling2D(pool_size=stride))
##capa 3
cnn.add(Convolution2D(tot_kernels3, kernel3, padding='same', activation='relu'))
cnn.add(MaxPooling2D(pool_size=stride))

cnn.add(Flatten()) # aplana la informacion
##capa 4
cnn.add(Dense(256, activation='relu')) #

cnn.add(Dropout(0.5)) #porcentaje de neuronas apagadas en cada paso (0.5 = 50%)
# permite aprender caminos alternos para clasificar.. evita sobreentrenamiento

#capa 5 - salida
cnn.add(Dense(clases, activation='softmax'))

cnn.compile(loss='categorical_crossentropy', optimizer=optimizers.Adam(learning_rate=lr), metrics=['accuracy'])
#cnn.compile(loss='binary_crossentropy', optimizer=optimizers.Adam(learning_rate=lr), metrics=['accuracy'])
#loss -> funcion de perdida

#entrena el modelo de la red neuronal
cnn.fit(imagen_entrenamiento, steps_per_epoch=pasos, epochs=epocas, validation_data=imagen_prueba, validation_steps=pasos_validacion)

dir = "modelo/"
if not os.path.exists(dir):
    os.mkdir(dir)
cnn.save(dir + 'modelo.h5') #estructura
cnn.save_weights(dir + 'pesos.weights.h5') #pesos en las capas

