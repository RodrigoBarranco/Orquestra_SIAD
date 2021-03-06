
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[wfSP_NOTIFY_AUTOMATIC_TASK_EXECUTION] (
														@CodTask int, 
														@CodUser int, 
														@CodFlowExecute int)
AS

DECLARE @Codflow INT
SELECT @Codflow = CodFlow FROM wfFLOW_EXECUTE WHERE CodFlowExecute = @CodFlowExecute

DECLARE @DsName VARCHAR(MAX)
SELECT @DsName = DsName FROM wUSER WHERE CodUser = @CodUser

DECLARE @DsTaskTitle VARCHAR(MAX)
SELECT @DsTaskTitle = DsTaskTitle FROM wfTASK WHERE CodTask = @CodTask

DECLARE @SystemDomain VARCHAR(MAX)
SELECT @SystemDomain = DsParameterValue FROM wPARAMETER WHERE DsParameterKey = 'SYSTEM_DOMAIN'

INSERT INTO wNOTIFICATION (
							CodUserFrom, 
							CodUserTo, 
							CodFlowExecute, 
							CodFlow, 
							StType, 
							StShow, 
							DsSubject, 
							DsBody, 
							DtDate, 
							StRead)
				VALUES (
						1321,
						@CodUser,
						@CodFlowExecute,
						@Codflow,
						'MessageEvent',
						'S',
						'Tarefa concluída automaticamente',
						'Olá ' + @DsName + ', <br><br> A tarefa <b>' + @DsTaskTitle + '</b> do processo nº <b>' + CAST(@CodFlowExecute AS VARCHAR(MAX)) + 
						'</b> foi finalizada automaticamente. <br><br>' + 'Para maiores informações acesse o <a href="' + @SystemDomain 
						+ 'workflow/wfrel_tracker_detail.aspx?inpCodFlowExecute=' + CAST(@CodFlowExecute AS VARCHAR(MAX)) + '">relatório do processo</a>',
						GETDATE(),
						'N')

