
--RESTORE DATABASE [StockExp] FROM  DISK = N'H:\StockExp.bak' WITH  FILE = 1,  MOVE N'StockExp' TO N'D:\Data\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\StockExp.mdf',  MOVE N'StockExp_log' TO N'D:\Data\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\StockExp.ldf',  NOUNLOAD,  REPLACE,  STATS = 10

/*
TRUNCATE TABLE StockHead
TRUNCATE TABLE KLineDay
TRUNCATE TABLE KLineDayZS
TRUNCATE TABLE KLineWeek
TRUNCATE TABLE StockBlock
DBCC SHRINKDATABASE(N'tempdb' )
DBCC SHRINKDATABASE(N'StockExp' )
*/
SET NOCOUNT ON

SELECT * FROM StockHead  WHERE StkCode = '999999'
SELECT * FROM KLineDay   WHERE StkCode = '999999'
SELECT * FROM KLineDayZS WHERE StkCode = '999999'
SELECT * FROM KLineWeek  WHERE StkCode = '999999'
SELECT * FROM StockBlock

SELECT * FROM StockHead WHERE StkCode IN ('000009','000010','000016','000903','000905') ORDER BY StkType

--�г����ͣ����С����С���ҵ�壩
SELECT * FROM KLineDay WHERE MarkType = '{}'

SELECT * FROM StockHead  WHERE StkCode = '603999'