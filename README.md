# Chirper  

Detta är en applikation som använder SignalR för att  
se till att alla klienter uppdateras samtidigt vid förändringar.  
Front end är byggt med React och back end är ASP.NET Core med SignalR Hub.  

Applikationen heter Chirper.  
Användarna kan skapa små medelanden, chirps, i applikationen.  
Dessa chirps visas i klientgränssnittet efter varandra i en lista. Listan uppdateras på alla klienter i realtid när ett chirp skapas, ändras eller tas bort.  

När en användare skapar ett chirp så sätter denne en tag på meddelandet. Detta ord visas sedan i meddelandet
med ett | (pipe) tecken framför.
Ett exempel kan vara |Flingsalt. Uttalas som pipe-tag flingsalt.  
När användaren väljer ut en sådan pipe-tag i en chirp så visas en vy med alla chirps som har denna pipe-tag.  

Alla chirps kan skapas, hämtas, ändras och tas bort (CRUD).

## Tekniker  
ASP.NET Core SignalR.  
React.  
SignalR JavaScript-bibliotek.  
Bootstrap 4.

## Att köra projektet lokalt
Du behöver Node.js installerat.  
Npm används som pakethanterare.  
För att installera Node.js och Npm gå till denna länk:  
[Node.js](https://nodejs.org/en/)  

### Visual Studio 2019
- Klona repositoriet till en map på din lokala dator.
- Öppna filen Chirper.sln med Visual Studio 2019.
- I Visual Studio 2019 starta projektet med IIS.

### VS Code eller valfritt kommandoverktyg
- Klona repositoriet till en map på din lokala dator.
- Gå till mappen \meddelandecentralen_chirper\Chirper\Chirper\ClientApp.
- Ange kommandot ```npm ci```. Detta skapar en mapp som heter node_modules.
- Gå till mappen \meddelandecentralen_chirper\Chirper\Chirper\
- Ange kommandot ```dotnet run chirper```
- Öppna den adress som visas i kommandoverktyget i en webbläsare.
