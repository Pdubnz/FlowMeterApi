CREATE PROCEDURE [dbo].[spFlowMeter_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT [FlowMeterId], [Description], [DateAdded]
	FROM dbo.[FlowMeter]
END
