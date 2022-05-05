# IAV22-DiegoCastilloSanchez

Trabajo final para la asignatura de IAV de la UCM.

## Propuesta
Mi propuesta es un simulador de un aquario, en el que se enfrentaran varias especies de peces, estos tendran un sistema de navegacion para navegar por el acuario y un sistema de eleccion de prioridades segun sus necesidades.

La practica incluira:

  - Sistema de navegacion 3D o 2D (depende de la complejidad) con deteccion de colisiones y detección de agentes aliados y contrarios.
  - Un arbol de comportamientos dirigido por necesidades que simulan las del anima; comer, espacio, satisfaccion, peligro, aparearse ... (prioridades facilmente modificable desde el juego).
  - Elementos en el mapa que satisfazcan esas necesidades, lugares de comida, areas poco ocupadas, puntos de apareamiento...


Posibles añadidos:

  - Un sistema de generación de mapas en el que se distrubuyan los elementos básicos del mapa, utilizando algún algoritmo como la función de colapsado y/o el mapa de ruido de Perlin.
  - Un mapa de inlfuencia que se sumaria arbol de comportamientos para definir las necesidades y prioridades de los agentes, como pueden ser el control de areas de recursos beneficiosos

Esta aplicación tomaria inspiracion de los simuladores como los *Sims* u otros simuladores de civilizaciones automaticas como *WorldBox* o *RimWorld*.
