CREATE PROCEDURE sp_GetProductsPaged
    @PageNumber INT = 1,
    @RowsPerPage INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Products
    ORDER BY Id -- È obbligatorio definire un ordinamento per la paginazione
    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
    FETCH NEXT @RowsPerPage ROWS ONLY;
END
GO