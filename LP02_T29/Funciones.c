#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define TABLE_SIZE 100

typedef struct {
    char *name;
    int value;
} Symbol;

Symbol idTable[TABLE_SIZE];
Symbol numTable[TABLE_SIZE];
int idCount = 0;
int numCount = 0;

/* Función para instalar un identificador en la tabla de símbolos */
int installID(char *name) {
    if (idCount >= TABLE_SIZE) {
        fprintf(stderr, "Tabla de símbolos llena\n");
        exit(1);
    }
    idTable[idCount].name = strdup(name);  // Duplica el nombre del identificador
    idTable[idCount].value = idCount;  // Asigna un valor único
    return idCount++;
}

/* Función para instalar un número en la tabla de símbolos */
int installNum(int value) {
    if (numCount >= TABLE_SIZE) {
        fprintf(stderr, "Tabla de símbolos llena\n");
        exit(1);
    }
    numTable[numCount].value = value;  // Almacena el valor numérico
    return numCount++;
}

int main() {
    /* Ejemplos básicos de prueba */
    printf("Ejemplo 1: Instalando identificadores y números\n");
    int id1 = installID("variable1");
    int id2 = installID("variable2");
    int num1 = installNum(10);
    int num2 = installNum(20);

    printf("ID1: %d, Nombre: %s\n", id1, idTable[id1].name);
    printf("ID2: %d, Nombre: %s\n", id2, idTable[id2].name);
    printf("NUM1: %d, Valor: %d\n", num1, numTable[num1].value);
    printf("NUM2: %d, Valor: %d\n", num2, numTable[num2].value);

    /* Ejemplo 2: Instalando identificadores y números adicionales */

    printf("Ejemplo 2: Instalando identificadores y números adicionales\n");

    int id3 = installID("loopVar");
    int num3 = installNum(30);

    printf("ID3: %d, Nombre: %s\n", id3, idTable[id3].name);
    printf("NUM3: %d, Valor: %d\n", num3, numTable[num3].value);


    printf("Ejemplo 3: Prueba de manejo de espacio en la tabla de símbolos\n");
    /* Ejemplo 3: Prueba de manejo de espacio en la tabla de símbolos */
    for (int i = 0; i < TABLE_SIZE; i++) {
        installID("tempID");
        installNum(100 + i);
    }

    return 0;
}
