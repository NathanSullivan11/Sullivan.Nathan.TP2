# Truco Argentino
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Sobre mí

Hola, mi nombre es Nathan, estudiante del segundo cuatrimestre en Técnico en Programación. Este proyecto fue uno de los que mas tiempo me llevo, no de escribir código, sino en diagramar y pensar como relacionar las distintas parte del programa. Fue desafiante desde el principio hasta el último commit. A pesar de esos momentos de sentirme como si no salieran las cosas, me llevo una gran y divertida experiencia. Creo que se hizo mas llevadero gracias a que el proyecto estaba orientado a desarrollar un juego, esó sirvió como motivación. Espero que les guste!

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Resumen

La aplicación consiste en un simulador del juego de cartas 'Truco', podremos tanto como simular partidas, en las que juegan 2 bots, como tambíen jugar una partida contra un bot. Contamos con la posibilidad de visualizar las estadísticas de las partidas, y de los jugadores. 

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Diagrama de clases


![Captura de pantalla (19)](https://user-images.githubusercontent.com/97369033/202081664-800cd227-6a04-40c6-9e13-2577dcea2ec5.png)

![Captura de pantalla (20)](https://user-images.githubusercontent.com/97369033/202081677-c0dde6e9-9260-447d-a17b-eaf6178ba37a.png)     
![Captura de pantalla (21)](https://user-images.githubusercontent.com/97369033/202081728-5c0cf389-9fae-49e9-9396-dbf9b204ed44.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## ¿Cómo usar la aplicación?
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
### Lobby principal
![image](https://user-images.githubusercontent.com/97369033/202146809-0ad2629b-85b3-4aa4-98ed-2cd163f1bd5c.png)

Tiene un sector donde se van a jugar todas las partidas simuladas, es decir, bot vs bot. Los puntaje de cada partida se actualizan en tiempo real.<br/>
![image](https://user-images.githubusercontent.com/97369033/202146994-f1d6da16-97ed-4b96-be75-8a0abc7a9808.png)

Si le damos al botón ver nos llevará a otro formulario donde podremos seguir el rastro de la partida, y tambíen pudiendo cancelar la misma.<br/>
![image](https://user-images.githubusercontent.com/97369033/202147451-84069dfe-0f3f-4a5b-be9c-67fe5cd7cf5f.png)

Al terminar o cancelar la partida, se habilitarán los botones para guardar el registro, contaremos con 3 opciones de guardado: en TXT, en JSON o en XML. Tambíen podremos cerrar la partida sin guardar.<br/>
![image](https://user-images.githubusercontent.com/97369033/202147461-218ba361-7520-4c15-9671-1f003ca6d483.png)


Luego, en el otro sector del lobby tendremos 3 botones<br/>
![image](https://user-images.githubusercontent.com/97369033/202147630-776e76e3-0d74-4f8b-95df-08a4ad178195.png)

###'Jugar contra un bot'

Este nos llevará a otro formulario donde podremos comenzar la partida para jugar contra un bot.<br/>
![image](https://user-images.githubusercontent.com/97369033/202147824-30a60798-2aaa-46af-8327-c7231be3a07b.png)

Al darle a comenzar, automaticamente se empezerán a repartir las cartas y a jugar la partida. Podremos cancelarla en todo momento.<br/>
![image](https://user-images.githubusercontent.com/97369033/202147913-b3534229-f5e3-4d1b-a2c7-11dbeeb181c4.png)

Al terminar o cancelar la partida, se habilitarán los botones para guardar el registro, contaremos con 2opciones de guardado: en JSON o en XML. Tambíen podremos cerrar la partida sin guardar.<br/>
![image](https://user-images.githubusercontent.com/97369033/202148286-db43a7ce-100f-4fde-ab84-9117679f7bdf.png)

### 'Estadísticas jugadores'<br/>
Se abrirá un data grid mostrandónos toda la información que haya en la base de datos de los jugadores.<br/>
![image](https://user-images.githubusercontent.com/97369033/202148635-84f294bf-ab21-445f-9582-503464165d62.png)

Podremos agregar un jugador como también borrar uno.<br/>
![image](https://user-images.githubusercontent.com/97369033/202148651-bab18c76-b3a8-44de-ab11-9b7a3f0ad312.png)

### 'Registro de las partidas'

Nos abrirá un formulario que nos permite mostrar los registros que esten serializados en XML o en JSON, y nos permite mostrar los registros de partidas bot vs bot y usuario vs bot<br/>
![image](https://user-images.githubusercontent.com/97369033/202149259-1aa2f5c3-d444-42c8-969d-33a213e0281d.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Justificación técnica

### SQL

La base de datos tiene una única tabla donde manejo los datos de los Jugadores. Al iniciar la aplicación se ejecuta una query 'SELECT' para cargar los Jugadores en memoria. Luego tendremos la posibilidad de ver a todos los Jugadores en un formulario, con la opción de 'Agregar' y 'Eliminar'. Los UPDATE se realizan cuando termina una partida, se actualizan los datos como, partidas jugadas, ganadas y perdidas.

![Captura de pantalla (30)](https://user-images.githubusercontent.com/97369033/202083825-61f3bc40-829d-437b-8fc8-8e81e73a943a.png)  ![Captura de pantalla (23)](https://user-images.githubusercontent.com/97369033/202083854-77676ca1-d6c1-45f9-91aa-fbf7768dd787.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Manejo de excepciones
Las excepciones las uso en las porciones de código donde mas riesgo tiene la aplicación, esto sería cuando; Abro una conexión con la base de datos; Lectura de archivos; Serialización y Deserialización de XML y JSON. Mas que nada en el código que depende de programas externos.

![Captura de pantalla (31)](https://user-images.githubusercontent.com/97369033/202084879-6c84deb7-764c-4d60-8145-8a14f9a0e072.png)
![Captura de pantalla (32)](https://user-images.githubusercontent.com/97369033/202084889-e007994c-ce9a-4e3d-8419-40308e969809.png)
![Captura de pantalla (33)](https://user-images.githubusercontent.com/97369033/202085086-e7c76cfa-3472-43d8-be95-3794c160fb2f.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Unit Testing
Intenté hacer unit testing de la mayoria de las funcionalidades, lamentablemente me quedaron algunas que no pasaron por el unit testing, pero fueron verificadas en un proyecto de consola que servia para hacer pruebas más rapidas, y mas debuggeables. De todas maneras, tengo el unit testing de unas 4/5 clases.

![Captura de pantalla (36)](https://user-images.githubusercontent.com/97369033/202085779-c72ab354-75b3-41ee-ab4d-6159cca52129.png)![Captura de pantalla (35)]

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Generics, Serialización e Interfaz
Estos 4 temas me pareció razonable utilizarlos juntos, ya que a lo largo de mi aplicación iba a necesitar serializar diferentes objetos, listas de objetos, etc. Entonces decidí hacer las serializaciones genéricas, y que implementen una interfaz. Pudiendo ser implementadapara la serializacion/deserializacion de archivos, tanto JSON como XML. 

![Captura de pantalla (37)](https://user-images.githubusercontent.com/97369033/202086739-51c2a654-55ac-4388-8dc1-d70ce1a9f42a.png)

![Captura de pantalla (38)](https://user-images.githubusercontent.com/97369033/202086750-dc59c2ae-3664-4c79-b864-9505ca07f5c6.png)

![image](https://user-images.githubusercontent.com/97369033/202091347-2f5001db-9695-470a-90c5-e3161014f079.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Escritura de archivos

Escribo archivos de diferentes tipos, XML JSON y TXT. El de texto lo utilizo para guardar el registro de las partidas en las que juegan bot vs bot. En el archivo quedaría algo como:  -J1: Tiro 5 de basto, -J2: Le gana con 1 de Oro, etc.
![image](https://user-images.githubusercontent.com/97369033/202087386-65e1367e-d651-46b0-97d6-f9ab8cf0166d.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Delegados

La aplicación de los delegados no me resultó muy útil, como si me resultaron los eventos. El único lugar donde pude aplicarlos fue al momento de que el bot elija que cartar tirar. En vez de llamar al método en cada if-else, le cambió el método que tiene asignado el delegado, y por último lo invoco.

![image](https://user-images.githubusercontent.com/97369033/202088563-d3bab62d-b0c8-4fd3-bfd9-aa6e1a306cd7.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Eventos

Los eventos me resolvieron un montón de cuestiones, las mas notorias, por ejemplo, son cuando tenia que mostrar gráficamente datos que perteneciían a las entidades. Entonces lo que hice fue declarar varios eventos en la clase Partida, cuyos eventos tenian varios métodos subscriptos, que respondían a sus necesidades.

![image](https://user-images.githubusercontent.com/97369033/202089187-53568979-16e6-4a7f-8996-ffa7514e7795.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Multihilo con Tasks

Las tareas asíncronas fueron un tema clave en este proyecto, me permiten correr varias salas a la vez, incluso pueden estar jugando varios bots entre ellos y por otro lado que el usuario este jugando tambíén, interactuando sin ninguna interrupción.
![Captura de pantalla (40)](https://user-images.githubusercontent.com/97369033/202090460-525efb12-23ef-4ad8-b72f-2049aa247fa8.png)
