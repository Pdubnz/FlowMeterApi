CREATE TABLE [dbo].[FlowMeter]
(
	[FlowMeterId] INT NOT NULL PRIMARY KEY,
	[Description] NVARCHAR(100) NOT NUll,
	[DateAdded] DATETIME2 NOT NULL DEFAULT getutcdate()
)
