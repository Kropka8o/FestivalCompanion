# Conventies
## Inhoud
- [Code](#code)
- [Generiek](#generiek)
- [Naamgevingsconventies](#naamgevingsconventies)
- [Code Structuur](#code-structuur)
- [Documentatie](#documentatie)

## Code
### Generiek
- De code is in het Engels geschreven, dit betreft alle variabelen, methodes, klasses, etc. namen en commentaar.
- Branches en commits zijn geschreven in het Nederlands.
- De output van de app is Nederlandstalig.
- Commentaar wordt alleen toegevoegd om uit te leggen _waarom_ code is geschreven zoals het is, _niet_ om uit te leggen wat het doet. (Verwijder dus het commentaar dat AI schrijft!)
- Gebruik beschrijvende namen, _niet_ str, _maar_ userName.
- Indentatie is 4 spaties, _niet_ tabs (kan ingesteld worden in je editor).
- Accolades worden op de volgende regel geplaatst.
- _Geen_ trailing comma's.
### Naamgevingsconventies
- Lokale variabele volgen camelCase, bijv.:
  - num.
  - currentOrder.
  - firstProduct.
- Eigenschappen volgen PascalCase, bijv.:
  - Name.
  - Username.
  - MinimumAge.
- Methodes volgen camelCase, bijv.:
  - getProduct.
  - addNumbers.
  - saveUser.
- Klassennamen volgen PascalCase, bijv.:
  - AppDataContext.
  - Order.
  - Product.
- Bestanden volgen dezelfde naamgevingsconventies als de bijbehorende klasse, bijv.:
    - Order.cs bevat de definitie van de Order-klasse.
    - Product.cs bevat de definitie van de Product-klasse.
    - User.cs bevat de definitie van de User-klasse.
 - Branches volgend camelCase en worden ingedeeld op de categorie functie of fix, bijv.:
    - functie/homePaginaToevoegen.
    - functie/kleurenPaletteToepassen.
    - fix/inlogWachtwoordBugOplossen.
### Code structuur
- `Models/` Bevat de klassen.
- `Controllers` Bevat de controllers.
- `Views/` Bevat de pagina's van de webapp.
## Documentatie
- Documentatie wordt in het Nederlands geschreven, met uitzondering op vaktermen die moeilijk zijn te vertalen.
