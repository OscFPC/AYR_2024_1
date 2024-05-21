from E2_FuncionesModularizarK import proceso

Kernels = {
    'Identity': [
        [0, 0, 0],
        [0, 1, 0],
        [0, 0, 0]
    ],
    'Ridge': [
        [0, -1, 0],
        [-1, 4, -1],
        [0, -1, 0]
    ],
    'Edge': [
        [-1, -1, -1],
        [-1, 8, -1],
        [-1, -1, -1]
    ],
    'Sharpen': [
        [0, -1, 0],
        [-1, 5, -1],
        [0, -1, 0]
    ],
    'BoxBlur': [
        [1, 1, 1],
        [1, 1, 1],
        [1, 1, 1]
    ],
    'GaussianBlur': [
        [1, 2, 1],
        [2, 4, 2],
        [1, 2, 1]
    ]
}

img=(input("Imagen--> "))

file = f'../Archivos/{img}'
largo=(int(input("largo--> ")))
alto=(int(input("alto--> ")))
nombre=input("Nombre del kernel--> ")

proceso(file,largo,alto,nombre,Kernels[nombre])