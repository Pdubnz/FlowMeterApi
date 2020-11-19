CREATE PROCEDURE [dbo].[spFlowMeter_DeleteByIdIncludeReadings]
	@FlowMeterId int
AS
BEGIN
	EXEC spFlowMeterReading_DeleteAllByFlowMeterId @FlowMeterId
	EXEC spFlowMeter_DeleteById @FlowMeterId
END
