USE [Orquestra3]
GO
/****** Object:  StoredProcedure [dbo].[wfSP_GET_VALIDATION_DATA]    Script Date: 11/05/2017 23:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[wfSP_GET_VALIDATION_DATA] (@MinCodFlowExecuteTask int, @CodTask int, @CodUserExecute int, @CodFields VARCHAR(MAX), @CodFieldsIsNull VARCHAR(MAX))

AS

DECLARE @CodFlow int
SELECT @CodFlow = CodFlow FROM wfTASK where CodTask = @CodTask

DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

select @cols = STUFF((SELECT ',' + QUOTENAME(CodField) 
                    from wfTASK_FORM_FIELD_LOG
                    group by CodField
                    order by CodField
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')

set @query =N'SELECT CodFlowExecuteTask, CodFlowExecute, DsFlowResult, ' + @CodFieldsIsNull + N' FROM 
             (
                	SELECT tffl.CodFlowExecuteTask, et.CodFlowExecute, CodField, DsFormFieldValue, DsFlowResult
					FROM wfTASK_FORM_FIELD_LOG tffl
					INNER JOIN wfFLOW_EXECUTE_TASK et ON et.CodFlowExecuteTask = tffl.CodFlowExecuteTask
					WHERE tffl.CodFlow = ' + CAST(@CodFlow AS VARCHAR) + N' AND tffl.CodTask = ' + CAST(@CodTask AS VARCHAR) + N' AND et.CodUserExecute = ' + CAST(@CodUserExecute AS VARCHAR) + N'
					
					AND et.CodFlowExecuteTask = (
												SELECT TOP 1 x.CodFlowExecuteTask
												FROM wfFLOW_EXECUTE_TASK x
												WHERE x.CodFlowExecute = et.CodFlowExecute AND x.CodTask = et.CodTask
												AND x.CodUserExecute = et.CodUserExecute
												ORDER BY CASE WHEN x.DtEndDate IS NULL THEN 1 ELSE 0 END, x.DtEndDate
												)
            ) x
            pivot 
            (
                MAX(DsFormFieldValue)
                FOR CodField IN (' + @CodFields + N')
            ) p 
            ORDER BY CodFlowExecuteTask DESC'

exec sp_executesql @query;