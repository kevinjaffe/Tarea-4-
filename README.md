
# Tarea 4 — Login con verificación de email usando SignalR

Aplicación ASP.NET Core (Razor Pages) que implementa un login con verificación de email: cuando el usuario "verifica" su correo, la página de login **se redirige automáticamente** a la página principal, sin que el usuario deba volver a ingresar sus credenciales.

Esta redirección automática se logra porque la página de login recibe un **evento del servidor** a través de una conexión **SignalR** (comunicación bidireccional cliente/servidor).

## Flujo de la solución


 el navegador le avisa al servidor que alguien quiere loguearse, y el servidor le avisa a *ese mismo navegador* (y solo a él) cuando el email fue verificado. Al recibir el aviso, la página se redirige sola.

## Cómo ejecutarlo

1. Abrir la solución en Visual Studio.
2. Correr con F5 (perfil `https`).
3. Se abre `https://localhost:7232/` con la página de login.
4. Ingresar cualquier email/contraseña y tocar **Login**.
5. En la ventana **Output** de Visual Studio aparece la URL completa de verificación (por ejemplo `https://localhost:7232/verificar/usuario/xxxx`).
6. Abrir esa URL en **otra pestaña** del navegador (simula el click en el enlace del mail).
7. La pestaña original del login **se redirige sola** a `https://localhost:7232/PaginaBienvenida`.

> En la consola aparece el log `Se notificara al cliente con id {id}` cuando la URL de verificación es accedida, confirmando que el servidor envió el evento.

## Diagrama de secuencia 

<img width="1411" height="656" alt="image" src="https://github.com/user-attachments/assets/b85d3ccb-908a-4029-9cfe-a60aaafb3080" />
