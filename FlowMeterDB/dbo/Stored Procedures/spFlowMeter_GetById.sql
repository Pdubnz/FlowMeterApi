CREATE PROCEDURE [dbo].[spFlowMeter_GetById]
	@FlowMeterId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [FlowMeterId], [Description], [DateAdded]
	FROM [dbo].[FlowMeter]
	WHERE [FlowMeterId] = @FlowMeterId
END
