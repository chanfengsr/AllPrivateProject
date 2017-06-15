
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockHead]') AND type in (N'U'))
DROP TABLE [dbo].[StockHead]
GO

CREATE TABLE [dbo].[StockHead](
    MarkType    CHAR(2) NOT NULL,               -- 沪市、深市、创业板
    StkCode     CHAR(6) NOT NULL,
    StkName     NVARCHAR(20) NOT NULL,
    StkType     CHAR(1) DEFAULT('1') NOT NULL,  -- 0 指数，1 股票
 CONSTRAINT [PK_StockHead] PRIMARY KEY CLUSTERED 
(
	[MarkType] ASC,
    [StkCode] ASC    
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockHead] ON [dbo].[StockHead] 
(
	[StkType] ASC,
	[MarkType] ASC,
	[StkCode] ASC
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
 CONSTRAINT [PK_KLineDay] PRIMARY KEY CLUSTERED 
(
	[MarkType] ASC,
    [StkCode] ASC,
    [TradeDay] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
--SELECT * FROM [KLineDay]