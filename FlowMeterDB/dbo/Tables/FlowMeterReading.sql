CREATE TABLE [dbo].[FlowMeterReading]
(
	[MeterReadingId] INT PRIMARY KEY,
	[FlowMeterId] INT NOT NULL,
	[DateTime] DATETIME2 NOT NULL,
	[Value] FLOAT NOT NULL,
	CONSTRAINT [FK_FlowMeterReading_ToFlowMeter] FOREIGN KEY (FlowMeterId) REFERENCES FlowMeter(FlowMeterId)
)
