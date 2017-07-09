ALTER PROCEDURE wfSP_GET_TASK_RESULTS (@CodTask int)

AS

SELECT DsFlowResult FROM
(
	-- Concluído/Aprovado
	SELECT 'DsFlowResult' = 
		CASE 
			WHEN tg.StShowPositiveButton = 'S' AND t.CodTaskType = 1 THEN 'Concluído'
			WHEN tg.StShowPositiveButton = 'S' AND t.CodTaskType = 2 THEN 'Aprovado'
		END
	FROM
	wfTASK_GENERAL tg
	INNER JOIN wfTASK t ON T.CodTask = tg.CodTask
	WHERE tg.CodTask = @CodTask

	UNION ALL

	-- Não concluído / Rejeitado
	SELECT 'DsFlowResult' = 
		CASE 
			WHEN tg.StShowNegativeButton = 'S' AND t.CodTaskType = 1 THEN 'Não-Concluído'
			WHEN tg.StShowNegativeButton = 'S' AND t.CodTaskType = 2 THEN 'Rejeitado'
		END
	FROM
	wfTASK_GENERAL tg
	INNER JOIN wfTASK t ON T.CodTask = tg.CodTask
	WHERE tg.CodTask = @CodTask

	UNION ALL

	-- Botões customizados
	SELECT DsButtonAction
	FROM WFTASK_BUTTON tb
	WHERE CodTask = @CodTask
) AS a
WHERE DsFlowResult IS NOT NULL