#  Mar del Chat #

##  Integrantes Grupo 1 ##
- Lucas Varela
- Damián Bosatta
- Fabián Labrunée
- Nicolás Francolino
##  Introducción ##
Trabajo Final del Bootcamp Backend .NET / C# - DEV PLACE Tech Academy.
	Este proyecto se trata de un servicio de chat en tiempo real implementado con tecnología .Net contra SQL Server mediante API
	en el BackEnd consumidas por la interfaz de usuario ...en el FrontEnd. El mismo se centra en el diseño y desarrollo de un servidor
	que proporciona soporte mediante ¿endpoints?(para no repetir APIs) a una aplicación llamada ??, la cual permite la interacción
	entre distintos usuarios registrados que pueden interactuar con otros mediante salas de chat individuales o grupales.
	El usuario se debe registrar en el FrontEnd para comenzar a chatear con otro usuario mediante una sala individual o puede
	acceder a una sala grupal donde hay mas usuarios. Las salas no son persistentes, son destruidas al finalizar la sesión todos
	los usuarios que la integran.
- Persistencia de datos en cuanto a login y registro de usuarios
- Soporte multi clientes
- Detección de escritura en tiempo real
- Detección del ingreso y salida de cualquier usuario al chat
- Plataforma múltiple
	
##  Tecnologías y herramientas ##
Se extrajo Visual Studio Community 2022 como herramienta de programacion
###  Para el desarrollo de la parte Backend se utilizaron principalmente los siguientes lenguajes y tecnologías: ###
- C#  
- SQL Server  
- .NET Framework Core 6.0  

<p align="center">
  <img src="https://user-images.githubusercontent.com/91495463/176471635-f7b2ce83-58d5-4853-a7b4-43ebbca30228.png" alt="cross-platform-chat" width="600" />
</p>
<p align="center"> https://docs.microsoft.com/es-es/dotnet/architecture/microservices/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern#what-is-the-api-gateway-pattern </p>  

###  En el FrontEnd, se extrajo la herramienta de desarrollo SignalR junto con Blazor ###  
####  SignalR ####
SignalR es una librería o framework de desarrollo que permite conectar en nuestras aplicaciones, la capa de backend con el lado cliente, en ambas direcciones, y sobre todo en tiempo real sin necesidad de recargar pantalla.
Con SignalR podemos conectar a un servicio tanto clientes como digamos, pudiendo escalar el servicio bajo demanda.
Las conexiones al servicio se realizan con autenticación multifactor, gracias a la clave de acceso, que nos devuelve un token de sesión válido para que las aplicaciones de los clientes consuman el servicio.
Esta herramienta permite desarrollar una aplicación sobre una conexión virtualmente siempre abierta, creando la sensación de estar trabajando en una conexión continua. Del lado del servidor se puede detectar cuando se ha conectado o desconectado un nuevo cliente, se puede recibir mensajes de los mismos y enviar mensajes a los clientes conectados, en definitiva, todo lo necesario para poder crear aplicaciones asincronas multiusuario.  
<p align="centro">
  <img src="https://docs.microsoft.com/es-ES/azure/architecture/solution-ideas/media/cross-platform-chat.png" alt="cross-platform-chat" width="400 " />
</p>
<p align="center"> https://docs.microsoft.com/es-es/azure/architecture/solution-ideas/articles/cross-platform-chat </p>  

#####  Flujo de datos #####  
- La aplicación de chat web se conecta a SignalR Service y recibe un token.  
- El usuario inicia sesión en la aplicación con la autenticación multifactor; si la supera, se devuelven el punto de conexión de SignalR y el token de portador.  
- El usuario se conecta a SignalR Service con el punto de conexión y el token.  

<p align="centro">
  <img src="https://www.compartimoss.com/static/cf87d91c43f165c7e0cd338d055e275c/2bef9/image3.png" alt="signalr-service" width="650" />
</p>  
<p align="center"> https://www.compartimoss.com/revistas/numero-36/eventos-real-time-con-azure-signalr-en-asp-net-core/ </p>  

####  Blazor ####
Es un proyecto desarrollado por Microsoft creado para permitir crear [ SPAs ](https://docs.microsoft.com/en-us/aspnet/single-page-application/overview) usando únicamente como lenguajes de programación C# y Razor Pages, haciendo nula la necesidad de programar en Javascript o frameworks derivados.
Su principal fuerte es la interacción en tiempo real entre cliente y servidor a través de SignalR.
El modelo de hospedaje de Blazor Server ofrece las siguientes ventajas:

- El tamaño de la descarga es mucho menor que una aplicación del lado cliente y la aplicación se carga mucho más rápido.
- La aplicación aprovecha al máximo las funciones del servidor, incluido el uso de las API compatibles con .NET.
- En el servidor, .NET se usa para ejecutar la aplicación, por lo que las herramientas de .NET existentes, como la depuración, funcionan según lo previsto.
- Se presentó clientes ligeros. Por ejemplo, las aplicaciones del lado servidor funcionan con exploradores que no eliminaron WebAssembly y en dispositivos con restricción de recursos.
- La base del código de la aplicación .NET/C#, incluido el código de componente de la aplicación, no se sirve a los clientes.  
<p align="centro">
  <img src="https://docs.microsoft.com/es-es/dotnet/architecture/blazor-for-web-forms-developers/media/hosting-models/blazor-server.png" alt="blazor- servidor" ancho="450" ​​/>
</p>  
<p align="center"> https://docs.microsoft.com/es-es/dotnet/architecture/blazor-for-web-forms-developers/hosting-models </p>  

##  Implementación ##
El proyecto está desarrollado usando la metodología de Arquitectura de N-Capas la cual se presta a reutilización de código por parte de distintas capas de presentación.
<p align="centro">
  <img src="https://docs.microsoft.com/es-es/dotnet/architecture/cloud-native/media/direct-client-to-service-communication.png" alt="direct-client-to- servicio-comunicación" width="500" />
</p>  
<p align="center"> https://docs.microsoft.com/es-es/dotnet/architecture/cloud-native/front-end-communication </p>  

##  Estructura del sistema Backend ##
```
├───API_CoreNegocio  
│ ├───Autenticación  
│ │ ├───Solicitud  
│ │ └───Respuesta  
│ ├───Entidades  
├───API_DataCore  
│ ├───Interfaces de complementos  
│ └───Repositorio  
├───API_GenericCore  
│ ├───Repositorio genérico  
│ │ └───Interfaces  
├───API_LoggerCore  
│ ├───Registrador personalizado  
│ ├───Middleware  
│ └───Propiedades  
├───API_UsesCasos  
│ ├───Servicios  
│ └───UnidadDeTrabajo  
└───MarDelChat  
    ├───Controladores  
    ├───Migraciones  
    └───Propiedades  
```
##  Requisitos ##
-Net Framework Core 6

##  Diagrama de clases ##
![ ClassDiagram1 ](https://user-images.githubusercontent.com/91495463/176903373-1d8bcbc8-2e5c-4af8-8e91-471e0ec832d5.jpg)

## Diagrama Entidad-Relación ##
![ imagen ](https://user-images.githubusercontent.com/91495463/176903469-e15ac123-08a6-448e-8cd0-52d5589dd0ce.png)

##  Glosario ##
- Back-end: La parte de una aplicación que almacena y manipula datos.
- Front-end: Es una interfaz a través de cual los usuarios comunes pueden acceder a un programa.
- Arquitectura de Capas: es la organización donde los componentes funcionales están separados jerárquicamente por capas. Cada capa solo está conectada con su superior y su inferior mediante interfaces.
- Framework: es una plataforma para el desarrollo de aplicaciones de software. Proporciona una base sobre la cual los desarrolladores de software pueden construir programas para una plataforma específica.
- API: se refiere a la Interfaz de Programación de Aplicaciones. Es la plataforma que utiliza un programa para acceder a diferentes servicios en el sistema informático.
