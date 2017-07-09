CREATE PROCEDURE wfSP_GET_PENDING_TASKS (@CodUser INT, @CodTask INT) AS

SELECT * FROM wfFLOW_EXECUTE_TASK et
INNER JOIN wfFLOW_EXECUTE_TASK_POSITION etp
ON etp.CodFlowExecuteTask = et.CodFlowExecuteTask
WHERE et.StTaskActive = 'S' AND et.DtEndDate IS NULL
AND et.CodTask = @CodUser AND etp.CodUser = @CodTask AND etp.StTaskPositionActive = 'S'