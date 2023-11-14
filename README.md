# ChatApp en C# con Conexiones TCP

## Proyecto final de la materia Programación Sobre Redes

Este proyecto es una aplicación de chat simple implementada en C# que utiliza conexiones TCP para permitir la comunicación en tiempo real entre un servidor y múltiples clientes. El sistema de chat incluye un servidor y una interfaz de cliente en Windows Forms. Los clientes pueden conectarse al servidor, enviar mensajes y recibir mensajes de otros clientes.

## Requisitos Implementados

El proyecto cumple con los siguientes requisitos:

1. Uso de Hilos: 
   - Utilizamos hilos para manejar las conexiones entrantes tanto en el servidor como en los clientes. Cada cliente se maneja en un hilo separado, lo que permite la comunicación simultánea entre múltiples usuarios.

2. Sistema Distribuido:
   - El sistema es distribuido, ya que consta de un servidor central que acepta conexiones de múltiples clientes. La comunicación se realiza a través de conexiones TCP, lo que permite a los clientes enviar y recibir mensajes en tiempo real.

3. Trabajo con Flujos de Redes:
   - El proyecto utiliza flujos de red (NetworkStream, StreamReader y StreamWriter) para la comunicación entre el servidor y los clientes. Esto permite la transmisión de mensajes a través de la red de manera eficiente.

4. Lectura y Escritura de Archivos:
   - Se implemento la funcionalidad de lectura y escritura de archivos para almacenar en un archivo de texto  ("chat_history.txt") para mantener un historial de las conversaciones en el servidor y cargar mensajes anteriores en los clientes.

5. Uso de métodos para Administrar Hilos:
   - Se utilizo el método de sicronización de hilos Semaphore para controlar conexiones simultáneas en el servidor, permitiendo hasta 3 conexiones activas al mismo tiempo.

6. Authenticacion:
   - Se utilizo el método de authenticación RBAC, con la implementación en construcción de los permisos. 

## Uso

1. Cloná o descargá el repositorio en tu máquina local.
2. Abrí la solución en Visual Studio.
3. Compila y ejecutá tanto el servidor como el cliente.
4. El servidor debe estar en ejecución antes de que los clientes se puedan conectar.
5. Ingresa un nombre de usuario en el cliente y presiona "Conectar" para unirte al chat.
6. Podes enviar mensajes al escribir en el cuadro de texto y presionar "Enviar".
