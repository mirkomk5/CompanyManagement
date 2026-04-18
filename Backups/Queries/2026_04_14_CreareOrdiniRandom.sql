
INSERT INTO Orders (CustomerId, ProductId, CreatedAt, Notes)
SELECT TOP 10 
    C.Id,           -- Prende l'Id dalla tabella Customers
    P.Id,           -- Prende l'Id dalla tabella Products
    GETDATE(),      -- Data attuale
    'Ordine random generato automaticamente'
FROM Users C
CROSS JOIN Products P  -- Crea tutte le combinazioni possibili
ORDER BY NEWID();      -- Mescola i risultati in modo casuale