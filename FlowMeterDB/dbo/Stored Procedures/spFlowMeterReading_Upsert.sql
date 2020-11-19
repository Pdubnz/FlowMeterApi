CREATE PROCEDURE [dbo].[spFlowMeterReading_Upsert]
	@MeterReadingId int,
	@FlowMeterId int,
	@DateTime datetime2,
	@Value FLOAT
AS
BEGIN
	--INSERT INTO dbo.FlowMeterReading(MeterReadingId, FlowMeterId, DateTime, Value)
	--VALUES(@MeterReadingId, @FlowMeterId, @DateTime, @Value)

	MERGE [dbo].[FlowMeterReading] AS [Target]
	USING (SELECT @MeterReadingId, @FlowMeterId) AS [Source](MeterReadingId, FlowMeterId)
		ON [Target].FlowMeterId = [Source].FlowMeterId AND [Target].MeterReadingId = [Source].MeterReadingId
	WHEN MATCHED THEN
	  UPDATE SET [Target].[Value] = @Value
	WHEN NOT MATCHED THEN
	  INSERT (MeterReadingId, FlowMeterId, DateTime, Value) VALUES(@MeterReadingId, @FlowMeterId, @DateTime, @Value);
END