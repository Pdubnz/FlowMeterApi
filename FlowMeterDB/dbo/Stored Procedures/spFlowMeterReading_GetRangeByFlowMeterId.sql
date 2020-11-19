CREATE PROCEDURE [dbo].[spFlowMeterReading_GetRangeByFlowMeterId]
@FlowMeterId int,
	@StartDate DateTime2,
	@EndDate DateTime2
	
AS
BEGIN
	SELECT [MeterReadingId], [FlowMeterId], [DateTime], [Value]
	FROM [dbo].[FlowMeterReading]
	WHERE [FlowMeterId] = @FlowMeterId and
	[DateTime] BETWEEN @StartDate and @EndDate
END
