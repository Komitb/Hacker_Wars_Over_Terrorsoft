README - Hack Wars
1. Información del Proyecto
Nombre del Proyecto: Snails
Equipo Creador: Iker Rubio, Elliot Palestina, Lucas Ruiz, Daniel Fachero - OverTerrorsoft
Fecha de Creación: 13/03/2025

IDEA: Juego tipo "Worms" (Juego de estrategia por turnos en el que tienes un numero limitado de moviminetos y armas que puedes usar para eliminar a los elemigos, se juega en local) en el que la mecánica principal seria que las armas se consiguen a través de una especie de "Slot" de casino de forma aleatoria.

2. Historial de Hackeos
Hack 1 - OverTerrorsoft 13/03/2025-20/03/2025

¿Qué hemos cambiado?

1. Hemos creado una mecánica de turnos en el que el jugador activo tiene 30s para hacer acciones, cuando pasa ese tiempo o se ejecuta una accion el turno cambia al siguiente jugador en orden. El jugador que tiene el primer turno se elige de forma aleatoria en el script de "RNG Controller", en ese script también esta el funcionamiento de los turnos (cambiar personaje activo y que la cámara siga al personaje activo). En estos juegos se suele tener un equipo entero (Ex. 4 PJ) por ahora cada equipo es de un jugador pero estaría bien si fuesen de mas de uno.

2. Hemos creado también un sistema de apuntado y disparo (que a su vez las balas que sueltan tienen físicas, también esta la posibilidad de cambiar a que las balas vayan rectas) al jugador similar a como funciona en el juego "Worms" es decir, al disparar te quedas quieto, a su vez si mantienes el botón de disparo cambia la velocidad de la bala, salen propulsados con mas potencia o con menos dependiendo de lo que mantengas el botón y por último que cada vez que dispares 2 veces cambie de turno.

3. Hemos creado un inventario (comunal por ahora), pero la idea es que cada equipo tenga un inventario independiente. También habría que añadir que cuando se seleccione un arma del inventario se use. Tiene 9 slots por lo que solo se pueden acumular 9 armas. Se activa con la "E". El arma se puede usar desde el principio y se debería usar cuando la tienes y se selecciona en el inventario.
	
4. Hemos creado un sistema de Spawn para los jugadores iniciales y que se spawneen entre los ejes x,y establecidos. También se ha creado el sistema de coins donde cada 30s te spawnea una moneda por el mapa aleatorio al igual que los jugadores (por ejex x,y) y si algún jugador colisiona con la coin se destruye y contea 1 punto al texto general.

¿Cómo lo hemos hecho?

 



¿Cómo lo hemos hecho?
(Explicación técnica de los cambios en código: qué scripts o escenas se han modificado, qué lógica se ha añadido o cambiado, etc.)

¿Qué problemas hemos encontrado?
(Opcional, pero útil: cualquier dificultad o bug que hayan encontrado, incluso si no lo han resuelto)

Notas para el siguiente equipo:
(Sugerencias, ideas o advertencias para el próximo equipo que reciba este proyecto)

3. Instrucciones de Uso
(Opcional, pero recomendable si el proyecto ya tiene varios cambios: explicaciones sobre cómo jugar, controles, requisitos técnicos, etc.)