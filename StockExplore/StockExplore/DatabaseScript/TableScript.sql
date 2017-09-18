
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockHead]') AND type in (N'U'))
DROP TABLE [dbo].[StockHead]
GO

CREATE TABLE [dbo].[StockHead](
    MarkType    CHAR(2) NOT NULL,               -- 市场类型（沪市、深市、创业板）
    StkCode     CHAR(6) NOT NULL,
    StkName     NVARCHAR(20) NOT NULL,
    StkNameAbbr NVARCHAR(10) DEFAULT('') NOT NULL,
    StkType     CHAR(1) DEFAULT('1') NOT NULL,  -- 0 指数，1 股票
    [RecId]     INT IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_StockHead] PRIMARY KEY CLUSTERED 
(
    [MarkType] ASC,
    [StkCode] ASC    
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_StockHead] ON [dbo].[StockHead] 
(
    [MarkType] ASC,
	[StkCode] ASC,
	[StkType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_StockHead_RecId] ON [dbo].[StockHead] 
(
	[RecId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockHead_StkNameAbbr] ON [dbo].[StockHead] 
(
	[StkNameAbbr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
--SELECT * FROM [StockHead]




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KLineDay]') AND type in (N'U'))
DROP TABLE [dbo].[KLineDay]
GO

CREATE TABLE [dbo].[KLineDay](
	MarkType  CHAR(2) NOT NULL,
    StkCode   CHAR(6) NOT NULL,
    TradeDay  SMALLDATETIME NOT NULL,
    [Open]    MONEY NOT NULL,
    [High]    MONEY NOT NULL,
    [Low]     MONEY NOT NULL,
    [Close]   MONEY NOT NULL,
    Volume    MONEY NOT NULL,
    Amount    MONEY NOT NULL,
    [RecId]   INT IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_KLineDay] PRIMARY KEY CLUSTERED 
(
    [MarkType] ASC,
    [StkCode] ASC,
    [TradeDay] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KLineDay] ON [dbo].[KLineDay] 
(
	[StkCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_KLineDay_RecId] ON [dbo].[KLineDay] 
(
	[RecId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
--SELECT * FROM [KLineDay]




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KLineDayZS]') AND type in (N'U'))
DROP TABLE [dbo].[KLineDayZS]
GO

CREATE TABLE [dbo].[KLineDayZS](
	MarkType  CHAR(2) NOT NULL,
    StkCode   CHAR(6) NOT NULL,
    TradeDay  SMALLDATETIME NOT NULL,
    [Open]    MONEY NOT NULL,
    [High]    MONEY NOT NULL,
    [Low]     MONEY NOT NULL,
    [Close]   MONEY NOT NULL,
    Volume    MONEY NOT NULL,
    Amount    MONEY NOT NULL,
    [RecId]   INT IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_KLineDayZS] PRIMARY KEY CLUSTERED 
(
    [MarkType] ASC,
    [StkCode] ASC,
    [TradeDay] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KLineDayZS] ON [dbo].[KLineDayZS] 
(
	[StkCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_KLineDayZS_RecId] ON [dbo].[KLineDayZS] 
(
	[RecId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
--SELECT * FROM [KLineDayZS]




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KLineWeek]') AND type in (N'U'))
DROP TABLE [dbo].[KLineWeek]
GO

CREATE TABLE [dbo].[KLineWeek](
	MarkType  CHAR(2) NOT NULL,
    StkCode   CHAR(6) NOT NULL,
    TradeDay  SMALLDATETIME NOT NULL,
    [Open]    MONEY NOT NULL,
    [High]    MONEY NOT NULL,
    [Low]     MONEY NOT NULL,
    [Close]   MONEY NOT NULL,
    Volume    MONEY NOT NULL,
    Amount    MONEY NOT NULL,
    [RecId]   INT IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_KLineWeek] PRIMARY KEY CLUSTERED 
(   [MarkType] ASC,
    [StkCode] ASC,
    [TradeDay] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_KLineWeek_RecId] ON [dbo].[KLineWeek] 
(
	[RecId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
--SELECT * FROM [KLineWeek]





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockBlock]') AND type in (N'U'))
DROP TABLE [dbo].[StockBlock]
GO

CREATE TABLE [dbo].[StockBlock](
    StkCode CHAR(6) NOT NULL,
    BKType  NVARCHAR(20) NOT NULL,
    BKName  NVARCHAR(20) NOT NULL,
    [RecId] INT IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_StockBlock] PRIMARY KEY CLUSTERED 
(   [StkCode] ASC,
    [BKType] ASC,
    [BKName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockBlock_StkCode] ON [dbo].[StockBlock] 
(
	[StkCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockBlock_BKType] ON [dbo].[StockBlock] 
(
	[BKType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockBlock_BKName] ON [dbo].[StockBlock] 
(
	[BKName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
CREATE UNIQUE NONCLUSTERED INDEX [IX_StockBlock_RecId] ON [dbo].[StockBlock] 
(
	[RecId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
--SELECT * FROM [StockBlock]










DBCC SHRINKDATABASE(N'tempdb' )
DBCC SHRINKDATABASE(N'StockExp' )