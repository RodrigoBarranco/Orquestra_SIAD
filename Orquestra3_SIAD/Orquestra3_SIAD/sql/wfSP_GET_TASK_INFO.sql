SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE wfSP_GET_TASK_INFO (@CodFlowExecuteTask int)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 CodFlow, CodFlowExecute, CodTask, DsTaskTitle
	FROM wfVWFLOW_EXECUTE_TASK
	WHERE CodFlowExecuteTask = @CodFlowExecuteTask

END
GO
