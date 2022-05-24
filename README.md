# IAV22-DiegoCastilloSanchez

Trabajo final para la asignatura de IAV de la UCM.
## [video](https://youtu.be/_sS1c6mQimE)
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

## El agente Pez

La entidad principal de la aplicación, se distinguiran por tipo de familia (color) y tendran 4 estados; (huevo, alevin, joven, adulto)

### Comportamientos:

#### Comportamientos:
  - Comer: Busca alimento según su dieta y la situación.
  - Huir: Huye buscando cobijo en otros aliados.
  - Atacar: Ataca a un pez de otra famila, para hacerle daño, defender los alevines o comerselo.
  - Reproducirse: Busca una pareja en una zona de deshove y hacen una puesta.

#### Necesidades:
  - Hambre
  - Espacio
  - Peligro
  - Extres

Segun estas necesidades y los requisitos minimos de estas, los distintos comportamientos adquiriran una prioridad distinta que el agente tendra en cuenta a la hora de realizar sus acciones.

## Psudocodigo

### Arbol de decisiones

un arbol de decisiones mediante tareas y prioridades, las prioridades se definen en el apartado de necesidades mediante porcentajes, siendo aquellas con un numero mayor las mas importantes

``` mermaid
  graph TD;
  Entry-->Repeat;
  Repeat-->Priority_Selector;
  Priority_Selector-->Task_Comer;
  Priority_Selector-->Task_Huir;
  Priority_Selector-->Task_Atacar;
  Priority_Selector-->Task_Deshovar;
```

#### Task_Comer

Su prioridad se rige, por el nivel de insatisfaccióin por debajo del minimo establecido en su necesidad de Hambre

```
//elige el elemento de comida mas cercano, y activa el comportamiento deseguimiento hacia este.

foreach comida in alimentos {

 //mide la distancia para elegir el mas cercano
 distancia = getDistancia(comida);
 
 if (distancia < distaciaObjetivo){
 
    objetivo = comida;
    distanciaObjetivo = distacia;  
 }
 
}

//activa el seguimiento a la comida con el nuevo objetivo

Seguimiento.Enable = true;
Seguimiento.Objetivo = Objetivo;


//devolvera succes cuando satisfaga su necesidad de alimento
if (satisfecho)
  return succes;
//mientras devolvera running y aumentara el nivel de estrex del animal

estrex++;
return running;
```


#### Task_Huir

Su nivel de prioridad se rige por el nivel de amenaza (proximidad a enemigos) por encima del minimo establecido

```
//activa el comportamiento de huida

Huir.Enable = true;

//devolvera succes cuando se sienta seguro, este alejado de sus enemigos, mientras este comportamiento este activo ganara estres
if (seguro?)
  return succes;
//mientras devolvera running

estrex++;
return running;
```
#### Task_Atacar

Su nivel de Prioridad se rige por el nivel de extres acumulado por encima del minimo establecido, cuando hay mucho estrex, el animal preferira atacar a huir antes de realizar otra acción.

```
//activa el comportamiento de Atacar

Atacar.Enable = true;

//devolvera succes cuando golpe a sus enemigos, coma, o su nivel de extres haya bajado
if (Extresado)
  return succes;
//mientras devolvera running
return running;
```

#### Task_Deshovar

Su nivel de prioridad se rige una vez haya satisfecho su necesidad de Comer y se sienta seguro y no Estresado, en un escala de 100.

```
//El agente se dirigira a una zona de deshove a multiplicarse
//activa el seguimiento a una de estas zonas (la mas cercana)

Seguir.Enable = true;
Seguir.Objetivo = GetZOnaDeshoveCercana();

//returneara succes una vez haya hehco al puesta si no contianura con el proceso.

if (deshovado)
  return succes;
else
  return running;


```


### Sistema de Navegación

El agente solamente se movera hacia adelante, puede sin embargo variar su rotación para orientarse hacia sus objetivos.

#### Detección de Aliados

detecta a sus aliados cercanos para intentar nadar en proximidad de ellos y mantenerse a una distancia que no les impida el movimiento

##### Flotching
```
//recorre todos sus aliados cercanos y elige un punto medio entre ellos al que dirigirse
foreach aliado in aliados
{
  posicion_objetivo = aliado.position + (posicion_objetivo - aliado.position) / 2; //posicion intermedia entre esos dos puntos.
}

//rotar al agente suavemente hacia el objetivo

trasnform.rotation.lookat(Time.DeltaTime * velocidad rotacion)

```

##### Dispersion
```
//recorre todos sus aliados  demasiado cercanos y elige un punto entre ellos al que alejarse
foreach aliado in aliados
{
  posicion_objetivo = aliado.position + (posicion_objetivo + aliado.position) / 2; //posicion intermedia alejada entre esos dos puntos.
}

//rotar al agente suavemente hacia el objetivo

trasnform.rotation.lookat(Time.DeltaTime * velocidad rotacion)

```

#### Huir

```
//recorre todos sus enemigos cercanos y elige un punto medio entre ellos al que huir
foreach enemigo in enemigos
{
  posicion_objetivo += transform.position - enemigo.position; //posicion a al que huir
}

//rotar al agente suavemente hacia el objetivo

trasnform.rotation.lookat(Time.DeltaTime * velocidad rotacion)

```

#### Perseguir

```
//se dirige en direccion al objetivo

direccion = transform.position - target.position;
direccion.normalize;

//rotar al agente suavemente hacia el objetivo

trasnform.rotation.lookat(Time.DeltaTime * velocidad rotacion)
```

#### Atacar y Comer

```
//el agente tiene una boca, que cuando entra en contaco con otro elemento realizara una acción dependiendo de la situación

//si es comida
//eliminara el elemento, y satisfacera su necesidad de comer

if (food){

  getComponent<necesidades>().addfood(elemento.comidaValue);

  elemento.destroy;
}
else if (enemigo){
//si es un enemigo

//le restara salud al enemigo y lo empujara para conseguir el espacio que perdio

enemigo.getComponent<Salud>().restar(daño);

enemigo.rigidbody.addforce(transofmr.forward * empuje);

}
```
