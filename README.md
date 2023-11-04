# chatApp en C# con Conexiones TCP

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

## Uso

1. Clona o descarga el repositorio en tu máquina local.
2. Abre la solución en Visual Studio.
3. Compila y ejecuta tanto el servidor como el cliente.
4. El servidor debe estar en ejecución antes de que los clientes se puedan conectar.
5. Ingresa un nombre de usuario en el cliente y presiona "Conectar" para unirte al chat.
6. Puedes enviar mensajes al escribir en el cuadro de texto y presionar "Enviar".
