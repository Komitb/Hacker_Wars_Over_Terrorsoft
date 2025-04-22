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

¿Qué problemas hemos encontrado?
Uno de los primero problemas que nos hemos encontrado es que detectaba la mancha pero al arrastrar no la borraba, luego conseguimos que la quitase pero quitaba la opacidad del tirón y no necesitabas casi esfuerzo para quitarla. Conseguimos finalmente que la opacidad bajara poco a poco pero no borraba otras manchas, lo conseguimos solucionar y ahora se borran todas las manchas.
En un principio para seleccionar la ventana y abrir el nivel es darle click a un cuadrado rojo que es un botón, esto en realidad debería ser que el personaje se mueva de arriba abajo, se coloque delante del cuadrado (ventana) y al darle a una tecla seleccione la ventana y se abra.

NOTAS

En cada piso se desarrolla una historia corta que luego podrías vender la información a un vecino cotilla que le interese, obteniendo tu algo a cambio a modo de premio (exp, contactos…)
Falta que detecte cuando la ventana está limpia y que salga para seleccionar otro nivel.


Hack #2 - Equipo "OverTerrorSoft"  - 19/03/2024 - 22/04/2025

¿Qué hemos cambiado?

Hemos cambiado la idea original del juego de limpiar cristales reutilizando el código original con la mecánica de limpiar para hacer un juego de Spider-Man al que de manera ingeniosa hemos llamado Snail-Man, en el que te balanceas por una ciudad rescatando civiles que están atrapados en sus apartamentos incendiados, reusando la mecánica de limpiar para apartar escombros y rescatar a la gente que está atrapada. Es un juego arcade, es decir cuando te quedes sin tiempo pierdes y tienes que rescatar a los máximos civiles posibles en ese periodo de tiempo. 

Con el click izquierdo disparas el gancho y te puedes agarrar a todas las superficies de color blanco.

Con A y D te mueves de izquierda a derecha.

Con Espacio saltas, a cuanto mas mantengas el Espacio saltara mas y si lo pulsas durante un momento saltara poco. 

Elliot:

Lucas: Establecí la generación de los civiles detrás de las manchas de la ventana. Aparece uno al azar entre 4 posiciones posibles y tienes que quitar la mancha entera para poder rescatar al civil. Ayudé a buscar una solución para los problemas que generaba el gancho al principio.

Dani: He creado el sistema de tiempo en el cual si tardas más de lo que nos da el juego en salvar a una persona te sale el losePanel, si salvas a la persona antes de que se acabe el tiempo se añadirán 15 segundos extras para poder dejarla en la base. También se creó un punto donde tiene que ir el jugador para salvar al civil con un onTriggerEnter y que salga la ventana donde habrá que salvar al civil, y también el punto de entrega que sería en la base. Además de que cuando se clique encima del civil al salvarlo en la ventana nos active el civil pegado al jugador para llevarlo a la base.

Iker: Corregi la ventana (ahora escombros) para que no fuese un “Soft-Lock”, cambie el gancho para que se pudiese lanzar en cualquier dirección y no solo a las plataformas seleccionadas, baje la distancia para que no fuese infinito, añadi un sistema de respawn, añadir un stat de Stamina para que a la hora de limpiar los escombros tuvieses que gestionar el recurso y no quedarte sin él, cree una partícula de fuego y he hecho que los civiles sean seleccionables al quitar los escombros y que se quite la ventana al seleccionarlo.

¿Qué problemas hemos encontrado?

Elliot: para hacer el movimineto de gancho 

Lucas: Establecer puntos de aparición fijos para los civiles. dentro del minijuego de la ventana.

Dani: No he encontrado ningún problema en lo que he trabajado, soy un fiera

Iker: Tuve problemas a la hora de hacer que el gancho no fuese solo a las plataformas “suelo” 



¿Cómo lo hemos hecho?

El proyecto original no tenía la cámara ni el movimineto proporcionado así que primero tuvimos que hacer un "remake" del proyecto de limpiacristales e integrarlo en el proyecto base.
