CREATE PROCEDURE [dbo].[spFlowMeter_Insert]
	@FlowMeterId int,
	@Description NVARCHAR(100),
	@DateAdded datetime2
AS
BEGIN
	INSERT INTO [dbo].[FlowMeter](FlowMeterId, Description, DateAdded)
	VALUES(@FlowMeterId, @Description, @DateAdded)
END
