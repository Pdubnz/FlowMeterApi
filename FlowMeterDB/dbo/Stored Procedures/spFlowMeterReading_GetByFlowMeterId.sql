CREATE PROCEDURE [dbo].[spFlowMeterReading_GetByFlowMeterId]
	@FlowMeterId int
AS
BEGIN
	SELECT [MeterReadingId], [FlowMeterId], [DateTime], [Value]
	FROM [dbo].[FlowMeterReading]
	WHERE [FlowMeterId] = @FlowMeterId
END