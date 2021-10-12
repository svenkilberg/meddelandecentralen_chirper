# Chirper  

Jag har valt att implementera VD:ns tredje idé. Något i stil med twitter.  

Applikationen heter Chirper.  
De anställda på hotellet kan skapa små medelanden, chirps, i applikationen.  
Dessa chirps visas i klientgränssinittet efter varandra i en lista. Listan uppdateras på alla klienter i realtid  
när ett chirp skapas, ändras eller tas bort.  

Om en användare sätter tecknet | (pipe) framför en text utan mellanslag bildar det en pipe-tag.
Ett exempel kan vara |Flingsalt. Uttalas som pipe-tag flingsalt.  
När användaren väljer ut en sådan pipe-tag i en chirp så visas en vy med alla chirps som har denna pipe-tag. 