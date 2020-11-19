CREATE PROCEDURE [dbo].[spFlowMeter_DeleteById]
	@FlowMeterId int
AS
BEGIN
	DELETE FROM [dbo].[FlowMeter]
	WHERE [FlowMeterId] = @FlowMeterId
END
