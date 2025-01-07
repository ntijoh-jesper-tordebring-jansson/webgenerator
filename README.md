# Webgenerator
Verktyg för att generera HTML filer från MD filer. 

## Funktionalitet
En input mapp kommer finnas där HTML filer och bilder läggs. Därefter körs programmet och en ny mapp genereras där det finns HTML filer med samma innehåll som MD filerna, fast i korrekt format. Dessa HTML filer kan därefter läggas in i en webbserver. 

## Setup
Först behöver du ha Dotnet 8.0 installerat. 

## Kommandon
"dotnet run -- seed" för att seeda databasen med markdown regler. 

"dotnet run" för att bygga och köra applikationen. 