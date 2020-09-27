

ALTER PROCEDURE [dbo].[SP_GetAllKue] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT k.id,k.gambar,k.id_gambar,nama_kategori,k.nama_kue,k.harga,k.stok from kue k join category c on k.id_category=c.id
END
