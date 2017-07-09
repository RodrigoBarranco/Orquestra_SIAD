ALTER PROCEDURE wfSP_COUNT_TASK_EXECUTIONS_BY_USER (@CodTask int, @CodUserExecute int)

AS

DECLARE @CodFlow INT
SELECT @CodFlow = CodFlow FROM wfTASK where CodTask = @CodTask

SELECT COUNT(*) 
FROM wfFLOW_EXECUTE_TASK
WHERE CodTask = @CodTask 
AND CodUserExecute = @CodUserExecute
AND CodFlow = @CodFlow