# svchostviewer
Svchost Viewer is a Windows program that has been designed to reveal the services behind specific svchost.exe processes on machines running Windows.

The software program of choice to analyze processes is Process Explorer from Sysinternals (usually), and while it is the go-to program for many, its feature richness and functionality can be quite intimidating at first.

Yes, there are other applications that do the same but Process Explorer is probably the application that most professionals and tech-savvy Windows users use for that purpose.

Note: Microsoft changed how svchost processes are displayed on Windows 10. The operating system lists one process for each svchost item, and reveals what it is so that it is a lot easier to find out what a process does.

The svchost process caused lots of confusion in the past as users did not know why why several svchost.exe processes were running on the system when they opened the Windows Task Manager or another process viewer.

The services under each svchost process are listed in the left pane, a click opens detailed information about each service on the right larger pane of the application.

It details the amount of computer memory a svchost process is using as well as a description and program path of the services it has spawned.
- No installation required.
- Only requirement is that you have .net installed (ver 2.0 or newer).
- Work in Windows XP to latest Windows OS.
- Coded in C#

![fb98b246-a57b-4b27-8570-742dbf9a945b](https://user-images.githubusercontent.com/74606519/123817989-e6c39b00-d8f8-11eb-85cb-d42a867c98a7.jpg)

Click to get executible: <a href="https://github.com/boss-beep/svchostviewer/blob/Matrix/Svchost%20Viewer.exe">
  <button>Download</button>
</a>
