CREATE PROCEDURE [dbo].[spFlowMeterReading_Insert]
	@MeterReadingId int,
	@FlowMeterId int,
	@DateTime datetime2,
	@Value FLOAT
AS
BEGIN
	INSERT INTO dbo.FlowMeterReading(MeterReadingId, FlowMeterId, DateTime, Value)
	VALUES(@MeterReadingId, @FlowMeterId, @DateTime, @Value)
END