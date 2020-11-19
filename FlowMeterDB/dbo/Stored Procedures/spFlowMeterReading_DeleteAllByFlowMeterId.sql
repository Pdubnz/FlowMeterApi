CREATE PROCEDURE [dbo].[spFlowMeterReading_DeleteAllByFlowMeterId]
	@FlowMeterId int
AS
BEGIN
	DELETE FROM [dbo].[FlowMeterReading]
	WHERE [FlowMeterId] = @FlowMeterId
END