# Prueba Shooter Físicas
Este es un proyecto de prueba, en el cual se integran mecánicas de funcionamiento de armas, personajes animados y físicas con objetos.
## Contenido
El proyecto se compone de 2 escenas, la escena inicial donde básicamente sólo hay una UI para seleccionar la animación que el personaje tendrá y para comenzar el juego. La segunda tiene un Character Controller en primera persona, objetos con trigger para que el jugador pueda agarra una arma, un PoolManager para armas, balas y explosiones y unos cubos con físicas para probar los efectos de las diferentes armas. Los valores de las armas pueden ser modificados en tiempo real por medio de las instancias del ScriptableObject 'GunData' que se encuentran en "Assets/Scripts/ScriptableObjects". Se agregaron también animaciones para las armas y efectos las balas así como las explosiones, igualmente se intregró un Manager para el sonido y sonidos básicos, también un filtro básico de bloom para las escenas.
## Nota Importante
Todas las clases implementadas en el proyecto fueron creadas por mi excepto el plugin externo DoTween, los assets utilizados son gratis de la tienda de Unity.
