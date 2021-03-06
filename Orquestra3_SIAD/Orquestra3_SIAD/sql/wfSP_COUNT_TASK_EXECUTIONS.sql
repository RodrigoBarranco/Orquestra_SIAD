USE [Orquestra3]
GO
/****** Object:  StoredProcedure [dbo].[wfSP_COUNT_TASK_EXECUTIONS]    Script Date: 09/05/2017 18:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[wfSP_COUNT_TASK_EXECUTIONS] (@CodTask int)

AS

DECLARE @CodFlow INT
SELECT @CodFlow = CodFlow FROM wfTASK where CodTask = @CodTask

SELECT COUNT(*) 
FROM wfFLOW_EXECUTE_TASK
WHERE CodTask = @CodTask 
AND CodFlow = @CodFlow AND DtEndDate IS NOT NULL AND (CodFlowResult IS NOT NULL OR DsFlowResult IS NOT NULL)