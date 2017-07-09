ALTER PROCEDURE wfSP_GET_TASK_RESULTS (@CodTask int)

AS

SELECT DsFlowResult FROM
(
	-- Conclu�do/Aprovado
	SELECT 'DsFlowResult' = 
		CASE 
			WHEN tg.StShowPositiveButton = 'S' AND t.CodTaskType = 1 THEN 'Conclu�do'
			WHEN tg.StShowPositiveButton = 'S' AND t.CodTaskType = 2 THEN 'Aprovado'
		END
	FROM
	wfTASK_GENERAL tg
	INNER JOIN wfTASK t ON T.CodTask = tg.CodTask
	WHERE tg.CodTask = @CodTask

	UNION ALL

	-- N�o conclu�do / Rejeitado
	SELECT 'DsFlowResult' = 
		CASE 
			WHEN tg.StShowNegativeButton = 'S' AND t.CodTaskType = 1 THEN 'N�o-Conclu�do'
			WHEN tg.StShowNegativeButton = 'S' AND t.CodTaskType = 2 THEN 'Rejeitado'
		END
	FROM
	wfTASK_GENERAL tg
	INNER JOIN wfTASK t ON T.CodTask = tg.CodTask
	WHERE tg.CodTask = @CodTask

	UNION ALL

	-- Bot�es customizados
	SELECT DsButtonAction
	FROM WFTASK_BUTTON tb
	WHERE CodTask = @CodTask
) AS a
WHERE DsFlowResult IS NOT NULL