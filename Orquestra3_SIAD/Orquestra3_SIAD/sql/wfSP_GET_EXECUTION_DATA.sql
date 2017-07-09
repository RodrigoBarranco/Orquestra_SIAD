CREATE PROCEDURE wfSP_GET_EXECUTION_DATA (@CodFlowExecute int, @CodFields VARCHAR(MAX), @CodFieldsIsNull VARCHAR(MAX))

AS

DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

select @cols = STUFF((SELECT ',' + QUOTENAME(CodField) 
                    from wfTASK_FORM_FIELD_LOG
                    group by CodField
                    order by CodField
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')

set @query =N'SELECT CodFlowExecute, ' + @CodFieldsIsNull + N' FROM 
             (
                	SELECT et.CodFlowExecute, CodField, DsFormFieldValue
					FROM wfFLOW_FORM_FIELD_LOG ffl
					WHERE ffl.CodFlowExecute = ' + CAST(@CodFlowExecute AS VARCHAR) + N'
            ) x
            pivot 
            (
                MAX(DsFormFieldValue)
                FOR CodField IN (' + @CodFields + N')
            ) p'

exec sp_executesql @query;