README - Hack Wars
1. Información del Proyecto
Nombre del Proyecto: Limpia cristales
Equipo Creador: Laura, Raúl, Miguel e Iguacel.
Fecha de Creación: 06/03/2025

2. Historial de Hackeos
Hack #1 - Equipo "Mega Perverso Ltd." - 6/03/2025
¿Qué hemos creado?
Hemos creado un juego sobre cómo una persona tiene que limpiar los diferentes cristales de un edificio. El objetivo del juego es limpiar los cristales para ver las diferentes situaciones que están ocurriendo en los pisos.
Las mecánicas base son moverte de izquierda a derecha, limpiar los cristales con click y arrastrar, moverte de arriba abajo solo en la selección de nivel (el edificio) y sistema de puntos de experiencia.
En cada nivel la dificultad irá aumentando y habrá manchas que tengas que usar otra herramienta para quitarlas o que te vayan ensuciando la ventana conforme la vas limpiando, es decir, te da pie a que utilices más herramientas de tu equipo y tengas que ir mejorándolas a medida que vas subiendo de nivel.

¿Cómo lo hemos hecho?
Los movimientos de izquierda a derecha y de arriba a abajo los hemos hecho con el eje horizontal y vertical. La mecánica de limpiar los cristales ha sido un poco más complicada ya que teníamos que saber cuál era la posición del ratón y si el ratón estaba en la mancha (pis o suciedad) y mantienes y arrastras la opacidad de la mancha en la que estás bajará hasta que no se vea y entonces se desactiva. Cuando terminas de limpiar esa mancha se reinicia la opacidad para que puedas limpiar el resto de manchas, ya que son todas prefabs.
El sistema de puntos no lo conseguimos hacer pero funcionaría de tal manera que cuando termines de limpiar la ventana te den tantos puntos de experiencia y con esos puntos de experiencia puedas mejorar tu equipo para limpiar más rápido o limpiar determinadas manchas.

¿Qué problemas hemos encontrado?
Uno de los primero problemas que nos hemos encontrado es que detectaba la mancha pero al arrastrar no la borraba, luego conseguimos que la quitase pero quitaba la opacidad del tirón y no necesitabas casi esfuerzo para quitarla. Conseguimos finalmente que la opacidad bajara poco a poco pero no borraba otras manchas, lo conseguimos solucionar y ahora se borran todas las manchas.
En un principio para seleccionar la ventana y abrir el nivel es darle click a un cuadrado rojo que es un botón, esto en realidad debería ser que el personaje se mueva de arriba abajo, se coloque delante del cuadrado (ventana) y al darle a una tecla seleccione la ventana y se abra.

NOTAS

En cada piso se desarrolla una historia corta que luego podrías vender la información a un vecino cotilla que le interese, obteniendo tu algo a cambio a modo de premio (exp, contactos…)
Falta que detecte cuando la ventana está limpia y que salga para seleccionar otro nivel.


Hack #2 - Equipo "OverTerrorSoft"  - 19/03/2024

¿Qué hemos cambiado?

Hemos cambiado la idea original del juego de limpiar cristales reutilizando el codigo original con la mecánica de limpiar para hacer un juego de Spider-Man al que de manera ingeniosa hemos llamado Snail-Man, en el que te balanceas por una ciudad rescatando civiles que estan atrapados en sus apartamentos incendiados, reusando la mecanica de limpiar para apartar escombros y rescatar a la gente que está atrapada. Es un juego arcade, es decir cuando te quedes sin tiempo pierdes y tienes que rescatar a los máximos civiles posibles en ese periodo de tiempo. 

Con el click izquierdo disparas el gancho y te puedes agarrar a todas las superficies de color blanco.

Con A y D te mueves de izquierda a derecha.

Con Espacio saltas, a cuanto mas mantengas el Espacio saltara mas y si lo pulsas durante un momento saltara poco. 

¿Cómo lo hemos hecho?

El proyecto original no tenia la camara ni el movimineto proporcionado asi que primero tuvimos que hacer un "remake" del proyecto de limpiacristales e integrarlo en el proyecto base.

Elliot: para hacer el movimineto de gancho 

¿Qué problemas hemos encontrado?

Elliot: al c
