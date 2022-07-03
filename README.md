<img src="https://i.postimg.cc/mZKL9Q7T/1.png">

<img src="https://i.postimg.cc/13QyCsWT/2.png">

<img alt="Windows" src="https://img.shields.io/badge/-Windows-0078D6?style=flat&logo=windows&logoColor=white"/> <img alt="NET" src="https://img.shields.io/badge/-Visual%20Basic-blue?style=flat&logo=.net&logoColor=white"/>


EL PROBLEMA
------------------
Las tarjetas gráficas (GPUs) se calientan mucho al minar criptomonedas ya que funcionan al 100% de forma continuada. En verano es mucho peor ya que suben las temperaturas y es prácticamente imposible tener un RIG encendido sin poner el aire acondicionado o un ventilador al lado porque las GPUs se sobrecalientan en exceso, incluso haciendo undervolting y/o bajando el power limit.

He tratado de buscar algún software como CoreTemp (https://www.alcpu.com/CoreTemp/) que vigila las temperaturas de los núcleos de la CPU y, si estas aumentan en exceso, pone el sistema a hibernar automáticamente, pero no he encontrado nada parecido para las GPUs, así que he decidido programarlo yo mismo.


LA SOLUCIÓN - ¿QUÉ ES MINERBOOT?
--------------------------------
MinerBoot es un software que he programado en Visual Basic.NET para tener controladas las temperaturas de todas las GPUs de mi RIG de minado de criptomonedas y que también incluye un pequeño sistema de seguridad anti sobrecalentamiento.

**ATENCION:** MinerBoot no es un software de minado, es un launcher para tu minero favorito.


¿CÓMO FUNCIONA?
---------------
La idea es simple, MinerBoot crea una lista de todas las GPUs instaladas en el sistema y controla sus temperaturas. Si alguna GPU supera la temperatura límite que hemos configurado previamente, la aplicación se encargará de finalizar el proceso del minero, luego hará una pausa de 5 minutos para que las GPUs se enfíen y luego volverá a lanzar el proceso del minero.

* En las últimas versiones he incluido la opción de poner el sistema a hibernar en vez de pausar el minero durante unos minutos para que las GPUs se enfríen.

En la configuración de la aplicación podemos ajustar la temperatura límite para las GPUs, el ejecutable (.exe) del minero, la linea de comandos para lanzar el minero
y la forma de finalizar el proceso del minero (forzado o no), así como otras muchas opciones que se van ampliando con cada nueva versión del programa. 


¿EN QUE SE DIFERENCIAN LOS DOS MÉTODOS DE APAGADO DEL MIENRO?
-------------------------------------------------------------
- Normal  -> Process.CloseMainWindow(): El proceso se cierra igual que si apretas el botón X de la ventana.

- Forzado -> Process.Kill(): Es cómo apretar Ctrl+Alt+Supr y finalizar la tarea del minero en el task manager.

* Algunas veces me ha pasado que la ventana del minero se queda "colgada" y no se cierra correctamente con Process.CloseMainWindow() así que he decidido implementar el cierre forzado con Process.Kill(). Ambos métodos se pueden ajustar en la ventana de "Settings" (ajustes).


CÓDIGO DE TRECEROS
------------------
MinerBoot utiliza las librerías de Libre Hardware Monitor para leer las temperaturas y los nombres de las tarjetas gráficas.
https://github.com/LibreHardwareMonitor/LibreHardwareMonitor/releases

Para leer los valores guardados en el archivo de configuración .INI utiliza la clase INIReadWrite que encontré en StackOverflow.


¿CON QUE SOFTWARE DE MINADO ES COMPATIBLE?
------------------------------------------
MinerBoot funciona con cualquier software de minería por GPU que admita ejecutarse mediante línea de comandos, por ejemplo T-REX Miner, Phoenix Miner, etc...


¿CON QUE SISTEMAS OPERATIVOS ES COMPATIBLE?
------------------------------------------
MinerBoot es una aplicación para sistemas operativos Windows (7, VISTA, 8 y 10) y necesita permisos de administrador para poder leer las temperaturas de las GPUs correctamente.

**¡NO FUNCIONA EN MAC Y LINUX!**


¿POR QUÉ MINERBOOT PIDE PERMISOS DE ADMINISTRADOR?
--------------------------------------------------
Al ejecutar MinerBoot, el control de cuentas de usuario de Windows nos pedirá que proporcionemos permisos de administrador a la aplicación. MinerBoot no necesita permisos especiales para poder ejecutarse pero algunas de las librerías que usa si necesitan esos permisos para poder cumplir con su tarea. Estas librerías son:

- Libre Hardware Monitor

¿PARA QUÉ SIRVE EL WATCHDOG DE MINERBOOT Y CÓMO USARLO CORRECTAMENTE?
---------------------------------------------------------------------
Todo software de minado puede fallar y cerrarse por un error de Windows, de los drivers de la tarjeta gráfica o del propio programa. Para evitar esto, he incluido una rutina para comprobar cada 5 segundos que el programa de minado está funcionando. Si MinerBoot detecta que el programa de minado se ha cerrado, lo volverá a ejecutar.

Para usar esta opción te recomiendo que configures tu minero para que se cierre en caso de error fatal, así MinerBoot podrá detectar que el software de minado ha fallado.

**EJEMPLO:** El software de minado T-REX tiene algunos comandos para esto cómo:

**--exit-on-cuda-error**
**--exit-on-connection-lost**
**--exit-on-high-power**

Busca los comandos precisos para tu software de minado y agrégalos a la linea de comandos en las opciones de MinerBoot.

AGRADECIMIENTOS
---------------
Quiero hacer especial mención a un Youtuber que he tenido el placer de conocer y que le ha dedicado un video a una versión anterior de este software.
Podéis ver el video en el canal de Elbo desde este enlace: https://www.youtube.com/watch?v=IfHPQNG_aRI

SOPORTE TÉCNICO Y AYUDA
-----------------------
Si se te ocurre alguna mejora, te gustaría agregar alguna funcionalidad o has encontrado un error, ponte en contacto conmigo via emial en f.paez(at)hotmail(dot)es y lo hablamos.
