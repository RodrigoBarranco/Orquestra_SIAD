USE [Orquestra3]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wfSP_DEACTIVATE_AUTOMATIC_TASK_EXECUTION] (@CodTask int, @CodUser int)
AS

DELETE FROM AutomaticTaskExecution WHERE CodTask = @CodTask AND  CodUser = @CodUser