# Esercitazione ALM

## Descrizione Generale
Il team deve realizzare un servizio web per un sistema di gestione dei Ticket di supporto IT.

### Entità
- **Ticket**
    - Data di creazione *(datetime)*
    - Richiedente *(string)*
    - Descrizione Breve *(string)*
    - Descrizione Lunga *(string)*
    - Categoria [*FK*]
    - Stato [*FK*]
    - Assegnatario (gestore del Ticket) *(string)*
    - Data di Chiusura *(datetime)*
- Entità Anagrafiche
    - **Categoria**
        - valori possibili: System, Development, Office Application, SAP, Other
    - **Stato** 
        - valori possibili: Nuovo, Assegnato, In Risoluzione, Chiuso

### Requisiti del backend
- il servizio dovrà permettere la gestione delle operazioni CRUD sulle anagrafiche
- per quanto riguarda i Ticket dovrà permettere la 
    - lettura della lista dei Ticket e del singolo Ticket
    - creazione di un nuovo Ticket
    - assegnazione del Ticket (con cambio di stato)
    - modifica delle informazioni del Ticket
    - chiusura del Ticket (con cambio di stato)

### Requisiti del frontend
- realizzare una console app che si colleghi al backend per
    - mostrare la lista dei Ticket
    - permetta l'inserimento di un nuovo Ticket
    - permetta la chiusura di un Ticket esistente

## Requisiti Tecnici
- utilizzare ASP.NET Core WebAPI
- realizzare una architettura con Business Layer / Data Layer (EF e/o Mock)
- realizzare una batteria di test unitari per verificare il comportamento del BL
    - implementare almeno un test per 2 diverse entità
- mantenere i requisiti e il codice in Azure DevOps
    - utilizzare le board per decrivere i requisiti ed assegnare le attività all'interno del team