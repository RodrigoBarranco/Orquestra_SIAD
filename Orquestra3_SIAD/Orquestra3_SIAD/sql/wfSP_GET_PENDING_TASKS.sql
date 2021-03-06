USE [Orquestra3]
GO
/****** Object:  StoredProcedure [dbo].[wfSP_GET_PENDING_TASKS]    Script Date: 23/03/2017 14:45:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[wfSP_GET_PENDING_TASKS] (@CodUser INT, @CodTask INT) AS

SELECT * FROM wfFLOW_EXECUTE_TASK et
INNER JOIN wfFLOW_EXECUTE_TASK_POSITION etp
ON etp.CodFlowExecuteTask = et.CodFlowExecuteTask
WHERE et.StTaskActive = 'S' AND et.DtEndDate IS NULL
AND etp.CodUser = @CodUser AND et.CodTask = @CodTask AND etp.StTaskPositionActive = 'S'