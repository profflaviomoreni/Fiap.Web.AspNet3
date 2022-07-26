DECLARE @REPRE INT;
SET @REPRE = 0;


SELECT
	*
FROM
	Cliente
WHERE
	NOME LIKE '%la%'		AND
	( @REPRE = 0 OR RepresentanteId = @REPRE )  