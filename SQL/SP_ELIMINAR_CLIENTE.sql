CREATE PROCEDURE SP_ELIMINAR_CLIENTE(
	@IDCLIENTE INT
)
AS
BEGIN
	DELETE FROM CLIENTES WHERE IDCLIENTE = @IDCLIENTE;
END;