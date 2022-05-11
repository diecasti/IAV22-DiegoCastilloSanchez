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


# DOCUMENTACION

## Descripcion:

  La aplicacion es una simulación de familias de peces que viven en un acuario, su objetivo es reproducirse y conseguir todo el territorio del acuario o extinguir a la otra familia. Para ello llevaran a cabo las necesidades basicas de un animal, comer su dieta, moverse, conseguir territorio, atacar a la otra especie y reproducirse.
  Se podran modificar los parametros de las prioridades de los peces apra conseguir conductas distintas.

## Elementos del Acuario

El acuario se formara a traves de una malla que simula el sustrato marino con sus accidentes propios. El Mapa estara dividido en cubos que dividiran el mapa en elementos ams sencillos con los que trabajar (y generar el mapa), estos elementos son:

 - Algas: Aportan alimento del tipo vegetal a los peces con la dieta Hérbibora.
 - Placton: Aportan alimento del tipo proteina a los peces con la dieta Carnivora.
 - Rocas de deshove: Lugar al que acuden los peces para reproducirse, los alevines preferiran mantenerse cerca de estas zonas ya que son lugares seguros.
 - Zona abierta: Espacio abierto sin ningún elemento, los peces habitaran estas zonas para ganar territorio o las usaran de paso.


