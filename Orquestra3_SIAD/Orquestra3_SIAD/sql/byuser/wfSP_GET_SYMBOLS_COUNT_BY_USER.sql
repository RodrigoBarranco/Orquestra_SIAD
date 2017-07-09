ALTER PROCEDURE wfSP_GET_SYMBOLS_COUNT_BY_USER (@CodTask int, @CodUserExecute int)

AS

DECLARE @CodFlow int
SELECT @CodFlow = CodFlow FROM wfTASK where CodTask = @CodTask

SELECT DISTINCT CodField, DsFieldName, SymbolsCount
FROM(
	SELECT
		tffl.CodField,
		ff.DsFieldName,
		tffl.DsFormFieldValue,
		SUM(1) OVER (PARTITION BY tffl.CodField) as SymbolsCount
	FROM
		wfTASK_FORM_FIELD_LOG tffl
	INNER JOIN
		wfFLOW_EXECUTE_TASK et ON et.CodFlowExecuteTask = tffl.CodFlowExecuteTask
	INNER JOIN 
		wfFORM_FIELD ff ON ff.CodField = tffl.CodField
	WHERE	
		et.CodUserExecuteOriginal IS NULL
		AND tffl.codflow = @CodFlow
		AND et.CodTask = @CodTask
		AND et.CodUserExecute = @CodUserExecute
		AND tffl.DsFormFieldValue IS NOT NULL
		
		AND et.CodFlowExecuteTask = (
									-- Seleciona apenas a primeira execução da tarefa
									SELECT TOP 1 x.CodFlowExecuteTask
									-- JOIN COM wfTASK_FORM_FIELD_LOG GARANTE A EXISTÊNCIA DOS REGISTROS
									FROM wfFLOW_EXECUTE_TASK x
									WHERE x.CodFlowExecute = et.CodFlowExecute AND x.CodTask = et.CodTask
									AND x.CodUserExecute = et.CodUserExecute
									ORDER BY CASE WHEN x.DtEndDate IS NULL THEN 1 ELSE 0 END, x.DtEndDate
									)

	GROUP BY tffl.CodField, ff.DsFieldName, Cast(DsFormFieldValue As varbinary(MAX)), DsFormFieldValue
) AS a
ORDER BY SymbolsCount