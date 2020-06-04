# Struktura Backendu
## Data
04.06.20

## Status
Przyjęto

## Kontekst
Wybór struktury projektu może nakreślić resktrykcje,w celu utrzymania porządku,
prostrzego rozwijania w przyszłość, zwiększjąc złożoność projektu.

## Rozwiązanie
1. Brak wyraźnej struktury
2. 3-layer
3. One-layer

## Decyzja
Wprowadzamy strukturę 3-layer ponieważ dzieli logikę biznesową od endpoints,
oraz kontaktu z bazą danych co zmiejsza lokalną złożoność, 
oraz zwiększa abstrakcję całego systemu.

## Konsekwencje
Dezycja uprości lokalną złożoność, dając mniej skomplikowane zależności
między komponentami, kosztem większej ilość kodu.
Ale to niewielka cena za prostrze utrzyamnie systemu, czyż nie? 

## Autor
[@jjzajac](https://github.com/jjzajac)

###### tags: `Digital Owl , adr, backend`
