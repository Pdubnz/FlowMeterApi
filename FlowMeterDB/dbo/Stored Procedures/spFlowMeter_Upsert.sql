CREATE PROCEDURE [dbo].[spFlowMeter_Upsert]
	@FlowMeterId int,
	@Description NVARCHAR(100),
	@DateAdded datetime2
AS
BEGIN
	--INSERT INTO [dbo].[FlowMeter](FlowMeterId, Description, DateAdded)
	--VALUES(@FlowMeterId, @Description, @DateAdded)

	MERGE [dbo].[FlowMeter] AS [Target]
	USING (SELECT @FlowMeterId AS FlowMeterId) AS [Source](FlowMeterId)
		ON [Target].FlowMeterId = [Source].FlowMeterId
	WHEN MATCHED THEN
	  UPDATE SET [Target].[Description] = @Description
	WHEN NOT MATCHED THEN
	  INSERT (FlowMeterId, Description, DateAdded) VALUES(@FlowMeterId, @Description, @DateAdded);

END

