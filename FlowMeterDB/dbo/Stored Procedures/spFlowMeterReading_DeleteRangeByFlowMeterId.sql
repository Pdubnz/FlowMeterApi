CREATE PROCEDURE [dbo].[spFlowMeterReading_DeleteRangeByFlowMeterId]
	@FlowMeterId int,
	@StartDate DateTime2,
	@EndDate DateTime2
	
AS
BEGIN
	DELETE FROM [dbo].[FlowMeterReading]
	WHERE [FlowMeterId] = @FlowMeterId and
	[DateTime] BETWEEN @StartDate and @EndDate
END
